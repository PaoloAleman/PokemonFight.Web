using PokemonFight.Data.EF;

namespace PokemonFight.Servicios
{
    public interface IPokemonServicio{

        List<Pokemon> listarPokemones();
        Ataque obtenerAtaquePorId(int value);
        Pokemon obtenerPokemonPorAtaque(int idAtaque);
        Pokemon obtenerPokemonPorNombre(string v);
   
    }
}