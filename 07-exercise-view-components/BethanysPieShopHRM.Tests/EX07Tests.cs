using BethanysPieShopHRM.Components;
using BethanysPieShopHRM.Controllers;
using BethanysPieShopHRM.Models;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShopHRM.Tests
{
    public class EX07Tests
    {
        [Fact]
        [Trait("Category", "Task1")]
        public void EX07_VerifyViewComponent()
        {
            var filePath = TestHelpers.GetRootString() + "BethanysPieShopHRM"
                                                       + Path.DirectorySeparatorChar + "Components"
                                                       + Path.DirectorySeparatorChar + "CountryCounterViewComponent.cs";

            Assert.True(File.Exists(filePath), "`CountryCounterViewComponent.cs` should exist in the `Components` folder.");

            var baseName = typeof(CountryCounterViewComponent).BaseType!.Name;
            Assert.True(baseName != null && baseName.Contains("ViewComponent"));

            var doc = new HtmlDocument();
            doc.Load(filePath);

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
                var counterViewComponent = new CountryCounterViewComponent(countryRepository);

                Assert.NotNull(counterViewComponent);

                var methods = typeof(CountryCounterViewComponent).GetMethods();
                var invoke = methods.FirstOrDefault(x => x.Name == "Invoke");
                var invokeAsync = methods.FirstOrDefault(x => x.Name == "InvokeAsync");

                Assert.True(
                    doc.Text.Contains("AllCountries.Count()") &&
                    (invoke != null || invokeAsync != null)
                    && invoke.ReturnType == typeof(IViewComponentResult) || invokeAsync.ReturnType == typeof(IViewComponentResult));
            }
        }

        [Fact]
        [Trait("Category", "Task2")]
        public void EX07_VerifyViewComponentView()
        {
            var filePath = TestHelpers.GetRootString() + "BethanysPieShopHRM"
                                                       + Path.DirectorySeparatorChar + "Views"
                                                       + Path.DirectorySeparatorChar + "Shared"
                                                       + Path.DirectorySeparatorChar + "Components"
                                                       + Path.DirectorySeparatorChar + "CountryCounter"
                                                       + Path.DirectorySeparatorChar + "Default.cshtml";

            Assert.True(File.Exists(filePath), "`Default.cshtml` should exist in the `Views/Shared/Components/CountryCounter` folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            Assert.Contains("@model int", doc.Text);
        }

        [Fact]
        [Trait("Category", "Task3")]
        public void EX07_VerifyViewComponentUsage()
        {
            var filePath = TestHelpers.GetRootString() + "BethanysPieShopHRM"
                                                       + Path.DirectorySeparatorChar + "Views"
                                                       + Path.DirectorySeparatorChar + "_ViewImports.cshtml";

            Assert.True(File.Exists(filePath), "`_ViewImports.cshtml` should exist in the `Views` folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            Assert.Contains("@addTagHelper *, BethanysPieShopHRM", doc.Text);

            var filePath1 = TestHelpers.GetRootString() + "BethanysPieShopHRM"
                                                       + Path.DirectorySeparatorChar + "Views"
                                                       + Path.DirectorySeparatorChar + "Home"
                                                       + Path.DirectorySeparatorChar + "Index.cshtml";

            Assert.True(File.Exists(filePath1), "`Index.cshtml` should exist in the `Views/Home` folder.");

            var doc1 = new HtmlDocument();
            doc1.Load(filePath1);

            var counterTag = doc1.DocumentNode.Descendants("vc:country-counter").FirstOrDefault();
            Assert.NotNull(counterTag);
            Assert.Equal(0, counterTag!.Attributes.Count);
        }
    }
}