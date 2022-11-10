using Microsoft.AspNetCore.Identity;

namespace Platform.Core.Entities
{
    public class User : IdentityUser<int>
    {
        
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}