using BethanysPieShopHRM.Models;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShopHRM.Components
{
    public class CountryCounterViewComponent: ViewComponent
    {
        private readonly ICountryRepository _countryRepository;

        public CountryCounterViewComponent(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public IViewComponentResult Invoke()
        { 
            return View(_countryRepository.AllCountries.Count());

        }
    }
}
