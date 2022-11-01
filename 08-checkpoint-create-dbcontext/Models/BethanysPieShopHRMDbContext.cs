using Microsoft.EntityFrameworkCore;

namespace BethanysPieShopHRM.Models
{
    public class BethanysPieShopHRMDbContext : DbContext
    {
        public BethanysPieShopHRMDbContext(DbContextOptions<BethanysPieShopHRMDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Category> Categories { get; set; }

    }

}
