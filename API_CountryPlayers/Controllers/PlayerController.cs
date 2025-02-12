using API_CountryPlayers.ActionClass.CountryActions;
using API_CountryPlayers.ActionClass.DTO;
using API_CountryPlayers.ActionClass.PlayersActions;
using API_CountryPlayers.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_CountryPlayers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayer _iplayer;
        public PlayerController(IPlayer iplayer)
        {
            _iplayer = iplayer;
        }
        [HttpPost("player/addPlayer")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public List<string> Post(PlayerCreate playerCreate)
        {
            return _iplayer.AddPlayer(playerCreate);
        }

        [HttpDelete("player/deletePlayer")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public List<string> Delete(long id)
        {
            return _iplayer.DeletePlayer(id);
        }

        [HttpGet("player/getPlayerById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public List<PlayerDTO> Get(long id)
        {
            return _iplayer.GetPlayerById(id);
        }
        [HttpGet("player/getPlayer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public List<PlayerDTO> Get()
        {
            return _iplayer.GetAllPlayers();
        }
        [HttpPatch("player/updatePlayer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public List<string> Patch(string login, PlayerUpdate playerUpdate)
        {
            return _iplayer.UpdatePlayer(login, playerUpdate);
        }
    }
}
