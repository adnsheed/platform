using AutoMapper;
using Platform.Core.Entities;
using Platform.Core.Requests.Item;
using Platform.Core.Requests.ItemProgram;

namespace Platform.Core.MapperProfiles
{
    public class ItemProgramProfile : Profile
    {
        public ItemProgramProfile()
        {
            CreateMap<ItemProgram, ItemProgramDto>().ReverseMap();
            CreateMap<AddItemProgramDto, ItemProgram > ().ReverseMap();
        }
    }
}
