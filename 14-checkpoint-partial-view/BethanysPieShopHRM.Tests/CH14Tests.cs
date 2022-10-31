using HtmlAgilityPack;

namespace BethanysPieShopHRM.Tests
{
    public class CH14Tests
    {
        [Fact]
        public void CH14_VerifyEmployeeRowFile()
        {
            var filePath = TestHelpers.GetRootString() + "BethanysPieShopHRM"
                                                       + Path.DirectorySeparatorChar + "Views"
                                                       + Path.DirectorySeparatorChar + "Shared"
                                                       + Path.DirectorySeparatorChar + "_EmployeeRow.cshtml";

            Assert.True(File.Exists(filePath), "`_EmployeeRow.cshtml` should exist in the Views/Shared folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            var trTag = doc.DocumentNode.Descendants("tr").FirstOrDefault();
            Assert.NotNull(trTag);
        }

        [Fact]
        public void CH14_VerifyUsePartialView()
        {
            var filePath = TestHelpers.GetRootString() + "BethanysPieShopHRM"
                                                       + Path.DirectorySeparatorChar + "Views"
                                                       + Path.DirectorySeparatorChar + "Employee"
                                                       + Path.DirectorySeparatorChar + "List.cshtml";

            Assert.True(File.Exists(filePath), "`List.cshtml` should exist in the Views/Employee folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);
            Assert.True(doc.Text.Contains("<partial name=\"_EmployeeRow\" model=\"item\" />") 
                        || doc.Text.Contains("<partial name=\"_EmployeeRow\" model=\"item\"/>")
                        || doc.Text.Contains("<partial name=\"_EmployeeRow\" model=\"item\"></partial>"));
        }
    }
}