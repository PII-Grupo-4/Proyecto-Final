using System.Collections.Generic;

namespace Battleship
{
    public class Player
    {
        private int GameId;
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

        // Retorna ambos barcos, prontos para
        public string GetBoardsToPrint()
        {
            string stringBoard = "Tablero con tus naves:\n";
            stringBoard += $"{this.ShipsBoard.BoardToString()}\n\n";
            stringBoard += "Tablero de registro de disparos:\n";
            stringBoard += $"{this.RegisterBoard.BoardToString()}\n";

            return stringBoard;
        }

        public void AddGameId(int Id)
        {
            this.GameId = Id;
        }

        public int GetGameId()
        {
            return this.GameId;
        }

        public int GetShipsAlive()
        {
            return ShipsBoard.GetShipsAlive();
        }
    }
}