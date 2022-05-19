using System;

namespace BatallaNaval
{
    public class Jugador
    {
        private int Idjugador;
        public string Nombre;

        public Jugador(string nombre)
        {
            Random randomId = new Random();
            this.Nombre = nombre;
            this.Idjugador = randomId.Next(0,100000);

        }
        public int ObtenerIdJugador()
        {
            return this.Idjugador;
        }
    }
}
