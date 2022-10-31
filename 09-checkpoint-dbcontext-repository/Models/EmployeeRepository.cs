namespace BethanysPieShopHRM.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {

        public List<Employee> GetAllEmployees()
        {
            return new List<Employee>() { };
        }
    }
}
