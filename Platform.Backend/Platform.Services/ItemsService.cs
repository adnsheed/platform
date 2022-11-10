

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Platform.Common;
using Platform.Core.Entities;
using Platform.Core.Interfaces;
using Platform.Core.Requests.Item;
using Platform.Core.Requests.ItemProgram;
using Platform.Core.Requests.Program;
using Platform.Core.Requests.Selection;
using Platform.Core.Requests.Student;
using Platform.Database;
using System.Linq.Dynamic.Core;

namespace Platform.Services
{
    public class ItemsService : IItemsService
    {
        private readonly IMapper mapper;
        private readonly PlatformDbContext context;

        public ItemsService(IMapper mapper, PlatformDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public async Task<ServiceResponse<List<ItemDto>>> GetAll(RequestParameters itemParameters)
        {
            var items = context.Items.AsQueryable();

            if (!string.IsNullOrWhiteSpace(itemParameters.Filter) && !string.IsNullOrWhiteSpace(itemParameters.Value))
            {
                //if (itemParameters.Filter == "name")
                //{
                //    items = items.Where(s => s.Name.ToUpper().Contains(itemParameters.Value.Trim().ToUpper()));
                //}
                //if (itemParameters.Filter == "description")
                //{
                //    items = items.Where(s => s.Description.ToUpper().Contains(itemParameters.Value.Trim().ToUpper()));
                //}
                
                
                    items = items.Where(itemParameters.Filter + $"= \"{itemParameters.Value}\"");
                
            };


            if (!string.IsNullOrWhiteSpace(itemParameters.Sort))
            {
                if (itemParameters.Sort == "name")
                {
                    items = items.OrderBy("name");
                }
                else if (itemParameters.Sort == "name desc")
                {
                    items = items.OrderBy("name desc");
                }
                else
                {
                    items = items.OrderBy(itemParameters.Sort);
                }
            }
            var count = items.Count();
            var pages = (int)Math.Ceiling((double)items.Count() / itemParameters.PageSize);
            items = items
            .Page(itemParameters.Page, itemParameters.PageSize);
               


            var response = new ServiceResponse<List<ItemDto>>
            {
                Data = await items.Select(s => mapper.Map<ItemDto>(s)).ToListAsync(),
                Pages = pages,
                Count = count
            };
            return response;
        }

        public async Task<ServiceResponse<ItemDto>> Create(CreateItemDto newItem)
        {

            var item = mapper.Map<Item>(newItem);

            context.Items.Add(item);
            await context.SaveChangesAsync();

            return new ServiceResponse<ItemDto>()
            {
                Data = mapper.Map<ItemDto>(item),
                Message = "Successfully added item."
            };



        }

        public async Task<ServiceResponse<ItemDto>> Delete(int id)
        {
            var item = await context.Items
                .FirstOrDefaultAsync(s => s.Id == id);

            if (item == null)
            {
                throw new KeyNotFoundException("Item not found");
            }

            context.Items.Remove(item);
            await context.SaveChangesAsync();

            return new ServiceResponse<ItemDto>()
            {
                Data = mapper.Map<ItemDto>(item),
                Message = "Successfully deleted item."
            };

        }

        public async Task<ServiceResponse<ItemDto>> Update(int id, UpdateItemDto updatedItem)
        {
            var item = await context.Items
               .FirstOrDefaultAsync(s => s.Id == id);

            if (item == null)
            {
                throw new KeyNotFoundException("Item not found");
            }

            item.Name = updatedItem.Name;
            item.Description = updatedItem.Description;
            item.Type = updatedItem.Type;
            item.WorkHours = updatedItem.WorkHours;
            item.Urls = updatedItem.Urls;

            await context.SaveChangesAsync();


            return new ServiceResponse<ItemDto>()
            {
                Data = mapper.Map<ItemDto>(item),
                Message = "Successfully updated item."
            };

        }

        public async Task<ServiceResponse<ItemDto>> GetById(int id)
        {
            var item = await context.Items
                .FirstOrDefaultAsync(s => s.Id == id);

            if (item == null)
            {
                throw new KeyNotFoundException("Item not found");
            }

            return new ServiceResponse<ItemDto>()
            {
                Data = mapper.Map<ItemDto>(item)
            };
        }

        //public async Task<bool> AddItemToProgram(AddItemProgramDto addItemProgram)
        //{
        //    var itemProgram = mapper.Map<ItemProgram>(addItemProgram);

        //    context.ItemPrograms.Add(itemProgram);
        //    await context.SaveChangesAsync();

        //    return true;
        //}





    }
}
