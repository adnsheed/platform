using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Platform.Common;
using Platform.Core.Entities;
using Platform.Core.Extensions;
using Platform.Core.Interfaces;
using Platform.Core.Requests.Mail;
using Platform.Core.Requests.Student;
using Platform.Database;
using System.Linq.Dynamic.Core;


namespace Platform.Services
{
    public class StudentsService : IStudentsService
    {
        private readonly IMapper mapper;
        private readonly PlatformDbContext context;
        private readonly IMailService mailService;
        private readonly UserManager<User> userManager;

        public StudentsService(IMapper mapper, PlatformDbContext context, IMailService mailService, UserManager<User> userManager)
        {
            this.mapper = mapper;
            this.context = context;
            this.mailService = mailService;
            this.userManager = userManager;
        }

        public async Task<ServiceResponse<List<StudentDto>>> Create(CreateStudentDto createStudent)
        {
            var userExists = await context.Users
                .AnyAsync(user => user.UserName == createStudent.UserName.ToLower().Trim());

            if (userExists)
            {
                throw new BadHttpRequestException("User already exists");
            }

            var selection = await context.Selections
            .FirstOrDefaultAsync(s => s.Id == createStudent.SelectionId);

           
            var student = mapper.Map<Student>(createStudent);
            
            student.UserName = createStudent.UserName.ToLower().Trim();

            var result = await userManager.CreateAsync(student, createStudent.Password);

            if (!result.Succeeded)
            {
                throw new BadHttpRequestException(result.Errors.First().Description);
            }

            await userManager.AddToRoleAsync(student, "Student");

            var template = EmailTemplate.Template(student.UserName, createStudent.Password);
            
            var email = await mailService.SendEmail(student.Email, EmailTemplate.Subject, template);

            return new ServiceResponse<List<StudentDto>>()
            {
                Data = await context.Students
                .Include(s => s.Selection)
                .ThenInclude(s => s.Program)
                .Include(c => c.Comments)
                .Select(s => mapper.Map<StudentDto>(s)).ToListAsync()
            };
        }

        public async Task<ServiceResponse<List<StudentDto>>> Delete(int id)
        {
            var student = await context.Students
             .FirstOrDefaultAsync(s => s.Id == id);

            if (student == null)
            {
                throw new KeyNotFoundException("Student not found");
            }

            context.Students.Remove(student);
            await context.SaveChangesAsync();

            return new ServiceResponse<List<StudentDto>>()
            {
                Data = await context.Students
                .Include(s => s.Selection)
                .ThenInclude(s => s.Program)
                .Select(s => mapper.Map<StudentDto>(s)).ToListAsync()
            };
        }

        public async Task<ServiceResponse<List<StudentDto>>> GetAll(RequestParameters studentParameters)
        {
            var students = context.Students.AsQueryable();

            if (!string.IsNullOrWhiteSpace(studentParameters.Filter) && !string.IsNullOrWhiteSpace(studentParameters.Value))
            {
                if (studentParameters.Filter == "program")
                {
                    students = students.Where(s => s.Selection.Program.Title.ToUpper().Contains(studentParameters.Value.Trim().ToUpper()));
                }
                else if (studentParameters.Filter == "selection")
                {
                    students = students.Where(s => s.Selection.Title == studentParameters.Value);
                }
                else
                {
                    students = students.Where(studentParameters.Filter + $"= \"{studentParameters.Value}\"");
                }
            };

            if (!string.IsNullOrWhiteSpace(studentParameters.Sort))
            {
                switch (studentParameters.Sort)
                {
                    case "program":
                        students = students.OrderBy("selection.program.title");
                        break;
                    case "program desc":
                        students = students.OrderBy("selection.program.title desc");
                        break;
                    case "selection":
                        students = students.OrderBy("selection.title");
                        break;
                    case "selection desc":
                        students = students.OrderBy("selection.title desc");
                        break;
                    default:
                        students = students.OrderBy(studentParameters.Sort);
                        break;
                }
            }

            var count = students.Count();

            var pages = (int)Math.Ceiling((double)students.Count() / studentParameters.PageSize);

            students = students.Page(studentParameters.Page, studentParameters.PageSize)
                               .Include(s => s.Selection)
                               .ThenInclude(s => s.Program);

            var response = new ServiceResponse<List<StudentDto>>
            {
                Data = await students
                .Select(s => mapper.Map<StudentDto>(s))
                .ToListAsync(),
                Pages = pages,
                Count = count
            };

            return response;
        }

        public async Task<ServiceResponse<StudentDto>> GetById(int id)
        {
            var student = await context.Students
                .Include(s => s.Selection)
                .Include(c => c.Comments)
                .Include(i => i.ItemStudents.OrderBy(ip => ip.ItemProgram.OrderNumber))
                .ThenInclude(ip=> ip.ItemProgram)
                .ThenInclude(i=> i.Item)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (student == null)
            {
                throw new KeyNotFoundException("Student not found");
            }

            return new ServiceResponse<StudentDto>()
            {
                Data = mapper.Map<StudentDto>(student)
            };
        }

        public async Task<ServiceResponse<StudentDto>> Update(int id, UpdateStudentDto updatedStudent)
        {
            var selection = await context.Selections
            .FirstOrDefaultAsync(s => s.Id == updatedStudent.SelectionId);

            var student = await context.Students
               .FirstOrDefaultAsync(s => s.Id == id);

            if (student == null)
            {
                throw new KeyNotFoundException("Student not found");
            }

            student = mapper.Map(updatedStudent, student);

            await context.SaveChangesAsync();

            return new ServiceResponse<StudentDto>()
            {
                Data = mapper.Map<StudentDto>(student)
            };
        }
    }
}
