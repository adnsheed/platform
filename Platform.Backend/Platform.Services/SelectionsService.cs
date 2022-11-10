using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Platform.Common;
using Platform.Core.Entities;
using Platform.Core.Extensions;
using Platform.Core.Interfaces;
using Platform.Core.Requests.Selection;
using Platform.Core.Requests.Student;
using Platform.Database;
using System.Linq.Dynamic.Core;

namespace Platform.Services
{
    public class SelectionsService : ISelectionsService
    {
        private readonly IMapper mapper;
        private readonly PlatformDbContext context;

        public SelectionsService(IMapper mapper, PlatformDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }
        public async Task<ServiceResponse<SelectionDto>> AddStudent(Guid slectionId, int studentId, Guid programId)
        {
            var student = await context.Students
               .FirstOrDefaultAsync(s => s.Id == studentId);

            if (student == null)
            {
                throw new KeyNotFoundException("Student not found");
            }

            var selection = await context.Selections
                .Include(s => s.Students)
                .FirstOrDefaultAsync(s => s.Id == slectionId);

            if (selection == null)
            {
                throw new KeyNotFoundException("Selection not found");
            }

            selection.Students.Add(student);
            await context.SaveChangesAsync();

            var program = await context.Programs
               .Include(p => p.Selections)
               .ThenInclude(s => s.Students)
               .ThenInclude(s => s.ItemStudents)
               .Include(p => p.ItemPrograms.OrderBy(ip => ip.OrderNumber))
               .ThenInclude(ip => ip.Item)
               .FirstOrDefaultAsync(p => p.Id == programId);

            if (program == null)
            {
                throw new KeyNotFoundException("Program not found");
            }

            for (int i = 0; i < program.ItemPrograms.Count; i++)
            {

                var duration = Math.Ceiling((double)program.ItemPrograms[i].Item.WorkHours / 8);

                var startDate = i == 0 ? student.Selection.StartDate : program.ItemPrograms[i - 1].ItemStudents[0].EndDate;

                var endDate = i == 0 ? student.Selection.StartDate.AddDays(duration) : startDate?.AddDays(duration);

                context.ItemStudents.Add(new ItemStudent
                {
                    ItemProgramId = program.ItemPrograms[i].Id,
                    StudentId = student.Id,
                    StartDate = startDate,
                    EndDate = endDate,

                });
            }

            await context.SaveChangesAsync();

            var selectionResponse = await context.Selections.
                Include(s => s.Program)
               .Include(s => s.Students)
               .FirstOrDefaultAsync(s => s.Id == slectionId);

            return new ServiceResponse<SelectionDto>()
            {
                Data = mapper.Map<SelectionDto>(selectionResponse)
            };
        }

        public async Task<ServiceResponse<SelectionDto>> Create(CreateSelectionDto newSelection)
        {
            var program = await context.Programs
                .FirstOrDefaultAsync(p => p.Id == newSelection.ProgramId);

            if (program == null)
            {
                throw new KeyNotFoundException("Program not found");
            }

            var student = await context.Students
                .FirstOrDefaultAsync(s => s.Id == newSelection.StudentId);


            if (student == null)
            {
                throw new KeyNotFoundException("Student not found");
            }

            Selection selection = new Selection
            {
                Title = newSelection.Title,
                StartDate = newSelection.StartDate,
                Status = newSelection.Status,
                Program = program
            };

            student.Selection = selection;
            context.Selections.Add(selection);

            await context.SaveChangesAsync();

            return new ServiceResponse<SelectionDto>()
            {
                Data = mapper.Map<SelectionDto>(selection)
            };
        }

        public async Task<ServiceResponse<List<SelectionDto>>> Delete(Guid id)
        {
            var selection = await context.Selections
               .FirstOrDefaultAsync(s => s.Id == id);

            if (selection == null)
            {
                throw new KeyNotFoundException("Selection not found");
            }

            context.Selections.Remove(selection);

            await context.SaveChangesAsync();

            return new ServiceResponse<List<SelectionDto>>()
            {
                Data = await context.Selections
                .Include(s => s.Program)
                .Include(s => s.Students)
                .Select(s => mapper.Map<SelectionDto>(s))
                .ToListAsync()
            };
        }

