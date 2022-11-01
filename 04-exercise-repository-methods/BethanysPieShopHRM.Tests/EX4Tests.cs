using BethanysPieShopHRM.Models;
using HtmlAgilityPack;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using BethanysPieShopHRM.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace BethanysPieShopHRM.Tests
{
    public class EX4Tests
    {
        [Fact]
        public void EX4_VerifyCountryRepository()
        {
            var filePath = TestHelpers.GetRootString() + "BethanysPieShopHRM"
                                                       + Path.DirectorySeparatorChar + "Models"
                                                       + Path.DirectorySeparatorChar + "CountryRepository.cs";

            Assert.True(File.Exists(filePath), "`CountryRepository.cs` should exist in the Models folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            Assert.Contains("private readonly BethanysPieShopHRMDbContext", doc.Text);

            var options = new DbContextOptionsBuilder<BethanysPieShopHRMDbContext>()
                .UseInMemoryDatabase(databaseName: "BethanysPieShopHRM")
            .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new BethanysPieShopHRMDbContext(options))
            {
                var countries = context.Countries;
                context.Countries.RemoveRange(countries);

                context.Countries.Add(new Country
                {
                    CountryId = 1,
                    CountryName = "Belgium"
                });

                context.Countries.Add(new Country
                {
                    CountryId = 2,
                    CountryName = "USA"
                });

                context.Countries.Add(new Country
                {
                    CountryId = 3,
                    CountryName = "France"
                });

                context.Countries.Add(new Country
                {
                    CountryId = 4,
                    CountryName = "Germany"
                });

                context.Countries.Add(new Country
                {
                    CountryId = 5,
                    CountryName = "UK"
                });
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new BethanysPieShopHRMDbContext(options))
            {
                CountryRepository countryRepository = new CountryRepository(context);

                var countries = countryRepository.AllCountries.ToList();
                Assert.Equal(5, countries.Count);
                Assert.Equal(1, countries[0].CountryId);
                Assert.Equal(2, countries[1].CountryId);
                Assert.Equal(3, countries[2].CountryId);
                Assert.Equal(4, countries[3].CountryId);
                Assert.Equal(5, countries[4].CountryId);
            }

            // Use a clean instance of the context to run the test
            using (var context = new BethanysPieShopHRMDbContext(options))
            {
                CountryRepository countryRepository = new CountryRepository(context);

                var country = countryRepository.GetCountryById(1);
                Assert.NotNull(country);
                Assert.Equal("Belgium", country.CountryName);

                var country1 = countryRepository.GetCountryById(8);
                Assert.Null(country1);
            }
        }

        [Fact]
        public void EX4_VerifyCountryController()
        {
            var filePath = TestHelpers.GetRootString() + "BethanysPieShopHRM"
                                                       + Path.DirectorySeparatorChar + "Controllers"
                                                       + Path.DirectorySeparatorChar + "CountryController.cs";

            Assert.True(File.Exists(filePath), "`CountryController.cs` should exist in the Controllers folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            Assert.Contains("private readonly ICountryRepository", doc.Text);

            var options = new DbContextOptionsBuilder<BethanysPieShopHRMDbContext>()
                .UseInMemoryDatabase(databaseName: "BethanysPieShopHRM")
            .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new BethanysPieShopHRMDbContext(options))
            {
                var countries = context.Countries;
                context.Countries.RemoveRange(countries);

                context.Countries.Add(new Country
                {
                    CountryId = 1,
                    CountryName = "Belgium"
                });

                context.Countries.Add(new Country
                {
                    CountryId = 2,
                    CountryName = "USA"
                });

                context.Countries.Add(new Country
                {
                    CountryId = 3,
                    CountryName = "France"
                });

                context.Countries.Add(new Country
                {
                    CountryId = 4,
                    CountryName = "Germany"
                });

                context.Countries.Add(new Country
                {
                    CountryId = 5,
                    CountryName = "UK"
                });
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new BethanysPieShopHRMDbContext(options))
            {
                CountryRepository countryRepository = new CountryRepository(context);
                var controller = new CountryController(countryRepository);

                var countriesIActionResult = controller.Index();
                var countriesViewResult = countriesIActionResult as ViewResult;
                Assert.Equal(5, ((countriesViewResult!.Model as IEnumerable<Country>)!.ToList()).Count);
                var countries = ((countriesViewResult!.Model as IEnumerable<Country>)!).ToList();

                Assert.Equal(1, countries![0].CountryId);
                Assert.Equal(2, countries![1].CountryId);
                Assert.Equal(3, countries![2].CountryId);
                Assert.Equal(4, countries![3].CountryId);
                Assert.Equal(5, countries![4].CountryId);
            }
        }
    }
}