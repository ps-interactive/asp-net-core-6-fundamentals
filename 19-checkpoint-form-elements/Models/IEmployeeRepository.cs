using System.IO.Pipelines;

namespace BethanysPieShopHRM.Models
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAllEmployees();
        Employee? GetEmployeeById(int employeeId);
    }
}
