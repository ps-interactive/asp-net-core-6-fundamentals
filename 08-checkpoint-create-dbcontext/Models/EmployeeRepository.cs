namespace BethanysPieShopHRM.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public List<Employee> GetAllEmployees()
        {
            var e1 = new Employee
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
            };

            var e2 = new Employee
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
            };

            return new List<Employee>() { e1, e2 };
        }
    }
}
