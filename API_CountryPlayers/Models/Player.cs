using System;
using System.Collections.Generic;

namespace API_CountryPlayers.Models;

public partial class Player
{
    public long Id { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Name { get; set; } = null!;

    public long CountryId { get; set; }

    public int Age { get; set; }

    public virtual Country Country { get; set; } = null!;
}
