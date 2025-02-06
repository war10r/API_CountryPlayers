using API_CountryPlayers.ActionClass.Country;
using API_CountryPlayers.ActionClass.HelperClass.DTO;
using API_CountryPlayers.Interface;
using API_CountryPlayers.Models;

namespace API_CountryPlayers.ActionClass
{
    public class CountryClass : ICountry
    {
        private DbConnection dbConnection;

        public List<string> AddCountry(CountyCreate country)
        {
            try
            {
                Country createCountry = new Country();
                {
                    CountryName = country.Name;
                };
                dbConnection.Country.Add(createCountry);
                dbConnection.SaveChanges();
                
                int countryId = createCountry.Id;
                Results.Created();
                
                return [$"Страна успешно создана ID - {countryId}"];
            }
            catch (Exception ex)
            {
                Results.BadRequest(new List<string> { "Ошибка в выполнении запроса"});
                throw;
            }
        }
        public List<string> DeleteCountry(int countryID)
        {
            try
            {
                var country = dbConnection.Country.Find(countryId);
                var playerCount = dbConnection.Country;
                
                if(country == null)
                {
                    Results.NotFound(new List<string> { "Пользователь не найдет" });
                }
                if(playerCount == 0)
                {
                Results.BadRequest(new List<string> { "Не удаётся! Удалить страну, в которой есть игроки невозможно удалить" });
                }
                dbConnection.RemoveRange(country);
                dbConnection.SaveChanges();
            }
            catch(Exception ex)
            {
              Results.BadRequest(new List<string> { "Ошибка в выполнении запроса"});
                throw;  
            }
        }
        public List<CountryDTO> GetCountry(string country)
        {
            throw new NotImplementedException();
        }
        public List<CountryDTO> GetCountries()
        {
            throw new NotImplementedException();
        }
        public List<string> UpdateCountry(string country)
        {
            throw new NotImplementedException();
        }
    }
}
