using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Platform.Core.Entities;

namespace Platform.Database.Configurations
{
    internal class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasData(
                new UserRole { RoleId = 1, UserId = 1 },
                new UserRole { RoleId = 2, UserId = 2 },
                new UserRole { RoleId = 2, UserId = 3 },
                new UserRole { RoleId = 2, UserId = 4 },
                new UserRole { RoleId = 2, UserId = 5 }
                );
        }
    }
}
