using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Platform.Core.Entities;

namespace Platform.Database.Configurations
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasData(
                new Item
                {
                    Id = 1,
                    Name = "React - The Complete Guide",
                    Type = ItemType.Lecture,
                    Description = "Dive in and learn React.js from scratch! Learn Reactjs, Hooks, Redux, React Routing, Animations, Next.js and way more!",
                    WorkHours = 40,
                    Urls = "https://reactjs.org/"
                },
                  new Item
                  {
                      Id = 2,
                      Name = ".Net Core API",
                      Type = ItemType.Lecture,
                      Description = "Build the back-end of a .NET 6 web application with Web API, Entity Framework Core & SQL Server in no time!",
                      WorkHours = 20,
                      Urls = "https://dotnet.microsoft.com/en-us/"
                  },
                   new Item
                   {
                       Id = 3,
                       Name = "Git - Crash Course",
                       Type = ItemType.Lecture,
                       Description = "Learn how to start building, shipping, and maintaining software with GitHub.",
                       Urls = "https://docs.github.com/en"
                   },
                    new Item
                    {
                        Id = 4,
                        Name = ".Net Core & React Test Project - Task",
                        Type = ItemType.Event,
                        Description = "Send completed assignment to mentor",
                        Urls = null
                    }
                );
        }
    }
}
