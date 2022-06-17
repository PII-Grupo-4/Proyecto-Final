using System.Collections.Generic;

namespace Battleship
{
    public class Game
    {
        private static int CounterId = 0;
        private int Id {get; set;}


        // private string GameSummary; // Cuando finalize la partida, aquí se guarda el resumen de la misma.

        private Player Player1 {get; set;}
        private Player Player2 {get; set;}

        public Game(Player player1, Player player2)
        {
            this.Id = CounterId;
            CounterId ++;

            this.Player1 = player1;

            this.Player2 = player2;
        }

        public void StartGame()
        {
            
        }

    }
}