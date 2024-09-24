using System;
using System.Collections.Generic;

namespace Taco_Fast_Food_API.Models;

public partial class Drink
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public float? Cost { get; set; }

    public bool? Slushie { get; set; }

    public virtual ICollection<Combo> Combos { get; set; } = new List<Combo>();
}
