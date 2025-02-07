using API_CountryPlayers.ActionClass.DTO;
using API_CountryPlayers.Interface;
using API_CountryPlayers.Models;
using API_CountryPlayers.ActionClass.PlayersActions;

namespace API_CountryPlayers.ActionClass
{
    public class PlayerClass : IPlayer
    {
        private readonly PlayersContext dbConnection;
        public PlayerClass(PlayersContext context) => dbConnection = context;
        public List<string> AddPlayer(PlayerCreate player)
        {
            try 
            {
                Player createPlayer = new Player()
                {   
                    Name = player.Name,
                    Login = player.Login,
                    Password = player.Password,
                    Age = player.Age
                };

                dbConnection.Players.Add(createPlayer);
                dbConnection.SaveChanges();

                long playerId = createPlayer.Id;
                Results.Created();
                return [$"Игрок успешно создан ID - {playerId}"];
            }
            catch (Exception ex)
            {
                Results.BadRequest(new List<string> { "Ошибка в выполнении запроса" });
                throw;
            }
        }
        public List<string> DeletePlayer(long Id)
        {
            try
            {
                var player = dbConnection.Players.Find(Id);
                if (player == null) 
                {
                    Results.NotFound(new List<string> { "Пользователь не найден" });
                }
                dbConnection.Players.Remove(player);
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
        public List<PlayerDTO> GetAllPlayers()
        {
try
            {
                var players = dbConnection.Players.Select(
                    x => new PlayerDTO()
                    {
                        Name = x.Name, Login = x.Login, Id = x.Id, Age = x.Age, CountryId = x.CountryId,
                    }).ToList();

                return (List<PlayerDTO>)players;
            }
            catch
            {
                Results.BadRequest();
                throw;
            }
        }
        public List<PlayerDTO> GetPlayerById(long Id)
        {
            try
            {
                var player = dbConnection.Players.Where(u => u.Id == Id).Select(x => new PlayerDTO
                {
                    Name = x.Name,
                    Login = x.Login,
                    Id = x.Id,
                    Age = x.Age,
                    CountryId = x.CountryId,
                }
                ).ToList();
                return (List<PlayerDTO>)player;
            }
            catch
            {
                Results.BadRequest();
                throw;
            }
        }
        public List<string> UpdatePlayer(long Id,PlayerUpdate player)
        {
            throw new NotImplementedException();
        }
    }
}
