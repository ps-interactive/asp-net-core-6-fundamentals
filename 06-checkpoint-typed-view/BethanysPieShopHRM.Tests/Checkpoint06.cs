using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace BethanysPieShopHRM.Tests
{
    public class Checkpoint06
    {
        [Fact]
        [Trait("Category", "Task1")]
        public void CH06_VerifyListSection()
        {
            var filePath = TestHelpers.GetRootString() + "BethanysPieShopHRM"
                                                       + Path.DirectorySeparatorChar + "Views"
                                                       + Path.DirectorySeparatorChar + "Employee"
                                                       + Path.DirectorySeparatorChar + "List.cshtml";

            Assert.True(File.Exists(filePath), "`List.cshtml` should exist in the `Views/Employee` folder.");
        }

        [Fact]
        [Trait("Category", "Task2")]
        public void CH06_VerifyForeach()
        {
            var filePath = TestHelpers.GetRootString() + "BethanysPieShopHRM"
                                                       + Path.DirectorySeparatorChar + "Views"
                                                       + Path.DirectorySeparatorChar + "Employee"
                                                       + Path.DirectorySeparatorChar + "List.cshtml";

            Assert.True(File.Exists(filePath), "`List.cshtml` should exist in the `Views/Employee` folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            // The answer could vary a fair amount, this checkpoint has loose requirements
            Assert.True(doc.Text.Contains("@using BethanysPieShopHRM.ViewModels"));
            Assert.True(doc.Text.Contains("@model EmployeeListViewModel"));
            Assert.True(doc.Text.Contains("<h1>@Model.EmployeeCategoryType</h1>"));
            Assert.True(doc.Text.Contains("<table>"));


            string file;
            using (var streamReader = new StreamReader(filePath))
            {
                file = streamReader.ReadToEnd();
            }

            var pattern = @"@foreach\s*?[(]\s*?(var|Employee)\s*?item\s*?in\s*?Model.Employees[)]\s*?{\s*?<\s*?[tT][rR]\s*?>\s*?\s*?\s*?<\s*?[tT][dD]\s*?>\s*?@item.EmployeeId\s*?<\/\s*?[tT][dD]\s*?>\s*?\s*?\s*?<\s*?[tT][dD]\s*?>\s*?@item.FirstName\s*?<\/\s*?[tT][dD]\s*?>\s*?\s*?\s*?<\s*?[tT][dD]\s*?>\s*?@item.LastName\s*?<\/\s*?[tT][dD]\s*?>\s*?\s*?\s*?<\/\s*?[tT][rR]\s*?>\s*?\s*?}";
            var rgx = new Regex(pattern);
            Assert.True(rgx.IsMatch(file), "`List.cshtml does not appear to contain a `table` with a `foreach` loop that creates rows and columns for the `Employees`.");
        }
    }
}