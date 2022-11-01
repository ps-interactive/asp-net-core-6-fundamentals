using Microsoft.EntityFrameworkCore;
using System.IO.Pipelines;

namespace BethanysPieShopHRM.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly BethanysPieShopHRMDbContext _context;

        public EmployeeRepository(BethanysPieShopHRMDbContext context)
        {
            _context = context;
        }

        public List<Employee> GetAllEmployees()
        {
            return _context.Employees.Include(c => c.Category).ToList();
        }

        public Employee? GetEmployeeById(int employeeId)
        {
            return _context.Employees.FirstOrDefault(p => p.EmployeeId == employeeId);
        }
    }
}
