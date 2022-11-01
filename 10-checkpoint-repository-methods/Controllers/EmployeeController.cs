using BethanysPieShopHRM.Models;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShopHRM.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IActionResult List()
        {
            return View(_employeeRepository.GetAllEmployees());
        }


    }
}
