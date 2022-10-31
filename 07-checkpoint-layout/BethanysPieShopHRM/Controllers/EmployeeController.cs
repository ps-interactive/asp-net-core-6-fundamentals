using BethanysPieShopHRM.Models;
using BethanysPieShopHRM.ViewModels;
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
            EmployeeListViewModel employeeListViewModel = new EmployeeListViewModel
            {
                Employees = _employeeRepository.GetAllEmployees(),

                EmployeeCategoryType = "Store staff"
            };

            return View(employeeListViewModel);
        }
    }
}
