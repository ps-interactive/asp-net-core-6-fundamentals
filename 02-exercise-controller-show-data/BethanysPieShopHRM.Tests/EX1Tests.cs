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
        [Trait("Category", "Task1")]
        public void EX1_VerifyCountryController()
        {
            var filePath = TestHelpers.GetRootString() + "BethanysPieShopHRM"
                                                       + Path.DirectorySeparatorChar + "Controllers"
                                                       + Path.DirectorySeparatorChar + "CountryController.cs";

            Assert.True(File.Exists(filePath), "`CountryController.cs` should exist in the Controllers folder.");

            Assert.True(typeof(Controller).IsAssignableFrom(typeof(CountryController)));
        }
    }
}