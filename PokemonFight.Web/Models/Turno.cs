namespace PokemonFight.Web.Models
{
    public class Turno
    {
        public static int contador =0;
        public String mensaje = "todavia no es tu turno";


        public Turno()
        {
            

        }
     
        public void Contar() { contador++; }

        public int getContador() { return contador; }
    }
}

