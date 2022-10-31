using BethanysPieShopHRM.Models;
using Microsoft.AspNetCore.Authorization;
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

        public IActionResult Details(int id)
        {
            return View(_employeeRepository.GetEmployeeById(id));
        }

        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            return View(employee);
        }
    }
}
