using System.Collections.Generic;

namespace Battleship
{
    public class Player
    {
        private int GameId;
        private Board RegisterBoard = new Board();

        private Board ShipsBoard = new Board();

        // Habilidades del player, solo se pueden usar una vez.
        private List<string> specialHabilities = new List<string>{"air attack", "seer", "satellite photo"};

        public Board GetShipsBoard()
        {
            return this.ShipsBoard;
        }

        public Board GetRegisterBoard()
        {
            return this.RegisterBoard;
        }

        /// <summary>
        /// Retorna ambos tableros como string, prontos para imprimir
        /// </summary>
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

        /// <summary>
        /// "air attack", "seer", "satellite photo"
        /// </summary>
        /// <param name="hability"></param>
        public void UseHability(string hability)
        {
            foreach (string habili in this.specialHabilities)
            {
                if (habili == hability)
                {
                    this.specialHabilities.Remove(habili);
                    break;
                }  
            }
        }

        public List<string> GetSpecialsHabilities()
        {
           return specialHabilities;
        }
    }
}