using AutoMapper;
using Platform.Core.Entities;
using Platform.Core.Requests.Program;

namespace Platform.Core.MapperProfiles
{
    public class ProgramProfile : Profile
    {
        public ProgramProfile()
        {
            CreateMap<Program, ProgramDto>();
        }
    }
}
