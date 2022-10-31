using HtmlAgilityPack;

namespace BethanysPieShopHRM.Tests
{
    public class CH11Tests
    {
        [Fact]
        public void CH11_VerifyNavLinks()
        {
            var filePath = TestHelpers.GetRootString() + "BethanysPieShopHRM"
                                                       + Path.DirectorySeparatorChar + "Views"
                                                       + Path.DirectorySeparatorChar + "Shared"
                                                       + Path.DirectorySeparatorChar + "_Layout.cshtml";

            Assert.True(File.Exists(filePath), "`_Layout.cshtml` should exist in the Shared folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            var imgATag = doc.DocumentNode.Descendants("a").FirstOrDefault();
            Assert.NotNull(imgATag);
            var imgATagAttributes = imgATag!.Attributes;
            Assert.True(imgATagAttributes["asp-controller"]?.Value.ToLower() == "home");
            Assert.True(imgATagAttributes["asp-action"]?.Value.ToLower() == "index");

            var ulTag = doc.DocumentNode.Descendants("ul")?.FirstOrDefault();
            Assert.NotNull(ulTag);
            var firstUlLinkAttributes = ulTag!.Descendants("li").ElementAt(0)
                .Descendants("a").FirstOrDefault()
                ?.Attributes;
            Assert.NotNull(firstUlLinkAttributes);
            Assert.True(firstUlLinkAttributes!["asp-controller"]?.Value.ToLower() == "employee");
            Assert.True(firstUlLinkAttributes!["asp-action"]?.Value.ToLower() == "list");

            var secondUlLinkAttributes = ulTag.Descendants("li").ElementAt(1)
                .Descendants("a").FirstOrDefault()
                ?.Attributes;
            Assert.NotNull(secondUlLinkAttributes);
            Assert.True(secondUlLinkAttributes!["asp-controller"]?.Value.ToLower() == "help");
            Assert.True(secondUlLinkAttributes!["asp-action"]?.Value.ToLower() == "index");
        }
    }
}