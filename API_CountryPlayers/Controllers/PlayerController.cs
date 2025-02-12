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
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<List<string>>> Post(PlayerCreate playerCreate) => await Task.FromResult(_iplayer.AddPlayer(playerCreate));

        [HttpDelete("player/deletePlayer")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<List<string>>> Delete(long id) => await Task.FromResult(_iplayer.DeletePlayer(id));

        [HttpGet("player/getPlayerById")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<PlayerDTO>>> Get(long id) => await Task.FromResult(_iplayer.GetPlayerById(id));

        [HttpGet("player/getPlayer")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<PlayerDTO>>> Get() => await Task.FromResult(_iplayer.GetAllPlayers());

        [HttpPatch("player/updatePlayer")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<string>>> Patch(string login, PlayerUpdate playerUpdate) => await Task.FromResult(_iplayer.UpdatePlayer(login, playerUpdate));
    }
}
