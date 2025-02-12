using System.ComponentModel.DataAnnotations;

namespace API_CountryPlayers.ActionClass.DTO
{
    public class CountryDTO
    {
        [Key]
        public long Id { get; set; }
        public string CountryName { get; set; } = null!;
        public long PlayerCount { get; set; }
    }
}
