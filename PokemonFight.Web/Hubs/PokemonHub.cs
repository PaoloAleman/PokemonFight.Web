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


    }
}
