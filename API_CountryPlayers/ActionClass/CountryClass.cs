using API_CountryPlayers.ActionClass.CountryActions;
using API_CountryPlayers.ActionClass.DTO;
using API_CountryPlayers.Interface;
using API_CountryPlayers.Models;

namespace API_CountryPlayers.ActionClass
{
    public class CountryClass : ICountry
    {
        private readonly PlayersContext dbConnection;
        public CountryClass(PlayersContext context) => dbConnection = context;

        public List<string> AddCountry(CountryCreate country)
        {
            try
            {
                Country createCountry = new Country()
                {
                    CountryName = country.Name
                };
                dbConnection.Countries.Add(createCountry);
                dbConnection.SaveChanges();
                
                long countryId = createCountry.Id;
                Results.Created();
                
                return [$"Страна успешно создана ID - {countryId}"];
            }
            catch (Exception ex)
            {
                Results.BadRequest(new List<string> { "Ошибка в выполнении запроса"});
                throw;
            }
        }
        public List<string> DeleteCountry(long Id)
        {
            try
            {
                var country = dbConnection.Countries.Find(Id);
                var playerCount = dbConnection.Countries;
                
                if(country == null)
                {
                    Results.NotFound(new List<string> { "Страна не найдена" });
                }
                if(playerCount == 0)
                {
                    Results.BadRequest(new List<string> { "Не удаётся! Удалить страну, в которой есть игроки невозможно удалить" });
                    return new List<string> { "Не удаётся! Удалить страну, в которой есть игроки невозможно удалить" };
                }
                dbConnection.RemoveRange(country);
                dbConnection.SaveChanges();
                return new List<string> { "Страна успешно удалена" };
            }
            catch(Exception ex)
            {
              Results.BadRequest(new List<string> { "Ошибка в выполнении запроса"});
               throw;  
            }
        }

        public List<CountryDTO> GetAllCountries()
        {
            throw new NotImplementedException();
        }

        public List<CountryDTO> GetCountryById(long Id)
        {
            throw new NotImplementedException();
        }
    }
}
