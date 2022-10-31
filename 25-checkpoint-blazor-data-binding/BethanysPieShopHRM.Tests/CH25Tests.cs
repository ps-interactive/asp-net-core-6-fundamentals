using HtmlAgilityPack;

namespace BethanysPieShopHRM.Tests
{
    public class CH25Tests
    {
        [Fact]
        public void CH25_VerifyInputAttributes()
        {
            var filePath = TestHelpers.GetRootString() + "BethanysPieShopHRM"
                                                       + Path.DirectorySeparatorChar + "Pages"
                                                       + Path.DirectorySeparatorChar + "App"
                                                       + Path.DirectorySeparatorChar + "SearchEmployees.razor";

            Assert.True(File.Exists(filePath), "`SearchEmployees.razor` should exist in the Pages/App folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            var inputTag = doc.DocumentNode.Descendants("input").FirstOrDefault();
            Assert.NotNull(inputTag);


            Assert.True(inputTag!.Attributes["@bind-value"] != null);
            Assert.Equal("SearchText", inputTag!.Attributes["@bind-value"].Value);
            Assert.True(inputTag!.Attributes["@bind-value:event"] != null);
            Assert.Equal("oninput", inputTag!.Attributes["@bind-value:event"].Value.ToLower());
            Assert.True(inputTag!.Attributes["@onkeyup"] != null);
            Assert.Equal("Search", inputTag!.Attributes["@onkeyup"].Value);
        }
    }
}