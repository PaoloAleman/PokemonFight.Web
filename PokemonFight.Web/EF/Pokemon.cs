using System;
using System.Collections.Generic;

namespace PokemonFight.Web.EF;

public partial class Pokemon
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Tipo { get; set; }

    public double? Vida { get; set; }

    public string? Imagen { get; set; }

    public virtual ICollection<AtaquePokemon> AtaquePokemons { get; set; } = new List<AtaquePokemon>();
}
