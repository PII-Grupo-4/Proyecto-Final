using System.Collections.Generic;

namespace Battleship
{
    public class Game
    {
        private static int CounterId = 0;
        private int Id {get; set;}


        // private string GameSummary; // Cuando finalize la partida, aquí se guarda el resumen de la misma.
        

        private User User1;
        private User User2;

        private Player Player1 {get; set;}
        private Player Player2 {get; set;}

        public Game(User user1, User user2)
        {
            this.Id = CounterId;
            CounterId ++;

            this.User1 = user1;

            this.User2 = user2;

            this.Player1 = new Player(user1);

            this.Player2 = new Player(user2);
        }
        

        // Se posicionan los barcos, se ingresa como parametro numero del player que posicionará las naves.
        public void PositionShip (int playerNumber, int shipSize, string coordinates, string orientation)
        {
            if (playerNumber == 1)
            {
                Board boardPlayer = Player1.GetShipsBoard();
                
                boardPlayer.AddShip(shipSize, coordinates, orientation);
                
            }
            else if (playerNumber == 2)
            {

            }
            else
            {
                // Printer.AddText("El número de player es incorrecto, el barco no se ha colocado");
            }
        }
    }
}