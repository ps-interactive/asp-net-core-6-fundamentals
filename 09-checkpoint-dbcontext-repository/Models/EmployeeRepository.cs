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
            return new List<Employee>() { };
        }
    }
}
