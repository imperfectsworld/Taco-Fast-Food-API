using System;
using System.Collections.Generic;

namespace Taco_Fast_Food_API.Models;

public partial class Combo
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? TacoId { get; set; }

    public int? DrinkId { get; set; }

    public float? Cost { get; set; }

    public virtual Drink? Drink { get; set; }

    public virtual Taco? Taco { get; set; }
}
