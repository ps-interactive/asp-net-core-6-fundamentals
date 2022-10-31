using BethanysPieShopHRM.Components;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShopHRM.Tests
{
    public class CH15Tests
    {
        [Fact]
        public void CH15_VerifyViewComponent()
        {
            var filePath = TestHelpers.GetRootString() + "BethanysPieShopHRM"
                                                       + Path.DirectorySeparatorChar + "Components"
                                                       + Path.DirectorySeparatorChar + "EmployeeList.cs";

            Assert.True(File.Exists(filePath), "`EmployeeList.cs` should exist in the `Components` folder.");

            var baseName = typeof(EmployeeList).BaseType!.Name;
            Assert.True(baseName != null && baseName.Contains("ViewComponent"));

            var doc = new HtmlDocument();
            doc.Load(filePath);

            var methods = typeof(EmployeeList).GetMethods();

            var invoke = methods.FirstOrDefault(x => x.Name == "Invoke");
            var invokeAsync = methods.FirstOrDefault(x => x.Name == "InvokeAsync");
            

            Assert.True(
                doc.Text.Contains("_employeeRepository.GetAllEmployees") &&
                (invoke != null || invokeAsync != null)
                && invoke.ReturnType == typeof(IViewComponentResult) || invokeAsync.ReturnType == typeof(IViewComponentResult));
        }
    }
}