using HtmlAgilityPack;
using System.Reflection;
using System.Text.RegularExpressions;

namespace BethanysPieShopHRM.Tests
{
    public class EX3Tests
    {
        [Fact]
        public void EX3_VerifyIndexViewExists()
        {
            var filePath = TestHelpers.GetRootString() + "BethanysPieShopHRM"
                                 + Path.DirectorySeparatorChar + "Views"
                                 + Path.DirectorySeparatorChar + "Country"
                                 + Path.DirectorySeparatorChar + "Index.cshtml";

            Assert.True(File.Exists(filePath), "`Index.cshtml` should exist in the `Views/Country` folder.");
        }

        [Fact]
        public void EX3_VerifyIndexView()
        {
            var filePath = TestHelpers.GetRootString() + "BethanysPieShopHRM"
                                                       + Path.DirectorySeparatorChar + "Views"
                                                       + Path.DirectorySeparatorChar + "Country"
                                                       + Path.DirectorySeparatorChar + "Index.cshtml";

            Assert.True(File.Exists(filePath), "`Index.cshtml` should exist in the `Views/Country` folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            Assert.Contains("@model IEnumerable<BethanysPieShopHRM.Models.Country>", doc.Text);
            
            var pattern = @"Layout\s*?=\s*?[""]*[_]Layout[""]";
            var rgx = new Regex(pattern);
            Assert.True(rgx.IsMatch(doc.Text), "`Index.cshtml` does not appear to contain a Layout property");

            Assert.Contains("<table>", doc.Text);

            var pattern2 = @"@foreach\s*?[(]\s*?(var|Country)\s*?item\s*?in\s*?Model[)]\s*?{\s*?<\s*?[tT][rR]\s*?>\s*?\s*?\s*?<\s*?[tT][dD]\s*?>\s*?@item.CountryId\s*?<\/\s*?[tT][dD]\s*?>\s*?\s*?\s*?<\s*?[tT][dD]\s*?>\s*?@item.CountryName\s*?<\/\s*?[tT][dD]\s*?>\s*?\s*?\s*?<\/\s*?[tT][rR]\s*?>\s*?\s*?}";
            var rgx2 = new Regex(pattern2);
            Assert.True(rgx.IsMatch(doc.Text), "`Index.cshtml does not appear to contain a `table` with a `foreach` loop that creates rows and columns for the `Countries`.");
        }
    }
}