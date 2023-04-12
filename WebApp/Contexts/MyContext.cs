using Microsoft.EntityFrameworkCore;
using WebApp.Models;
using WebApp.ViewModels;

namespace WebApp.Contexts
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }

        // Mendaftarkan Model ke Dalam Context/ Database
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountRole> AccountRoles { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Profiling> Profilings { get; set; }
        public DbSet<Role> Roles { get; set; }  
        public DbSet<University> Universities { get; set; }



        // Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relasi antara satu University dengan banyak Education
            modelBuilder.Entity<University>()
                        .HasMany(u => u.Educations)
                        .WithOne(e => e.Universities)
                        .HasForeignKey(u => u.UniversityID)
                        .OnDelete(DeleteBehavior.NoAction);

            // Relasi antara satu Profiling dan satu Education
            modelBuilder.Entity<Profiling>()
                        .HasOne(p => p.Educations)
                        .WithOne(e => e.Profilings)
                        .HasForeignKey<Profiling>(p => p.EducationID)
                        .OnDelete(DeleteBehavior.NoAction);

            // Relasi anta Satu Employee dan satu Profiling
            modelBuilder.Entity<Employee>()
                        .HasOne(e => e.Profilings)
                        .WithOne(p => p.Employees)
                        .HasForeignKey<Profiling>(p => p.EmployeeNIK)
                        .OnDelete(DeleteBehavior.NoAction);

            // Relasi antara satu Employee dan satu Account
            modelBuilder.Entity<Employee>()
                        .HasOne(e => e.Accounts)
                        .WithOne(a => a.Employees)
                        .HasForeignKey<Account>(a => a.EmployeeNIK)
                        .OnDelete(DeleteBehavior.NoAction);

            // Relasi antara satu Account dan banyak AcoountRole
            modelBuilder.Entity<Account>()
                        .HasMany(a => a.AccountRoles)
                        .WithOne(ar => ar.Accounts)
                        .HasForeignKey(a => a.AccountNIK)
                        .OnDelete(DeleteBehavior.NoAction);

            // Relasi antara saru Role dan banyak AccountRole
            modelBuilder.Entity<Role>()
                        .HasMany(r => r.AccountRoles)
                        .WithOne(ar => ar.Roles)
                        .HasForeignKey(r => r.RoleID)
                        .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<RegisterVM>()
                        .HasNoKey();

            modelBuilder.Entity<LoginVM>()
                        .HasNoKey();
        }



        // Fluent API
        public DbSet<WebApp.ViewModels.RegisterVM>? RegisterVM { get; set; }



        // Fluent API
        public DbSet<WebApp.ViewModels.LoginVM>? LoginVM { get; set; }
    }
}
