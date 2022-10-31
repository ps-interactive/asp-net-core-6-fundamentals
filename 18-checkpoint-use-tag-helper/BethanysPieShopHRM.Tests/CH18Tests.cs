using HtmlAgilityPack;

namespace BethanysPieShopHRM.Tests
{
    public class CH18Tests
    {
        [Fact]
        [Trait("Category", "Task1")]
        public void CH18_VerifyViewImports()
        {
            var filePath = TestHelpers.GetRootString() + "BethanysPieShopHRM"
                                                       + Path.DirectorySeparatorChar + "Views"
                                                       + Path.DirectorySeparatorChar + "_ViewImports.cshtml";

            Assert.True(File.Exists(filePath), "`_ViewImports.cshtml` should exist in the Views folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            Assert.True(doc.Text.Contains("@addTagHelper BethanysPieShopHRM.TagHelpers.*, BethanysPieShopHRM"));
        }

        [Fact]
        [Trait("Category", "Task2")]
        public void CH16_VerifyIndex()
        {
            var filePath = TestHelpers.GetRootString() + "BethanysPieShopHRM"
                                                       + Path.DirectorySeparatorChar + "Views"
                                                       + Path.DirectorySeparatorChar + "Home"
                                                       + Path.DirectorySeparatorChar + "Index.cshtml";

            Assert.True(File.Exists(filePath), "`Index.cshtml` should exist in the Views/Home folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            Assert.True(doc.Text.Contains("<welcome />")
                        || doc.Text.Contains("<welcome/>")
                        || doc.Text.Contains("<welcome></welcome>"));
        }
    }
}