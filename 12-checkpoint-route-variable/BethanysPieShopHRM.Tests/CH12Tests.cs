using HtmlAgilityPack;

namespace BethanysPieShopHRM.Tests
{
    public class CH12Tests
    {
        [Fact]
        public void CH12_VerifyNavLink()
        {
            var filePath = TestHelpers.GetRootString() + "BethanysPieShopHRM"
                                                       + Path.DirectorySeparatorChar + "Views"
                                                       + Path.DirectorySeparatorChar + "Employee"
                                                       + Path.DirectorySeparatorChar + "List.cshtml";

            Assert.True(File.Exists(filePath), "`List.cshtml` should exist in the Views/Employee folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            var trTag = doc.DocumentNode.Descendants("tr").FirstOrDefault();
            Assert.NotNull(trTag);

            var tdTagForNav = doc.DocumentNode.Descendants("td")?.ElementAt(3);
            Assert.NotNull(tdTagForNav);
            var aTag = tdTagForNav!.Descendants("a").FirstOrDefault();
            Assert.NotNull(aTag);
            var aTagAttributes = aTag!.Attributes;
            Assert.NotNull(aTagAttributes);
            Assert.True(aTagAttributes!["asp-controller"]?.Value.ToLower() == "employee");
            Assert.True(aTagAttributes!["asp-action"]?.Value.ToLower() == "details");
            Assert.True(aTagAttributes!["asp-route-id"]?.Value.ToLower() == "@item.employeeid");

        }
    }
}