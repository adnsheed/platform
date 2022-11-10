using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Platform.Core.Requests.Admin;

namespace Platform.Database.Configurations
{
    public class OverallSuccessConfiguration : IEntityTypeConfiguration<OverallSuccess>
    {
        public void Configure(EntityTypeBuilder<OverallSuccess> builder)
        {
            builder
                .ToTable("OverallSuccess", t => t.ExcludeFromMigrations())
                .HasNoKey();
        }
    }
}
