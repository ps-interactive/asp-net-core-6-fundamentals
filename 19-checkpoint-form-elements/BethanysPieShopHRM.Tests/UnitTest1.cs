using HtmlAgilityPack;

namespace BethanysPieShopHRM.Tests
{
    public class CH19Tests
    {
        [Fact]
        public void CH19_CheckInputAttributes()
        {
            var filePath = TestHelpers.GetRootString() + "BethanysPieShopHRM"
                                                       + Path.DirectorySeparatorChar + "Views"
                                                       + Path.DirectorySeparatorChar + "Employee"
                                                       + Path.DirectorySeparatorChar + "AddEmployee.cshtml";

            Assert.True(File.Exists(filePath), "`AddEmployee.cshtml` should exist in the Views/Employee folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            var inputTags = doc.DocumentNode.Descendants("input");

            var submitInputTag = inputTags.Last();
            foreach (var input in inputTags)
            {
                if (input != submitInputTag)
                {
                    Assert.True(input.Attributes["asp-for"] != null,
                        "Every form input should include the `asp-for` attribute with the corresponding model property assigned.");
                }
            }

            var labelTags = doc.DocumentNode.Descendants("label");

            foreach (var label in labelTags)
            {
                Assert.True(label.Attributes["asp-for"] != null,
                    "Every form label element should include the `asp-for` attribute with the corresponding model property assigned.");
            }
        }

        [Fact]
        public void CH19_CheckFormAttributes()
        {
            var filePath = TestHelpers.GetRootString() + "BethanysPieShopHRM"
                                                       + Path.DirectorySeparatorChar + "Views"
                                                       + Path.DirectorySeparatorChar + "Employee"
                                                       + Path.DirectorySeparatorChar + "AddEmployee.cshtml";

            Assert.True(File.Exists(filePath), "`AddEmployee.cshtml` should exist in the Views/Employee folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            var formTag = doc.DocumentNode.Descendants("form").FirstOrDefault();
            Assert.NotNull(formTag);

                    Assert.True(formTag!.Attributes["asp-action"].Value == "AddEmployee",
                        "The form tag should include the `asp-action` attribute with the AddEmployee action.");
        }
    }
}