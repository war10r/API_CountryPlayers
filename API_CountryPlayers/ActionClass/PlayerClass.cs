using API_CountryPlayers.ActionClass.HelperClass.DTO;
using API_CountryPlayers.Interface;
using API_CountryPlayers.Models;
using API_CountryPlayers.ActionClass.Player;

namespace API_CountryPlayers.ActionClass
{
    public class PlayerClass : IPlayer
    {
        private DbConnection dbConnection;

        

        public List<string> AddPlayer(PlayerCreate player)
        {
            try 
            {
                Player createPlayer = new Player();
                {   
                    Name = player.Name,
                    Login = player.Login,
                    Age = player.Age,
                    Password = player.Password
                };

                dbConnection.Player.Add(createPlayer);
                dbConnection.SaveChanges();

                long playerId = createPlayer.Id;
                Results.Created();

                return [$"Игрок успешно создан ID - {playerId}"];
            }
        }
        public List<string> DeletePlayer(int playerId)
        {
            try
            {
                var player = dbConnection.Players.Find(playerId);
                if (player == null) 
                {
                    Results.NotFound(new List<string> { "Пользователь не найден" });
                }
                dbConnection.players.Remove(player);
                dbConnection.SaveChanges();

                Results.NoContent();
                return new List<string> { "Пользователь успешно удален" };

            }
            catch
            {
                Results.BadRequest(new List<string> { "Ошибка в выполнении запроса" });
                throw;
            }
        }
        public List<PlayerDTO> GetPlayer(string player)
        {
try
            {
                var player = dbConnection.Players.Select(
                    x => new PlayerDTO()
                    {
                        Name = x.Name, Login = x.Login, Id = x.Id, Age = x.Age, CountryId = x.CountryId,
                    }).ToList();

                return (List<PlayerDTO>)player;
            }
            catch
            {
                Results.BadRequest();
                throw;
            }
        }
        public List<PlayerDTO> GetPlayerById(string player)
        {
            try
            {
                var player = _context.Persons.Where(u => u.Name == name).Select(x => new PersonDTO
                {
                    Name = x.Name,
                    Login = x.Login,
                    Id = x.Id,
                    Age = x.Age,
                    CountryId = x.CountryId,
                }
                ).ToList();
                return (List<PersonDTO>)player;
            }
            catch
            {
                Results.BadRequest();
                throw;
            }
        }
        public List<string> UpdatePlayer(string Player)
        {
            throw new NotImplementedException();
        }
    }
}
