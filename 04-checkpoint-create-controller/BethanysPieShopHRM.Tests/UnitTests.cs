using BethanysPieShopHRM.Controllers;
using BethanysPieShopHRM.Models;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShopHRM.Tests
{
    public class UnitTests
    {
        [Fact]
        [Trait("Category", "Task1")]
        public void CheckIfEmployeeControllerIsOfTypeController()
        {
            var controller = new EmployeeController();

            Assert.IsAssignableFrom<Controller>(controller);
        }

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