        public async Task<ServiceResponse<List<SelectionDto>>> GetAll(RequestParameters selectionParameters)
        {
            var selections = context.Selections.AsQueryable();

            if (!string.IsNullOrWhiteSpace(selectionParameters.Filter) && !string.IsNullOrWhiteSpace(selectionParameters.Value))
            {
                if (selectionParameters.Filter == "program")
                {
                    selections = selections.Where(s => s.Program.Title.ToUpper().Contains(selectionParameters.Value.Trim().ToUpper()));

                }
                else
                {
                    selections = selections.Where(selectionParameters.Filter + $"= \"{selectionParameters.Value}\"");
                }
            };

            if (!string.IsNullOrWhiteSpace(selectionParameters.Sort))
            {
                if (selectionParameters.Sort == "program")
                {
                    selections = selections.OrderBy("program.title");
                }
                else if (selectionParameters.Sort == "program desc")
                {
                    selections = selections.OrderBy("program.title desc");
                }
                else
                {
                    selections = selections.OrderBy(selectionParameters.Sort);
                }
            }
            var count = selections.Count();
            var pages = (int)Math.Ceiling((double)selections.Count() / selectionParameters.PageSize);

            selections = selections
                .Page(selectionParameters.Page, selectionParameters.PageSize)
                .Include(s => s.Program)
                .Include(s => s.Students);


            var response = new ServiceResponse<List<SelectionDto>>
            {
                Data = await selections.Select(s => mapper.Map<SelectionDto>(s)).ToListAsync(),
                Pages = pages,
                Count = count
            };
            return response;
        }

        public async Task<ServiceResponse<SelectionDto>> GetById(Guid id)
        {
            var selection = await context.Selections.
             Include(s => s.Program)
            .Include(s => s.Students)
            .FirstOrDefaultAsync(s => s.Id == id);

            if (selection == null)
            {
                throw new KeyNotFoundException("Selection not found");
            }

            return new ServiceResponse<SelectionDto>()
            {
                Data = mapper.Map<SelectionDto>(selection)
            };
        }

        public async Task<ServiceResponse<SelectionDto>> RemoveStudent(Guid slectionId, int studentId)
        {
            var student = await context.Students
              .FirstOrDefaultAsync(s => s.Id == studentId);

            if (student == null)
            {
                throw new KeyNotFoundException("Student not found");
            }

            Selection? selection = await context.Selections
                .Include(s => s.Students)
                .FirstOrDefaultAsync(s => s.Id == slectionId);

            if (selection == null)
            {
                throw new KeyNotFoundException("Selection not found");
            }

            selection.Students.Remove(student);
            await context.SaveChangesAsync();

            var selectionResponse = await context.Selections.
                Include(s => s.Program)
               .Include(s => s.Students)
               .FirstOrDefaultAsync(s => s.Id == slectionId);

            return new ServiceResponse<SelectionDto>()
            {
                Data = mapper.Map<SelectionDto>(selectionResponse)
            };
        }

        public async Task<ServiceResponse<SelectionDto>> Update(Guid id, UpdateSelectionDto updatedSelection)
        {
            var selection = await context.Selections
               .FirstOrDefaultAsync(s => s.Id == id);

            if (selection == null)
            {
                throw new KeyNotFoundException("Selection not found");
            }

            selection.Title = updatedSelection.Title;
            selection.Status = updatedSelection.Status;
            selection.StartDate = updatedSelection.StartDate;
            selection.EndDate = updatedSelection.EndDate;

            await context.SaveChangesAsync();

            var selectionResponse = await context.Selections.
                Include(s => s.Program)
               .Include(s => s.Students)
               .FirstOrDefaultAsync(s => s.Id == id);

            return new ServiceResponse<SelectionDto>()
            {
                Data = mapper.Map<SelectionDto>(selectionResponse)
            };
        }
    }
}
