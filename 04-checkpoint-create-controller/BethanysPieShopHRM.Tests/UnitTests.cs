using BethanysPieShopHRM.Controllers;
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


    }
}