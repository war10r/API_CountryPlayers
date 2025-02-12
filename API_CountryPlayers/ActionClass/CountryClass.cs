using System.Data.Common;
using System.Reflection.Metadata.Ecma335;
using API_CountryPlayers.ActionClass.CountryActions;
using API_CountryPlayers.ActionClass.DTO;
using API_CountryPlayers.Interface;
using API_CountryPlayers.Models;

namespace API_CountryPlayers.ActionClass
{
    public class CountryClass : ICountry
    {
        private PlayersContext dbConnection;
        public CountryClass(PlayersContext context) => dbConnection = context;

        public List<string> AddCountry(CountryCreate country)
        {
            try
            {
                Country createCountry = new Country()
                {
                    CountryName = country.CountryName
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
                if(country.PlayerCount == 0)
                {
                    Results.BadRequest(new List<string> { "Не удаётся! Удалить страну, в которой есть игроки невозможно удалить" });
                }
                dbConnection.Remove(country);
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
            try
            {
                var country = dbConnection.Countries.Select(x => new CountryDTO()
                {
                    Id = x.Id,
                    CountryName = x.CountryName,
                    PlayerCount = x.PlayerCount
                }
                ).ToList();

                return (List<CountryDTO>)country;
            }
            catch(Exception ex) 
            { 
                Results.BadRequest();
                throw;
            }
        }

        public List<CountryDTO> GetCountryById(long id)
        {
            try
            {
                var country = dbConnection.Countries.Select(x => new CountryDTO()
                {
                    Id = x.Id,
                    CountryName = x.CountryName,
                }).
                Where(item => item.Id == id).
                ToList();
                return (List<CountryDTO>)country;
            }
            catch(Exception ex) { Results.BadRequest(); throw; }
        }
    }
}
