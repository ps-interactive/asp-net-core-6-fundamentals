using BethanysPieShopHRM.Models;

namespace BethanysPieShopHRM.ViewModels
{
    public class EmployeeListViewModel
    {
        public string EmployeeCategoryType { get; set; } = string.Empty;

        public List<Employee> Employees { get; set; } = default!;

    }
}
