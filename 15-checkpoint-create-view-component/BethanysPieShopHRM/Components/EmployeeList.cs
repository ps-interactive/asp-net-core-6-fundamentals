using BethanysPieShopHRM.Models;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShopHRM.Components
{
    public class EmployeeList : ViewComponent
    {

        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeList(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IViewComponentResult Invoke()
        {
            var employees = _employeeRepository.GetAllEmployees();
            return View(employees);
        }
    }
}
