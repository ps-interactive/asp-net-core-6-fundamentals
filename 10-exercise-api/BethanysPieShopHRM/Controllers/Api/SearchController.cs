using BethanysPieShopHRM.Models;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShopHRM.Controllers.Api
{
    public class SearchController : Controller
    {
        private readonly ICountryRepository _countryRepository;

        public SearchController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        
    }
}