using PokemonFight.Data.EF;

namespace PokemonFight.Servicios
{
    public interface IPokemonServicio{

        List<Pokemon> listarPokemones();
        Pokemon obtenerPokemonPorNombre(string v);
    }
}