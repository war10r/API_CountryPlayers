using API_CountryPlayers.ActionClass.CountryActions;
using API_CountryPlayers.ActionClass.DTO;
using API_CountryPlayers.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_CountryPlayers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountry _icountry;
        public CountryController(ICountry icountry)
        {
            _icountry = icountry;
        }
        [HttpPost("country/addCountry")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public List<string> Post(CountryCreate countryCreate)
        {
            return _icountry.AddCountry(countryCreate);
        }

        [HttpDelete("country/deleteCountry")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<List<string>>> Delete(long id) => await Task.FromResult(_icountry.DeleteCountry(id));

        [HttpGet("country/getCountryById")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CountryDTO>>> Get(long id) => await Task.FromResult(_icountry.GetCountryById(id));

        [HttpGet("country/getCountry")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CountryDTO>>> Get() => await Task.FromResult(_icountry.GetAllCountries());



    }
}
