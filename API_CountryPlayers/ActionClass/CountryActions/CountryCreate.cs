using System.ComponentModel.DataAnnotations;

namespace API_CountryPlayers.ActionClass.CountryActions
{
    public class CountryCreate
    {
        [Required]
        public string Name { get; set; }
    }
}
