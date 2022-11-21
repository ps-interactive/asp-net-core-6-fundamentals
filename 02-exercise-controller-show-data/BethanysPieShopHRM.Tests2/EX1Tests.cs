using BethanysPieShopHRM.Controllers;
using BethanysPieShopHRM.Models;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShopHRM.Tests
{
    public class EX1Tests
    {
    
        [Fact]
        [Trait("Category", "Task2")]
        public void EX1_VerifyCountryControllerActionMethod()
        {
            var filePath = TestHelpers.GetRootString() + "BethanysPieShopHRM"
                                                       + Path.DirectorySeparatorChar + "Controllers"
                                                       + Path.DirectorySeparatorChar + "CountryController.cs";

            Assert.True(File.Exists(filePath), "`CountryController.cs` should exist in the Controllers folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            Assert.Contains("_countryRepository.AllCountries", doc.Text);

            var methods = typeof(CountryController).GetMethods();
            var indexMethod = methods.FirstOrDefault(x => x.Name == "Index");

            Assert.True(indexMethod != null 
                && indexMethod.ReturnType == typeof(IActionResult));
        }

        [Fact]
        [Trait("Category", "Task2")]
        public void EX1_VerifyCountryControllerIndexMethod()
        {
            var filePath = TestHelpers.GetRootString() + "BethanysPieShopHRM"
                                                       + Path.DirectorySeparatorChar + "Controllers"
                                                       + Path.DirectorySeparatorChar + "CountryController.cs";

            Assert.True(File.Exists(filePath), "`CountryController.cs` should exist in the Controllers folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            Assert.Contains("_countryRepository.AllCountries", doc.Text);

                CountryRepository countryRepository = new CountryRepository();
                var controller = new CountryController(countryRepository);

                var view = controller.Index();
                Assert.IsType<ViewResult>(view);
                var viewResult = view as ViewResult;
                Assert.NotNull(viewResult);
                Assert.Equal(5, ((viewResult!.Model as List<Country>)!).Count);
        }
    }
}