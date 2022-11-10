

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Platform.Core.Entities;
using Platform.Core.Requests.Admin;

namespace Platform.Database.Configurations
{
    public class SelectionSuccessConfiguration : IEntityTypeConfiguration<SelectionSuccess>
    {
        public void Configure(EntityTypeBuilder<SelectionSuccess> builder)
        {
            builder
            .ToTable("SelectionSuccess", t => t.ExcludeFromMigrations())
            .HasNoKey();

        }
    }
}
