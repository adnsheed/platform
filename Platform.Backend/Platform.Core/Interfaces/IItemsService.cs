using Platform.Common;
using Platform.Core.Entities;
using Platform.Core.Requests.Item;
using Platform.Core.Requests.ItemProgram;

namespace Platform.Core.Interfaces
{
    public interface IItemsService
    {
        Task<ServiceResponse<List<ItemDto>>> GetAll(RequestParameters itemParameters);

        Task<ServiceResponse<ItemDto>> GetById(int id);

        Task<ServiceResponse<ItemDto>> Create(CreateItemDto newItem);

        Task<ServiceResponse<ItemDto>> Delete(int id);

        Task<ServiceResponse<ItemDto>> Update(int id, UpdateItemDto updatedItem);

    }
}
