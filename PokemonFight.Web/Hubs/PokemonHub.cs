using Microsoft.AspNetCore.Http;
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

            Pokemon pokemon = pokemonServicio.obtenerPokemonPorAtaque(int.Parse(value));

            string pokemonAtacado= definirPokemonAtacado(pokemon.Nombre);

            string pokemonAtacante = pokemon.Nombre;
            double? vidaPokemon=pokemon.Vida;
            
            await Clients.All.SendAsync("atacado", daño,pokemonAtacado,pokemonAtacante,vidaPokemon);
        }

        private string definirPokemonAtacado(string pokemon){
            var httpContext = Context.GetHttpContext();
            if (pokemon.Equals(httpContext.Session.GetString("nombre"))){
                pokemon= httpContext.Session.GetString("nombre2");
            }else{
                pokemon= httpContext.Session.GetString("nombre");
            }

            return pokemon;
        }


    }
}
