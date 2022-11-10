using AutoMapper;
using Platform.Core.Entities;
using Platform.Core.Requests.Selection;

namespace Platform.Core.MapperProfiles
{
    public class SelectionProfile : Profile
    {
        public SelectionProfile()
        {
            CreateMap<Selection, SelectionDto>();    
            CreateMap<CreateSelectionDto, Selection>();
        }
    }
}
