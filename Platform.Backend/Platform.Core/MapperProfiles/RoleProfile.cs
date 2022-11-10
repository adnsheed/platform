using AutoMapper;
using Platform.Core.Entities;
using Platform.Core.Requests.Role;

namespace Platform.Core.MapperProfiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleDto>();
        }
    }
}
