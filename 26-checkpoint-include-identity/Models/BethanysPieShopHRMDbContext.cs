using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace BethanysPieShopHRM.Models
{
    public class BethanysPieShopHRMDbContext : DbContext
    {
        public BethanysPieShopHRMDbContext(DbContextOptions<BethanysPieShopHRMDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Category> Categories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 1, CategoryName = "Management" });

            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 2, CategoryName = "Store staff" });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 1,
                BirthDate = new DateTime(1979, 1, 16),
                City = "Brussels",
                Email = "bethany@bethanyspieshop.com",
                FirstName = "Bethany",
                LastName = "Smith",
                PhoneNumber = "324777888773",
                Street = "Grote Markt 1",
                Zip = "1000",
                Comment = "Lorem Ipsum",
                CategoryId = 1
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 2,
                BirthDate = new DateTime(1980, 1, 16),
                City = "Antwerp",
                Email = "gill@bethanyspieshop.com",
                FirstName = "Gill",
                LastName = "Cleeren",
                PhoneNumber = "324448546648",
                Street = "Grote Markt 3",
                Zip = "1000",
                Comment = "Lorem Ipsum",
                CategoryId = 2

            });
        }
    }

}
