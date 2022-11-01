using BethanysPieShopHRM.Models;
using Microsoft.AspNetCore.Components;

namespace BethanysPieShopHRM.Pages.App
{
    public partial class SearchBlazor
    {
        public string SearchText = "";
        public List<Country> FilteredCountries { get; set; } = new List<Country>();

        [Inject]
        public ICountryRepository? CountryRepository { get; set; }

        private void Search()
        {
            FilteredCountries.Clear();
            if (CountryRepository is not null)
            {
                if (SearchText.Length >= 3)
                    FilteredCountries = CountryRepository.SearchCountries(SearchText).ToList();
            }
        }
    }
}
