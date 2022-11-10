using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Platform.Core.Entities;

namespace Platform.Database.Configurations
{
    public class ItemProgramConfiguration : IEntityTypeConfiguration<ItemProgram>
    {
        public void Configure(EntityTypeBuilder<ItemProgram> builder)
        {
            builder.HasData(

                new ItemProgram
                {
                    Id = 1,
                    ItemId = 1,
                    ProgramId = Guid.Parse("79e9872d-5a2f-413e-ac36-511036ccd3d4"),
                    OrderNumber = 1,
                    
                },
                 new ItemProgram
                 {
                     Id = 2,
                     ItemId = 2,
                     ProgramId = Guid.Parse("79e9872d-5a2f-413e-ac36-511036ccd3d4"),
                     OrderNumber = 2
                 }, 
                 new ItemProgram
                 {
                     Id = 3,
                     ItemId = 3,
                     ProgramId = Guid.Parse("79e9872d-5a2f-413e-ac36-511036ccd3d4"),
                     OrderNumber= 3
                 },
                 new ItemProgram
                 {
                     Id = 4,
                     ItemId = 4,
                     ProgramId = Guid.Parse("79e9872d-5a2f-413e-ac36-511036ccd3d4"),
                     OrderNumber = 4
                 }
                );
        }
    }
}
