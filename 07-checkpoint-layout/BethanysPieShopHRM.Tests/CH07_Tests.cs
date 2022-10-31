using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace BethanysPieShopHRM.Tests
{
    public class CH07_Tests
    {
        [Fact]
        [Trait("Category", "Task1")]
        public void CH07_VerifyLayoutSection()
        {
            var filePath = TestHelpers.GetRootString() + "BethanysPieShopHRM"
                                                       + Path.DirectorySeparatorChar + "Views"
                                                       + Path.DirectorySeparatorChar + "Shared"
                                                       + Path.DirectorySeparatorChar + "_Layout.cshtml";

            Assert.True(File.Exists(filePath), "`_Layout.cshtml` should exist in the Views/Shared folder.");
        }

        [Fact]
        [Trait("Category", "Task2")]
        public void CH07_VerifyPlaceholderViewContent()
        {
            var filePath = TestHelpers.GetRootString() + "BethanysPieShopHRM"
                                                       + Path.DirectorySeparatorChar + "Views"
                                                       + Path.DirectorySeparatorChar + "Shared"
                                                       + Path.DirectorySeparatorChar + "_Layout.cshtml";

            Assert.True(File.Exists(filePath), "`_Layout.cshtml` should exist in the Views/Shared folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            var divTags = doc.DocumentNode.Descendants("div");

            Assert.True(divTags != null,
                "`_Layout.cshtml` should contain a `div` element.");

            var firstDivTag = divTags!.FirstOrDefault()?.InnerHtml;
            Assert.True(firstDivTag != null,
                "The first `div` element should contain the placeholder for the regular view content.");

            Assert.Contains("@RenderBody()", firstDivTag!);
        }

        [Fact]
        [Trait("Category", "Task3")]
        public void CH07_VerifyViewStartSection()
        {
            var filePath = TestHelpers.GetRootString() + "BethanysPieShopHRM"
                                                       + Path.DirectorySeparatorChar + "Views"
                                                       + Path.DirectorySeparatorChar + "_ViewStart.cshtml";

            Assert.True(File.Exists(filePath), "`_ViewStart.cshtml` should exist in the Views folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            var pattern = @"Layout\s*?=\s*?[""]*[_]Layout[""]";
            var rgx = new Regex(pattern);

            Assert.True(rgx.IsMatch(doc.Text), "`_ViewStart.cshtml` does not appear to contain a Layout property");
        }
    }
}