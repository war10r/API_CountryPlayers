using API_CountryPlayers.ActionClass.DTO;
using API_CountryPlayers.ActionClass.PlayersActions;

namespace API_CountryPlayers.Interface
{
    public interface IPlayer
    {
        public List<PlayerDTO> GetAllPlayers();

        public List<PlayerDTO> GetPlayerById(long Id);

        public List<string> AddPlayer(PlayerCreate player);

        public List<string> UpdatePlayer(long Id, PlayerUpdate player);

        public List<string> DeletePlayer(long Id);
    }
}
