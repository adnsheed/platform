using Platform.Core.Requests.Role;

namespace Platform.Core.Requests.Users
{
    public class UserRoleDto
    {
        public UserDto User { get; set; }
        public RoleDto Role { get; set; }
    }
}
