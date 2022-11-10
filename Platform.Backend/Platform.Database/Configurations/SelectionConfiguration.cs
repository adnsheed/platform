using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Platform.Core.Entities;

namespace Platform.Database.Configurations
{
    public class SelectionConfiguration : IEntityTypeConfiguration<Selection>
    {
        public void Configure(EntityTypeBuilder<Selection> builder)
        {
            builder.HasData(
                new Selection
                {
                   Id = Guid.Parse("4c2b95e0-2022-4a8f-b537-eb3a32786b06"),
                   Title = "Selection Curabitur",
                   StartDate = new DateTime(2022, 6, 15),
                   EndDate = new DateTime(2022, 9, 15),
                   Status = SelectionStatus.Complete,
                   ProgramId = Guid.Parse("b950ddf5-e9ad-47ff-9d2a-57259014fae6")
                },
                new Selection
                {
                    Id = Guid.Parse("a1066e97-c7c8-4aee-905b-61bb31d82bfb"),
                    Title = "Selection Aenean",
                    StartDate = new DateTime(2022, 8, 15),
                    EndDate = new DateTime(2022, 11, 15),
                    Status = SelectionStatus.Active,
                    ProgramId = Guid.Parse("907f54ba-2142-4719-aef9-6230c23bd7de")
                },
                   new Selection
                   {
                       Id = Guid.Parse("30f96ef9-7b45-42f7-9fab-05a70e7fc394"),
                       Title = "Selection Donec",
                       StartDate = new DateTime(2022, 12, 15),
                       EndDate = new DateTime(2023, 3, 15),
                       Status = SelectionStatus.Active,
                       ProgramId = Guid.Parse("79e9872d-5a2f-413e-ac36-511036ccd3d4")
                   }
                );
        }
    }
}
