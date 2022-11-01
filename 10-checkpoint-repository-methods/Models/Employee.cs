using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Reflection;

namespace BethanysPieShopHRM.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public DateTime BirthDate { get; set; }

        public string Email { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string Zip { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string? Comment { get; set; }

        public Category Category { get; set; } = default!;
        public int CategoryId { get; set; }
    }
}
