using AutoMapper;
using Platform.Core.Entities;
using Platform.Core.Requests.Users;

namespace Platform.Core.MapperProfiles
{
    public class UserRoleProfile : Profile
    {
        public UserRoleProfile()
        {
            CreateMap<UserRole, UserRoleDto>();
        }
    }
}
