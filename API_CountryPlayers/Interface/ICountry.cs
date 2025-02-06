namespace API_CountryPlayers.Interface
{
    public interface ICountry
    {
        public List<CountryDTO> GetAllCountries();

        public List<CountryDTO> GetCountryById(long countryId);

        public string AddCountry(PlayerCreate country);

        public List<string> DeleteCountry(long countryId);
    }
}
