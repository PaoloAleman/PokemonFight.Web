using System;
using System.Collections.Generic;

namespace PokemonFight.Data.EF;

public partial class AtaquePokemon
{
    public int Id { get; set; }

    public int? IdPokemon { get; set; }

    public int? IdAtaque { get; set; }

    public virtual Ataque? IdAtaqueNavigation { get; set; }

    public virtual Pokemon? IdPokemonNavigation { get; set; }
}
