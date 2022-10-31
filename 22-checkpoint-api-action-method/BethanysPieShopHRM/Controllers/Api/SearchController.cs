using BethanysPieShopHRM.Models;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShopHRM.Controllers.Api
{
    public class SearchController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public SearchController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }


        public IActionResult GetAllEmployees()
        {
            var employees = _employeeRepository.GetAllEmployees();
        }

        public IActionResult GetById(int id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);

        }
    }
}
