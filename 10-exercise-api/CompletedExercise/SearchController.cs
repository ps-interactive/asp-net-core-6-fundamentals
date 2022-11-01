using BethanysPieShopHRM.Models;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShopHRM.Controllers.Api
{
    [Route("api/[controller]")]
    public class SearchController : Controller
    {
        private readonly ICountryRepository _countryRepository;

        public SearchController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        [HttpGet]
        public IActionResult SearchCountries([FromQuery] string value)
        {
            IEnumerable<Country> countries = new List<Country>();

            if (!string.IsNullOrEmpty(value))
            {
                countries = _countryRepository.SearchCountries(value);
                return new JsonResult(countries);
            }
            else
                return BadRequest();
        }
    }
}