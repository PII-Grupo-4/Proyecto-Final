using System.Collections.Generic;

namespace Battleship
{
    // La clase Games es una clase que contiene, brinda acceso y crea a los Games.
    public class Game
    {
        private static int CounterId = 0;
        private int Id {get; set;}


        // private string GameSummary; // Cuando finalize la partida, aquí se guarda el resumen de la misma.

        private User User1 {get; set;}
        private User User2 {get; set;}

        public Game(User user1, User user2)
        {
            this.Id = CounterId;
            CounterId ++;

            this.User1 = user1;

            this.User2 = user2;
        }

        public int GetId()
        {
            return this.Id;
        }
    }
}