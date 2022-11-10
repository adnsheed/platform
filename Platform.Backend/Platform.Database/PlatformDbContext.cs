using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Platform.Core.Entities;
using Platform.Core.Requests.Admin;
using Platform.Database.Configurations;

namespace Platform.Database
{
    public class PlatformDbContext : IdentityDbContext
        <User, Role, int,
        IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public PlatformDbContext(DbContextOptions<PlatformDbContext> options) : base(options)   
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new ProgramConfiguration());
            modelBuilder.ApplyConfiguration(new SelectionConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new OverallSuccessConfiguration());
            modelBuilder.ApplyConfiguration(new SelectionSuccessConfiguration());
            modelBuilder.ApplyConfiguration(new ItemConfiguration());
            modelBuilder.ApplyConfiguration(new ItemProgramConfiguration());

        }

        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Program> Programs { get; set; } = null!;
        public DbSet<Selection> Selections { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;
        public DbSet<OverallSuccess> OverallSuccesses { get; set; } = null!;
        public DbSet<SelectionSuccess> SelectionSuccesses { get; set; } = null!;
        public DbSet<Item> Items { get; set; } = null!;
        public DbSet<ItemProgram> ItemPrograms { get; set; } = null!;
        public DbSet<ItemStudent> ItemStudents { get; set; } = null!;

    }
}
