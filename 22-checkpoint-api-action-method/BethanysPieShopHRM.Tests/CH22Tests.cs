using BethanysPieShopHRM.Controllers.Api;
using BethanysPieShopHRM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShopHRM.Tests
{
    public class CH22Tests
    {
        [Fact]
        public void CH22_VerifyMethodReturns()
        {
            var options = new DbContextOptionsBuilder<BethanysPieShopHRMDbContext>()
                .UseInMemoryDatabase(databaseName: "BethanysPieShopHRM")
                .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new BethanysPieShopHRMDbContext(options))
            {
                context.Employees.Add(new Employee
                {
                    BirthDate = new DateTime(1989, 3, 11),
                    City = "Brussels",
                    Email = "bethany@bethanyspieshop.com",
                    EmployeeId = 1,
                    FirstName = "Bethany",
                    LastName = "Smith",
                    PhoneNumber = "324777888773",
                    Street = "Grote Markt 1",
                    Zip = "1000",
                    Comment = "Lorem Ipsum",
                    Category = new Category
                    {
                        CategoryId = 1,
                        CategoryName = "Management"
                    }
                });
                context.Employees.Add(new Employee
                {
                    BirthDate = new DateTime(1979, 1, 16),
                    City = "Antwerp",
                    Email = "gill@bethanyspieshop.com",
                    EmployeeId = 2,
                    FirstName = "Gill",
                    LastName = "Cleeren",
                    PhoneNumber = "33999909923",
                    Street = "New Street",
                    Zip = "2000",
                    Comment = "Lorem Ipsum",
                    Category = new Category
                    {
                        CategoryId = 2,
                        CategoryName = "Sales"
                    }
                });
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new BethanysPieShopHRMDbContext(options))
            {
                EmployeeRepository employeeRepository = new EmployeeRepository(context);
                var controller = new SearchController(employeeRepository);

                var employees = controller.GetAllEmployees();
                Assert.IsType<OkObjectResult>(employees);
                Assert.Equal(StatusCodes.Status200OK, (employees as OkObjectResult).StatusCode);
                Assert.Equal(2, ((employees as OkObjectResult).Value as List<Employee>).Count);
            }

            // Use a clean instance of the context to run the test
            using (var context = new BethanysPieShopHRMDbContext(options))
            {
                EmployeeRepository employeeRepository = new EmployeeRepository(context);
                var controller = new SearchController(employeeRepository);

                var employee = controller.GetById(1);
                Assert.IsType<OkObjectResult>(employee);
                Assert.Equal(StatusCodes.Status200OK, (employee as OkObjectResult).StatusCode);
                Assert.Equal(1, ((employee as OkObjectResult).Value as Employee).EmployeeId);
                Assert.Equal("Bethany", ((employee as OkObjectResult).Value as Employee).FirstName);

            }
        }
    }
}