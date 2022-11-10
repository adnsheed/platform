using AutoMapper;
using Platform.Core.Entities;
using Platform.Core.Requests.Users;

namespace Platform.Core.MapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}
