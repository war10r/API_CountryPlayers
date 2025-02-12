using System.ComponentModel.DataAnnotations;

namespace API_CountryPlayers.ActionClass.PlayersActions
{
    public class PlayerUpdate
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Login { get; set; }
        
        [Required]
        public string Password { get; set; }
        
        [Required]
        public int Age { get; set; }
    }
}
