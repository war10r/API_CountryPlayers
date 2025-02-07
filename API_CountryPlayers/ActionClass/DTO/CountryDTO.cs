using System.ComponentModel.DataAnnotations;

namespace API_CountryPlayers.ActionClass.DTO
{
    public class CountryDTO
    {
        [Key]
        long Id { get; set; }
        string CountryName { get; set; } = null!;
        int PlayerCount { get; set; }
    }
}
