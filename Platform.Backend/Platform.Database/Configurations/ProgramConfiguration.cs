using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Platform.Core.Entities;


namespace Platform.Database.Configurations
{
    public class ProgramConfiguration : IEntityTypeConfiguration<Program>
    {
        public void Configure(EntityTypeBuilder<Program> builder)
        {
            builder
                .HasMany(p => p.Selections)
                .WithOne(s => s.Program)
                .HasForeignKey(s => s.ProgramId);

            builder
                .HasMany(p => p.Items)
                .WithMany(p => p.Programs)
                .UsingEntity<ItemProgram>(
                    j => j
                        .HasOne(ip => ip.Item)
                        .WithMany(i => i.ItemPrograms)
                        .HasForeignKey(ip => ip.ItemId),
                    j => j
                        .HasOne(ip => ip.Program)
                        .WithMany(p => p.ItemPrograms)
                        .HasForeignKey(ip => ip.ProgramId),
                    j =>
                    {
                        j.Property(ip => ip.OrderNumber).HasDefaultValue(0);
                        j.HasIndex(ip => new { ip.ItemId, ip.ProgramId }).IsUnique();
                    });

            builder.HasData(
                new Program
                {
                    Id = Guid.Parse("b950ddf5-e9ad-47ff-9d2a-57259014fae6"),
                    Title = "Curabitur",
                    Description = "Curabitur bibendum, ipsum non pulvinar finibus, elit magna hendrerit velit."
                },
                 new Program
                 {
                     Id = Guid.Parse("907f54ba-2142-4719-aef9-6230c23bd7de"),
                     Title = "Aenean",
                     Description = "Aenean faucibus sit amet metus pellentesque ultrices. Aenean vestibulum suscipit."
                 },
                 new Program
                 {
                     Id = Guid.Parse("79e9872d-5a2f-413e-ac36-511036ccd3d4"),
                     Title = "Donec",
                     Description = "Donec sit amet sollicitudin nunc. Phasellus varius nisi sapien, in."
                 });
        }
    }
}
