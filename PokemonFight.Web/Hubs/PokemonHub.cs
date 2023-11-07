using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PokemonFight.Data.EF;
using PokemonFight.Servicios;
using PokemonFight.Web.Models;
using System.Diagnostics.Eventing.Reader;

namespace PokemonFight.Web.Hubs
{
    public class PokemonHub : Hub
    {

        private IPokemonServicio pokemonServicio;

        public PokemonHub(IPokemonServicio pokemonServicio)
        {
            this.pokemonServicio = pokemonServicio;

        }

        public async Task enviarPokemon(string pokemon)
        {
            //Mostramos el pokemon ya seleccionado
            await Clients.All.SendAsync("pokemonEnviado", pokemon);
        }

        public async Task redirigir(List<string> pokemonesObtenidos)
        {
            await Clients.All.SendAsync("redireccion", pokemonesObtenidos);
        }

        public async Task atacarPokemon(string value)
        {
            double? daño = pokemonServicio.obtenerAtaquePorId(int.Parse(value)).Daño;

            Pokemon pokemon = pokemonServicio.obtenerPokemonPorAtaque(int.Parse(value));

            string pokemonAtacado = definirPokemonAtacado(pokemon.Nombre);
            if (pokemonAtacado == "no es tu turno") { }
            else
            {
                string pokemonAtacante = pokemon.Nombre;
                double? vidaPokemon = pokemon.Vida;


                var mensaje = new Chat
                {
                    Usuario = Context.ConnectionId,
                    Accion = "Ataque",
                    Habilidad = pokemonServicio.obtenerAtaquePorId(int.Parse(value)).Nombre,
                    Danio = daño.Value
                };

                await Clients.All.SendAsync("atacado", daño, pokemonAtacado, pokemonAtacante, vidaPokemon, mensaje);
            }
        }

        private string definirPokemonAtacado(string pokemon)
        {
            var httpContext = Context.GetHttpContext();
            var turno = new Turno();  
            if (pokemon.Equals(httpContext.Session.GetString("nombre"))&&turno.getContador()%2==0)
            {
                pokemon = httpContext.Session.GetString("nombre2");
                turno.Contar();
            }
            else
            if (pokemon.Equals(httpContext.Session.GetString("nombre2"))&&turno.getContador() % 2 != 0)
            {
                pokemon = httpContext.Session.GetString("nombre");
                turno.Contar();
            }
            else { pokemon = "no es tu turno"; }

            return pokemon;
        }



    }
}