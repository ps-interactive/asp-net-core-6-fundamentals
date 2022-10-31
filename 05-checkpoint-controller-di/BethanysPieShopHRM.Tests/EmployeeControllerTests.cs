using BethanysPieShopHRM.Controllers;
using BethanysPieShopHRM.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace BethanysPieShopHRM.Tests
{
    public class EmployeeControllerTests
    {
        [Fact]
        public void CheckListMethod()
        {
            // Arrange
            var employeeRepository = new Mock<IEmployeeRepository>();
            employeeRepository
                .Setup(e => e.GetAllEmployees())
                .Returns(new List<Employee>());

                // Act
            var sut = new EmployeeController(employeeRepository.Object);
            var listView = sut.List();


            // Assert
            Assert.NotNull(listView);
            Assert.IsType<ViewResult>(listView);
            Assert.IsType<List<Employee>>(((listView as ViewResult)!).ViewData.Model);

            employeeRepository.Verify(e => e.GetAllEmployees(), Times.Once());
        }
    }
}