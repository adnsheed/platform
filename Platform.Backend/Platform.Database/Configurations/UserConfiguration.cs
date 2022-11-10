using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Platform.Core.Entities;

namespace Platform.Database.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(u => u.UserRoles)
                .WithOne(u => u.User)
                .HasForeignKey(u => u.UserId)
                .IsRequired();

            var hash = new PasswordHasher<User>();

            builder.HasData(
                new User
                {
                    Id = 1,
                    UserName = "admin",
                    PasswordHash = hash.HashPassword(null, "admin"),
                    FirstName = "Johnny",
                    LastName = "Cash"
                });
        }
    }
}
