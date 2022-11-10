using AutoMapper;
using Platform.Core.Entities;
using Platform.Core.Requests.ItemStudent;

namespace Platform.Core.MapperProfiles
{
    public class ItemStudentProfile : Profile
    {
        public ItemStudentProfile()
        {
            CreateMap<ItemStudent, ItemStudentDto>()
                .ForMember(dest => dest.OrderNumber, opt => opt.MapFrom(src => src.ItemProgram.OrderNumber))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ItemProgram.Item.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.ItemProgram.Item.Description))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.ItemProgram.Item.Type))
                .ForMember(dest => dest.WorkHours, opt => opt.MapFrom(src => src.ItemProgram.Item.WorkHours))
                .ForMember(dest => dest.Urls, opt => opt.MapFrom(src => src.ItemProgram.Item.Urls))
                .ReverseMap();
        }
    }
}
