using BethanysPieShopHRM.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BethanysPieShopHRM.Tests
{
    public class CH17Tests
    {
        [Fact]
        public void CH17_VerifyWelcomeTagHelper()
        {
            var filePath = TestHelpers.GetRootString() + "BethanysPieShopHRM"
                                                       + Path.DirectorySeparatorChar + "TagHelpers"
                                                       + Path.DirectorySeparatorChar + "WelcomeTagHelper.cs";

            Assert.True(File.Exists(filePath), "`WelcomeTagHelper.cs` should exist in the TagHelpers folder.");
            Assert.IsAssignableFrom<TagHelper>(new WelcomeTagHelper());

            var welcomeTagHelper = new WelcomeTagHelper();

            var ctx = new TagHelperContext(new TagHelperAttributeList(), new Dictionary<object, object>(), Guid.NewGuid().ToString("N"));

            var output = new TagHelperOutput("welcome",
                new TagHelperAttributeList(), (useCachedResult, htmlEncoder) =>
                {
                    var tagHelperContent = new DefaultTagHelperContent();
                    tagHelperContent.SetContent(string.Empty);
                    return Task.FromResult<TagHelperContent>(tagHelperContent);
                });

            welcomeTagHelper.Process(ctx, output);
            Assert.Equal("Welcome to Bethany&#x27;s Pie Shop HRM", output.Content.GetContent());
        }
    }
}