using Microsoft.AspNetCore.Identity;

namespace Platform.Core.Entities
{
    public class Role : IdentityRole<int>
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
