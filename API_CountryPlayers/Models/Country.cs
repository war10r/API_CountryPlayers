using System;
using System.Collections.Generic;

namespace API_CountryPlayers.Models;

public partial class Country
{
    public long Id { get; set; }

    public string CountryName { get; set; } = null!;

    public long PlayerCount { get; set; }

    public virtual ICollection<Player> Players { get; set; } = new List<Player>();
}
