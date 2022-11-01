namespace BethanysPieShopHRM.Models
{
    public interface ICountryRepository
    {
        IEnumerable<Country> AllCountries { get; }

        Country GetCountryById(int id);
    }
}
