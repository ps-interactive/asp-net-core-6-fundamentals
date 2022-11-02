using BethanysPieShopHRM.Controllers;
using BethanysPieShopHRM.Models;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShopHRM.Tests1
{
    public class UnitTest1
    {
        [Fact]
        [Trait("Category", "Task2")]
        public void GetListOfEmployeesViewTest()
        {
            var controller = new EmployeeController();
            var listView = controller.List();

            Assert.NotNull(listView);
            Assert.IsType<ViewResult>(listView);
            Assert.IsType<List<Employee>>(((listView as ViewResult)!).ViewData.Model);
        }
    }
}