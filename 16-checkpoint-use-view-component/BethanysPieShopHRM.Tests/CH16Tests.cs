using HtmlAgilityPack;

namespace BethanysPieShopHRM.Tests
{
    public class CH16Tests
    {
        [Fact]
        public void CH16_VerifyViewStart()
        {
            var filePath = TestHelpers.GetRootString() + "BethanysPieShopHRM"
                                                       + Path.DirectorySeparatorChar + "Views"
                                                       + Path.DirectorySeparatorChar + "_ViewImports.cshtml";

            Assert.True(File.Exists(filePath), "`_ViewImports.cshtml` should exist in the Views folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            Assert.True(doc.Text.Contains("@addTagHelper *, BethanysPieShopHRM"));
        }

        [Fact]
        public void CH16_VerifyListSection()
        {
            var filePath = TestHelpers.GetRootString() + "BethanysPieShopHRM"
                                                       + Path.DirectorySeparatorChar + "Views"
                                                       + Path.DirectorySeparatorChar + "Employee"
                                                       + Path.DirectorySeparatorChar + "List.cshtml";

            Assert.True(File.Exists(filePath), "`List.cshtml` should exist in the Views/Employee folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            Assert.True(doc.Text.Contains("<vc:employee-list />") 
            || doc.Text.Contains("<vc:employee-list/>")
            || doc.Text.Contains("<vc:employee-list></vc:employee-list>"));
        }
    }
}