using AutoMapper;
using Platform.Core.Entities;
using Platform.Core.Requests.Item;

namespace Platform.Core.MapperProfiles
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<Item, ItemDto>().ReverseMap();
            CreateMap<CreateItemDto, Item>().ReverseMap();
            CreateMap<UpdateItemDto, Item>().ReverseMap();
        }
    }
}