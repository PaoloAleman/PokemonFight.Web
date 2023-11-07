namespace PokemonFight.Web.Models
{
    public class Turno
    {
        private static int contadorturno = 1;
        public int contador => contadorturno;
        public String mensaje = "todavia no es tu turno";


        public Turno()
        {
            contadorturno++;

        }
    }
}

