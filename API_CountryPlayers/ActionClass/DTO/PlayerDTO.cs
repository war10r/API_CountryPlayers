using System.ComponentModel.DataAnnotations;

namespace API_CountryPlayers.ActionClass.DTO
{
    public class PlayerDTO
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int Age { get; set; }
        public long CountryId { get; set; }
    }
}
