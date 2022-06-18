using System.Collections.Generic;

namespace Battleship
{
    public class Player
    {
        private Board RegisterBoard = new Board();

        private Board ShipsBoard = new Board();

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