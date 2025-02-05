namespace APICounty.Interface
{
    public interface IPlayer
    {
        public List<PlayerDTO> GetAllPlayers();

        public List<PlayerDTO> GetPlayerById(long playerId);

        public string AddPlayer(PlayerCreate player);

        public List<string> UpdatePlayer(long playerId, PlayerUpdate player);

        public List<string> DeletePlayer(long playerId);
    }
}
