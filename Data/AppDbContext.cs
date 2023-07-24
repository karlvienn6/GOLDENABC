using Microsoft.EntityFrameworkCore;
using Goldenabc.Models;
using mysqlefcore;

namespace Goldenabc.Controllers
{
    public class AppDbContext : DbContext
    {

        private readonly string connectionString = "Server=localhost;Database=Golden;user ID=root;Password=karlrak321";

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Branch>? Branch { get; set; }
        public DbSet<Employee>? Employee {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Branch>(entity=>{
                entity.HasKey(e => e.branchCode);
                entity.Property(e => e.branchName).IsRequired();
                entity.Property(e => e.branchManager).IsRequired();
                entity.Property(e => e.dateOpened).IsRequired();
                entity.Property(e => e.barangay).IsRequired();
                entity.Property(e => e.address).IsRequired();
                entity.Property(e => e.city).IsRequired();
                entity.Property(e => e.permitNo).IsRequired();
                entity.Property(e => e.isActive).IsRequired();
            });

            // modelBuilder.Entity<Employee>().HasNoKey();

            modelBuilder.Entity<Employee>(entity => {
                entity.HasKey(e=>e.employeeId);
               entity.Property(e => e.firstName).IsRequired();
               entity.Property(e => e.lastName).IsRequired(); 
               entity.Property(e => e.middleName).IsRequired();
               entity.Property(e => e.dateHired).IsRequired();
            });
        }
    }
}