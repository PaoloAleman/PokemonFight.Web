using Microsoft.EntityFrameworkCore;
using PokemonFight.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonFight.Servicios
{
    public class PokemonServicio : IPokemonServicio
    {

        private PokemonFightContext _context;

        public PokemonServicio(PokemonFightContext context)
        {
            _context = context;
        }

        public List<Pokemon> listarPokemones()
        {
            return _context.Pokemons.ToList();
        }

        public Ataque obtenerAtaquePorId(int value)
        {
            return _context.Ataques.FirstOrDefault(a => a.Id == value);
        }

        public Pokemon obtenerPokemonPorAtaque(int idAtaque)
        {
            return _context.Pokemons.FirstOrDefault(p => p.AtaquePokemons.Any(ap => ap.IdAtaque == idAtaque));
        }

        public Pokemon obtenerPokemonPorNombre(string v)
        {
            return _context.Pokemons.
                Include(p => p.AtaquePokemons).ThenInclude(p => p.IdAtaqueNavigation).
                FirstOrDefault(p => p.Nombre == v);
        }


    }
}
