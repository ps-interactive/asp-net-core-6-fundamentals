using System.IO.Pipelines;

namespace BethanysPieShopHRM.Models
{
    public class CountryRepository : ICountryRepository
    {
        private readonly BethanysPieShopHRMDbContext _bethanysPieShopHRMDbContext;

        public CountryRepository(BethanysPieShopHRMDbContext bethanysPieShopHRMDbContext)
        {
            _bethanysPieShopHRMDbContext = bethanysPieShopHRMDbContext;
        }

        public IEnumerable<Country> AllCountries => _bethanysPieShopHRMDbContext.Countries.OrderBy(p => p.CountryId);

        public Country GetCountryById(int id)
        {
            return _bethanysPieShopHRMDbContext.Countries.FirstOrDefault(c => c.CountryId == id);
        }

        public IEnumerable<Country> SearchCountries(string searchQuery)
        {
            return _bethanysPieShopHRMDbContext.Countries.Where(p => p.CountryName.ToLower().Contains(searchQuery.ToLower()));
        }
    }
}
