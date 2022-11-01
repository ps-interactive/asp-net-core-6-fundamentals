using BethanysPieShopHRM.TagHelpers;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BethanysPieShopHRM.Tests
{
    public class EX06Tests
    {
        [Fact]
        public void EX06_VerifyEmailTagHelper()
        {
            var filePath = TestHelpers.GetRootString() + "BethanysPieShopHRM"
                                                       + Path.DirectorySeparatorChar + "TagHelpers"
                                                       + Path.DirectorySeparatorChar + "EmailTagHelper.cs";

            Assert.True(File.Exists(filePath), "`EmailTagHelper.cs` should exist in the TagHelpers folder.");
            Assert.IsAssignableFrom<TagHelper>(new EmailTagHelper());

            var emailTagHelper = new EmailTagHelper();
            emailTagHelper.Address = "example@example.com";
            emailTagHelper.Content = "Contact us!";

            var ctx = new TagHelperContext(new TagHelperAttributeList(), new Dictionary<object, object>(), Guid.NewGuid().ToString("N"));

            var output = new TagHelperOutput("welcome",
                new TagHelperAttributeList(), (useCachedResult, htmlEncoder) =>
                {
                    var tagHelperContent = new DefaultTagHelperContent();
                    tagHelperContent.SetContent(string.Empty);
                    return Task.FromResult<TagHelperContent>(tagHelperContent);
                });

            emailTagHelper.Process(ctx, output);
            Assert.Equal("Contact us!", output.Content.GetContent());
            Assert.Equal("mailto:example@example.com", output.Attributes.FirstOrDefault(a => a.Name == "href")!.Value.ToString());
        }

        [Fact]
        public void EX06_VerifyEmailTagHelperUsage()
        {
            var filePath = TestHelpers.GetRootString() + "BethanysPieShopHRM"
                                                       + Path.DirectorySeparatorChar + "Views"
                                                       + Path.DirectorySeparatorChar + "Home"
                                                       + Path.DirectorySeparatorChar + "Index.cshtml";

            Assert.True(File.Exists(filePath), "`Index.cshtml` should exist in the Views/Home folder.");

            var doc = new HtmlDocument();
            doc.Load(filePath);

            var emailTag = doc.DocumentNode.Descendants("email").FirstOrDefault();
            Assert.NotNull(emailTag);

            var attributes = emailTag!.Attributes;
            Assert.Equal("Contact us", attributes["content"].Value);
            Assert.Equal("info@@bethanyspieshop.com", attributes["address"].Value);
        }
    }
}