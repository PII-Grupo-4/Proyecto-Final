using System;

namespace BatallaNaval
{
    public class Jugador
    {
        private int playerId;
        public string Name;

        public Jugador(string name)
        {
            Random randomId = new Random();
            this.Name = name;
            this.playerId = randomId.Next(0,100000);

        }
        public int GetPlayerId()
        {
            return this.playerId;
        }
    }
}
