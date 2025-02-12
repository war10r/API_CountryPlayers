using API_CountryPlayers.ActionClass.DTO;
using API_CountryPlayers.Interface;
using API_CountryPlayers.Models;
using API_CountryPlayers.ActionClass.PlayersActions;

namespace API_CountryPlayers.ActionClass
{
    public class PlayerClass : IPlayer
    {
        private PlayersContext dbConnection;
        public PlayerClass(PlayersContext context) => dbConnection = context;
        public List<string> AddPlayer(PlayerCreate player)
        {
            var creatingPlayer = dbConnection.Players.Where(item => item.Login ==  player.Login).ToList();
            
            if (creatingPlayer.Any())
            {
                return new List<string> { "Пользователь с таким логином уже существует" };
            }

            try 
            {
                Player createPlayer = new Player()
                {   
                    Name = player.Name,
                    Login = player.Login,
                    Password = player.Password,
                    Age = player.Age,
                    CountryId = player.CountryId
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
        public List<PlayerDTO> GetPlayerById(long id)
        {
            try
            {
                var player = dbConnection.Players.Select(x => new PlayerDTO
                {
                    Name = x.Name,
                    Login = x.Login,
                    Password = x.Password,
                    Id = x.Id,
                    Age = x.Age,
                    CountryId = x.CountryId,
                }
                ).Where(u => u.Id == id).ToList();

                return (List<PlayerDTO>)player;
            }
            catch
            {
                Results.BadRequest();
                throw;
            }
        }
        public List<string> UpdatePlayer(string login,PlayerUpdate playerUpdate)
        {
            try 
            {
                var player = dbConnection.Players.FirstOrDefault(x => x.Login == login);
                if (player == null)
                {
                    Results.NoContent();
                    return [];
                }

                player.Name = playerUpdate.Name;
                player.Login = playerUpdate.Login;
                player.Password = playerUpdate.Password;
                player.Age = playerUpdate.Age;
                
                dbConnection.Players.Update(player);
                dbConnection.SaveChanges();

                Results.Ok();
                return ["Данные игрока успешно обновлены"];


            }
            catch
            {
                Results.BadRequest();
                throw;
            }
        }
    }
}
