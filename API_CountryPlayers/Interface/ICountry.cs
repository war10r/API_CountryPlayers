using API_CountryPlayers.ActionClass.CountryActions;
using API_CountryPlayers.ActionClass.DTO;

namespace API_CountryPlayers.Interface
{
    public interface ICountry
    {
        public List<CountryDTO> GetAllCountries();

        public List<CountryDTO> GetCountryById(long id);

        public List<string> AddCountry(CountryCreate country);

        public List<string> DeleteCountry(long Id);
    }
}
