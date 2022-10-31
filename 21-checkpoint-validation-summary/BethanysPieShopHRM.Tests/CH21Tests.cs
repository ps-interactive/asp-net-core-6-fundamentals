using HtmlAgilityPack;

namespace BethanysPieShopHRM.Tests
{
    public class CH21Tests
    {
        [Fact]
        public void CH21_verifyVaidationMessage()
        {
            var filePath = TestHelpers.GetRootString() + "BethanysPieShopHRM"
                                                       + Path.DirectorySeparatorChar + "Views"
                                                       + Path.DirectorySeparatorChar + "Employee"
                                                       + Path.DirectorySeparatorChar + "AddEmployee.cshtml";

            Assert.True(File.Exists(filePath), "`AddEmployee.cshtml` should exist in the Views/Employee folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            var divTags = doc.DocumentNode.Descendants("div").Where(x => x.Attributes["asp-validation-summary"] != null);

            Assert.True(divTags.Count() > 0, "The product form should contain a div with the `asp-validation-summary` attribute.");
        }
    }
}