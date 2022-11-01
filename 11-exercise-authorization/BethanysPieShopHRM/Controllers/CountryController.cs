using BethanysPieShopHRM.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShopHRM.Controllers
{
    [Authorize]
    public class CountryController : Controller
    {
        private readonly ICountryRepository _countryRepository;

        public CountryController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public IActionResult Index()
        {
            return View(_countryRepository.AllCountries);
        }

        public IActionResult Details(int id)
        {
            var country = _countryRepository.GetCountryById(id);
            return View(country);
        }
    }
}
