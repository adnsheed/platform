using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Platform.Core.Entities;
using Platform.Core.Interfaces;
using Platform.Core.Requests.Item;
using Platform.Core.Requests.ItemProgram;
using Platform.Core.Requests.Program;
using Platform.Core.Requests.Selection;
using Platform.Database;

namespace Platform.Services
{
    public class ProgramsService : IProgramsService
    {
        private readonly IMapper mapper;
        private readonly PlatformDbContext context;

        public ProgramsService(IMapper mapper, PlatformDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }
        public async Task<ServiceResponse<List<ProgramDto>>> GetAll()
        {
            
            return new ServiceResponse<List<ProgramDto>>()
            {
                Data = await context.Programs
                .Include(p => p.ItemPrograms.OrderBy(p => p.OrderNumber))
                    .ThenInclude(ip => ip.Item)
                .Select(s => mapper.Map<ProgramDto>(s)).ToListAsync()
            };
        }

        public async Task<ServiceResponse<ProgramDto>> AddItem(AddItemProgramDto addItemProgram)
        {
            var itemProgram = mapper.Map<ItemProgram>(addItemProgram);

            // Razmisliti za ovo
            
            //if(await context.Items.FindAsync(addItemProgram.ItemId) == null)
            //{
            //    throw new KeyNotFoundException("Item not found");
            //}

            context.ItemPrograms.Add(itemProgram);
            await context.SaveChangesAsync();

            var progId = addItemProgram.ProgramId;

            var program = await context.Programs.FindAsync(progId);

            return new ServiceResponse<ProgramDto>()
            {
                Data = mapper.Map<ProgramDto>(program),
                Message = "Successfully added item to program."
            };



        }

        public async Task<ServiceResponse<ProgramDto>> DeleteItem(Guid programId, int itemId)
        {
            var program = await context.Programs.FindAsync(programId);

            var itemProgram = context.ItemPrograms.FirstOrDefault(ip => ip.ItemId == itemId && ip.ProgramId == programId);

            //if (itemProgram == null)
            //{
            //    if (itemProgram == null)
            //    {
            //        throw new KeyNotFoundException("Item not found");
            //    }
            //}

            context.ItemPrograms.Remove(itemProgram);

            await context.SaveChangesAsync();


            return new ServiceResponse<ProgramDto>()
            {
                Data = mapper.Map<ProgramDto>(program),
                Message = "Successfully deleted item from program."
            };
        }

        public async Task<ServiceResponse<ProgramDto>> ChangeItemOrder(Guid programId, int itemId, int orderNumber)
        {
            var program = await context.Programs.FindAsync(programId);

            var itemProgram = context.ItemPrograms.FirstOrDefault(ip => ip.ItemId == itemId && ip.ProgramId == programId);

            itemProgram.OrderNumber = orderNumber;

            await context.SaveChangesAsync();

            return new ServiceResponse<ProgramDto>()
            {
                Data = mapper.Map<ProgramDto>(program),
                Message = "Successfully changed item order number."
            };


        }

        public async Task<ServiceResponse<ProgramDto>> GetById(Guid id)
        {
            var program = await context.Programs
            .Include(p => p.ItemPrograms
            .OrderBy(p => p.OrderNumber))
            .ThenInclude(ip => ip.Item)
            .Include(p => p.ItemPrograms)
            .FirstOrDefaultAsync(s => s.Id == id);

            if (program == null)
            {
                throw new KeyNotFoundException("Program not found");
            }

            return new ServiceResponse<ProgramDto>()
            {
                Data = mapper.Map<ProgramDto>(program)
            };
        }
    }
}
