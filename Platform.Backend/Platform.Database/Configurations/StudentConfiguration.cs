using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Platform.Core.Entities;

namespace Platform.Database.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder
                .HasOne(s => s.Selection)
                .WithMany(s => s.Students)
                .HasForeignKey(s => s.SelectionId);

            builder
               .HasMany(s => s.Comments)
               .WithOne(c => c.Student) 
               .HasForeignKey(s => s.StudentId);

            builder
               .HasMany(s => s.ItemPrograms)
               .WithMany(s => s.Students)
               .UsingEntity<ItemStudent>(
                   j => j
                       .HasOne(ips => ips.ItemProgram)
                       .WithMany(ip => ip.ItemStudents)
                       .HasForeignKey(ips => ips.ItemProgramId)
                       .OnDelete(DeleteBehavior.ClientNoAction),
                   j => j
                       .HasOne(ips => ips.Student)
                       .WithMany(s => s.ItemStudents)
                       .HasForeignKey(ips => ips.StudentId),
                   j =>
                   {
                       j.Property(ips => ips.Progress).HasDefaultValue(0);
                       j.Property(ips => ips.ProgressStatus).HasDefaultValue("Not Started");
                       j.HasKey(ip => new { ip.ItemProgramId, ip.StudentId });
                   }
               );

            var hash = new PasswordHasher<User>();

            builder.HasData(
                new Student
                {
                    Id = 2,
                    UserName = "sheed",
                    PasswordHash = hash.HashPassword(null, "Sheed1!"),
                    FirstName = "Rasheed",
                    LastName = "Wallace",
                    BirthDate = new DateTime(1974, 9, 17),
                    Status = StudentStatus.Success,
                    SelectionId = Guid.Parse("4c2b95e0-2022-4a8f-b537-eb3a32786b06")
                },
                 new Student
                 {
                     Id = 3,
                     UserName = "answer",
                     PasswordHash = hash.HashPassword(null, "Answer1!"),
                     FirstName = "Allen",
                     LastName = "Iverson",
                     BirthDate = new DateTime(1976, 3, 12),
                     Status = StudentStatus.Failed,
                     SelectionId = Guid.Parse("a1066e97-c7c8-4aee-905b-61bb31d82bfb")
                 },
                   new Student
                   {
                       Id = 4,
                       UserName = "vinsanity",
                       PasswordHash = hash.HashPassword(null, "Canada1!"),
                       FirstName = "Vince",
                       LastName = "Carter",
                       BirthDate = new DateTime(1975, 5, 6),
                       Status = StudentStatus.Success,
                       SelectionId = Guid.Parse("a1066e97-c7c8-4aee-905b-61bb31d82bfb")
                   },
                    new Student
                    {
                        Id = 5,
                        UserName = "glove",
                        PasswordHash = hash.HashPassword(null, "Glove1!"),
                        FirstName = "Gary",
                        LastName = "Payton",
                        BirthDate = new DateTime(1978, 5, 6),
                        Status = StudentStatus.InProgram,
                        SelectionId = Guid.Parse("30f96ef9-7b45-42f7-9fab-05a70e7fc394")
                    },
                     new Student
                     {
                         Id = 6,
                         UserName = "zgembo",
                         PasswordHash = hash.HashPassword(null, "Zgembo1!"),
                         FirstName = "Zgembo",
                         LastName = "Adislic",
                         BirthDate = new DateTime(1968, 5, 6),
                         Status = StudentStatus.Extended,
                         SelectionId = null
                     }
                );
        }
    }
}
