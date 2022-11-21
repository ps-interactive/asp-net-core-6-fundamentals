using BethanysPieShopHRM.Models;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShopHRM.Tests
{
    public class Ch10Tests
    {
        [Fact]
        public void CH10_VerifyGetAllEmployees()
        {
            var options = new DbContextOptionsBuilder<BethanysPieShopHRMDbContext>()
                .UseInMemoryDatabase(databaseName: "BethanysPieShopHRM")
                .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new BethanysPieShopHRMDbContext(options))
            {
                context.Database.EnsureDeleted();

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
                List<Employee> employees = employeeRepository.GetAllEmployees();

                Assert.Equal(2, employees.Count);
                Assert.NotNull(employees[0].Category);
            }
        }

        [Fact]
        public void CH10_VerifyGetEmployeeById()
        {
            var options = new DbContextOptionsBuilder<BethanysPieShopHRMDbContext>()
                .UseInMemoryDatabase(databaseName: "BethanysPieShopHRM")
                .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new BethanysPieShopHRMDbContext(options))
            {
                context.Database.EnsureDeleted();
                context.Employees.Add(new Employee
                {
                    BirthDate = new DateTime(1989, 3, 11),
                    City = "Brussels",
                    Email = "bethany@bethanyspieshop.com",
                    EmployeeId = 3,
                    FirstName = "Bethany",
                    LastName = "Smith",
                    PhoneNumber = "324777888773",
                    Street = "Grote Markt 1",
                    Zip = "1000",
                    Comment = "Lorem Ipsum",
                    Category = new Category
                    {
                        CategoryId = 3,
                        CategoryName = "Management"
                    }
                });
                
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new BethanysPieShopHRMDbContext(options))
            {
                EmployeeRepository employeeRepository = new EmployeeRepository(context);
                Employee? employee = employeeRepository.GetEmployeeById(3);
                Employee? employee2 = employeeRepository.GetEmployeeById(4);

                Assert.NotNull(employee);
                Assert.Null(employee2);
                Assert.Equal("Bethany", employee!.FirstName);
            }
        }
    }
}
