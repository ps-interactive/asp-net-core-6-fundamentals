using BethanysPieShopHRM.Models;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShopHRM.Controllers
{
    public class EmployeeController : Controller
    {
         List<Employee> employees = new List<Employee>();

        public IActionResult List()
        {
            return View(employees);
        }
    }
}
