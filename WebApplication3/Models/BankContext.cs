using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace WebApplication3.Models
{
    public class BankContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankBranch>().HasData(
                new BankBranch
                {
                    Id = 1,
                    LocationName = "Alshamyia",
                    BranchManager = "Abdulrahman",
                    EmployeeCount = 7,
                    LocationURL = "https://maps.app.goo.gl/k5DD4wvKX38Y6RFQ7"
                }
            );
        }

        public DbSet<BankBranch> BankBranches { get; set; }
        public DbSet<Employee> Employees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlite("Data Source=blog.db");

        }
    }
}
