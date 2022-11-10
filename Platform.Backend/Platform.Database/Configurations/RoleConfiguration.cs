using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Platform.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Database.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasMany(u => u.UserRoles)
                .WithOne(u => u.Role)
                .HasForeignKey(u => u.RoleId)
                .IsRequired();

            builder.HasData(
                new Role { Id = 1, Name = "Admin", NormalizedName = "ADMIN".ToUpper() },
                new Role { Id = 2, Name = "Student", NormalizedName = "STUDENT".ToUpper() }
                );
        }
    }
}
