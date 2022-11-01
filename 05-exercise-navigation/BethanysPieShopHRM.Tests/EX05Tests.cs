using HtmlAgilityPack;

namespace BethanysPieShopHRM.Tests
{
    public class EX05Tests
    {
        [Fact]
        public void EX05_VerifyIndex()
        {
            var filePath = TestHelpers.GetRootString() + "BethanysPieShopHRM"
                                 + Path.DirectorySeparatorChar + "Views"
                                 + Path.DirectorySeparatorChar + "Country"
                                 + Path.DirectorySeparatorChar + "Index.cshtml";

            Assert.True(File.Exists(filePath), "`Index.cshtml` should exist in the Views/Country folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            var aTag = doc.DocumentNode.Descendants("a").FirstOrDefault();
            Assert.NotNull(aTag);
            var aTagAttributes = aTag!.Attributes;
            Assert.True(aTagAttributes["asp-controller"]?.Value.ToLower() == "country");
            Assert.True(aTagAttributes["asp-action"]?.Value.ToLower() == "details");
            Assert.True(aTagAttributes["asp-route-id"]?.Value.ToLower() == "@item.countryid");
        }

        [Fact]
        public void EX05_VerifyDetail()
        {
            var filePath = TestHelpers.GetRootString() + "BethanysPieShopHRM"
                                                       + Path.DirectorySeparatorChar + "Views"
                                                       + Path.DirectorySeparatorChar + "Country"
                                                       + Path.DirectorySeparatorChar + "Details.cshtml";

            Assert.True(File.Exists(filePath), "`Details.cshtml` should exist in the Views/Country folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            var aTag = doc.DocumentNode.Descendants("a").FirstOrDefault();
            Assert.NotNull(aTag);
            var aTagAttributes = aTag!.Attributes;
            Assert.True(aTagAttributes["asp-controller"]?.Value.ToLower() == "country");
            Assert.True(aTagAttributes["asp-action"]?.Value.ToLower() == "index");
        }

        [Fact]
        public void EX05_VerifyLayout()
        {
            var filePath = TestHelpers.GetRootString() + "BethanysPieShopHRM"
                                                       + Path.DirectorySeparatorChar + "Views"
                                                       + Path.DirectorySeparatorChar + "Shared"
                                                       + Path.DirectorySeparatorChar + "_Layout.cshtml";

            Assert.True(File.Exists(filePath), "`_Layout.cshtml` should exist in the Views/Shared folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            var h1Tag = doc.DocumentNode.Descendants("h1").FirstOrDefault();
            Assert.NotNull(h1Tag);
            var h1ATag = h1Tag!.Descendants("a").FirstOrDefault();
            Assert.NotNull(h1ATag);
            var h1ATagAttributes = h1ATag!.Attributes;
            Assert.True(h1ATagAttributes["asp-controller"]?.Value.ToLower() == "home");
            Assert.True(h1ATagAttributes["asp-action"]?.Value.ToLower() == "index");

            var h3Tag = doc.DocumentNode.Descendants("h3").FirstOrDefault();
            Assert.NotNull(h3Tag);
            var h3ATag = h3Tag!.Descendants("a").FirstOrDefault();
            Assert.NotNull(h3ATag);
            var h3ATagAttributes = h3ATag!.Attributes;
            Assert.True(h3ATagAttributes["asp-controller"]?.Value.ToLower() == "country");
            Assert.True(h3ATagAttributes["asp-action"]?.Value.ToLower() == "index");
        }
    }
}