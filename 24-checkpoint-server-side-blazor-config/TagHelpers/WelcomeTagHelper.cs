using Microsoft.AspNetCore.Razor.TagHelpers;

namespace BethanysPieShopHRM.TagHelpers
{
    public class WelcomeTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Content.SetContent("Welcome to Bethany's Pie Shop HRM");
        }
    }
}
