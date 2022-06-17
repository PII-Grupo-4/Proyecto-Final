
namespace Battleship
{
    public class GameLogic
    {
        private string GameSummary; // Cuando finalize la partida, aquí se guarda el resumen de la misma.

        private Player Player1 {get; set;}
        private Player Player2 {get; set;}

        public GameLogic(User user1, User user2)
        {
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



        public void Logic()
        {

        }

    }
}