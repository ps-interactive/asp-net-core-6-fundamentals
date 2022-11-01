namespace BethanysPieShopHRM.Models
{
    public class CountryRepository : ICountryRepository
    {
        public IEnumerable<Country> AllCountries =>
            new List<Country>
            {
                new Country{CountryId=1, CountryName="USA"},
                new Country{CountryId=2, CountryName="Belgium"},
                new Country{CountryId=3, CountryName="France"},
                new Country{CountryId=4, CountryName="Germany"},
                new Country{CountryId=5, CountryName="UK"}

            };
    }
}
