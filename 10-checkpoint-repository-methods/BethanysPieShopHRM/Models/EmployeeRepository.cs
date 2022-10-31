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
        
    }
}
