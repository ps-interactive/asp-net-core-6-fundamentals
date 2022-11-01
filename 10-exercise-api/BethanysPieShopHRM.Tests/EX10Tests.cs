using BethanysPieShopHRM.Controllers.Api;
using BethanysPieShopHRM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShopHRM.Tests
{
    public class EX10Tests
    {
        [Fact]
        public void EX10_VerifyAPIMethod()
        {
            var options = new DbContextOptionsBuilder<BethanysPieShopHRMDbContext>()
                .UseInMemoryDatabase(databaseName: "BethanysPieShopHRM")
                .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new BethanysPieShopHRMDbContext(options))
            {
                context.Countries.Add(new Country
                {
                    CountryId = 1,
                    CountryName = "Belgium"
                });
                context.Countries.Add(new Country
                {
                    CountryId = 2,
                    CountryName = "France"
                });
                context.Countries.Add(new Country
                {
                    CountryId = 3,
                    CountryName = "Germany"
                });
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new BethanysPieShopHRMDbContext(options))
            {
                CountryRepository countryRepository = new CountryRepository(context);
                var controller = new SearchController(countryRepository);

                var countries = controller.SearchCountries("r");
                Assert.IsType<JsonResult>(countries);
                Assert.Equal(2, ((countries as JsonResult).Value as IEnumerable<Country>).ToList().Count);
            }

            // Use a clean instance of the context to run the test
            using (var context = new BethanysPieShopHRMDbContext(options))
            {
                CountryRepository countryRepository = new CountryRepository(context);
                var controller = new SearchController(countryRepository);

                var countries = controller.SearchCountries(null);
                Assert.IsType<BadRequestResult>(countries);
            }

            // Use a clean instance of the context to run the test
            using (var context = new BethanysPieShopHRMDbContext(options))
            {
                CountryRepository countryRepository = new CountryRepository(context);
                var controller = new SearchController(countryRepository);

                var countries = controller.SearchCountries(String.Empty);
                Assert.IsType<BadRequestResult>(countries);
            }
        }
    }
}