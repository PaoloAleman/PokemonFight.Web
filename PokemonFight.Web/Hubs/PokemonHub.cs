using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PokemonFight.Data.EF;
using PokemonFight.Servicios;

namespace PokemonFight.Web.Hubs{
    public class PokemonHub : Hub{

        private IPokemonServicio pokemonServicio;

        public PokemonHub(IPokemonServicio pokemonServicio){
            this.pokemonServicio = pokemonServicio;
            
        }

        public async Task enviarPokemon(string pokemon){
            //Mostramos el pokemon ya seleccionado
            await Clients.All.SendAsync("pokemonEnviado", pokemon);
        }

        public async Task redirigir(List<string> pokemonesObtenidos){
            await Clients.All.SendAsync("redireccion",pokemonesObtenidos);
        }

        public async Task atacarPokemon(string value){
            double? daño = pokemonServicio.obtenerAtaquePorId(int.Parse(value)).Daño;
            string nombrePokemon = pokemonServicio.obtenerPokemonPorAtaque(int.Parse(value)).Nombre;
            var httpContext = Context.GetHttpContext();
            string pokemonAtacado="";
            if (nombrePokemon.Equals(httpContext.Session.GetString("nombre"))) {
                pokemonAtacado = httpContext.Session.GetString("nombre2");
            }else {
                pokemonAtacado = httpContext.Session.GetString("nombre");
            }
            await Clients.All.SendAsync("atacado", daño,pokemonAtacado);
        }


    }
}
