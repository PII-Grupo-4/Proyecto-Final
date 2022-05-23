using System;

namespace BatallaNaval
{
    public class Player
    {
        private int Idjugador;
        public string Nombre;

        public Player(string nombre)
        {
            Random randomId = new Random();
            this.Nombre = nombre;
            this.Idjugador = randomId.Next(0,100000);

        }
        public int GetPlayerId()
        {
            return this.Idjugador;
        }
    }
}
