using API_CountryPlayers.ActionClass.DTO;
using API_CountryPlayers.ActionClass.PlayersActions;

namespace API_CountryPlayers.Interface
{
    public interface IPlayer
    {
        public List<PlayerDTO> GetAllPlayers();

        public List<PlayerDTO> GetPlayerById(long id);

        public List<string> AddPlayer(PlayerCreate player);

        public List<string> UpdatePlayer(string login, PlayerUpdate playerUpdate);

        public List<string> DeletePlayer(long Id);
    }
}
