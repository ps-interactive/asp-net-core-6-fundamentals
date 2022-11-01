using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace BethanysPieShopHRM.Models
{
    public class BethanysPieShopHRMDbContext : DbContext
    {
        public BethanysPieShopHRMDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Country> Countries { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 1, CountryName = "USA" });

            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 2, CountryName = "Belgium" });

            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 3, CountryName = "France" });

            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 4, CountryName = "Germany" });

            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 5, CountryName = "UK" });
            
        }
    }
}
