using System;
using System.Collections.Generic;

namespace PokemonFight.Data.EF;

public partial class Ataque
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public double? Daño { get; set; }

    public string? Tipo { get; set; }

    public virtual ICollection<AtaquePokemon> AtaquePokemons { get; set; } = new List<AtaquePokemon>();
}
