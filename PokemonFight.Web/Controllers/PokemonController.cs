using Microsoft.AspNetCore.Mvc;
using PokemonFight.Data.EF;
using PokemonFight.Servicios;

namespace PokemonFight.Web.Controllers
{
    public class PokemonController : Controller {

        private IPokemonServicio pokemonServicio;

        public PokemonController(IPokemonServicio pokemonServicio) {
            this.pokemonServicio = pokemonServicio;
        }

        public IActionResult elegirPokemon() {
            return View(pokemonServicio.listarPokemones());
        }

        [HttpPost]
        public string batalla(string nombre, string nombre2) {
            HttpContext.Session.SetString("nombre",nombre);
            HttpContext.Session.SetString("nombre2",nombre2);
            return nombre + " " + nombre2;
        }

        public IActionResult batallas(){
            List<Pokemon> pokemonesObtenidos = new List<Pokemon>();
            pokemonesObtenidos.Add(pokemonServicio.obtenerPokemonPorNombre(HttpContext.Session.GetString("nombre")));
            pokemonesObtenidos.Add(pokemonServicio.obtenerPokemonPorNombre(HttpContext.Session.GetString("nombre2")));
            return View(pokemonesObtenidos);

        }



    }
}
