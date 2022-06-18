using System.Collections.Generic;

namespace Battleship
{
    public class Player
    {
        private Board RegisterBoard = new Board();

        private Board ShipsBoard = new Board();

        public void PositionShips(IPrinter printer, IInputText inputText)
        {
            List<int> shipsSize = new List<int>{5,4,3,3,2};
            string coordinate = "";
            string direction = "";
            string response;

            foreach (int size in shipsSize)
            {   
                response = "";

                while (response != "El barco se creó correctamente")
                {
                    printer.Print(this.ShipsBoard.BoardToString());
                    printer.Print($"Ingrese la coordenada del extremo del barco con tamaño {size} (ej: 'A1'):");
                    coordinate = inputText.Input();
                    //coordinate = "E5";
                    printer.Print("Ingrese la orientación del barco ('up', 'down', 'left' or 'right'):");
                    direction = inputText.Input();
                    //direction = "up";

                    response = this.ShipsBoard.AddShip(size, coordinate, direction);
                    printer.Print(response);
                }
            }    
        }

        public Board GetShipsBoard()
        {
            return this.ShipsBoard;
        }

        public Board GetRegisterBoard()
        {
            return this.RegisterBoard;
        }

        public string GetBoardsToPrint()
        {
            string stringBoard = "Tablero con tus naves:\n";
            stringBoard += $"{this.ShipsBoard.BoardToString()}\n\n";
            stringBoard += "Tablero de registro de disparos:\n";
            stringBoard += $"{this.RegisterBoard.BoardToString()}\n";

            return stringBoard;
        }
    }
}