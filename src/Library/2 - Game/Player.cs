using System.Collections.Generic;

namespace Battleship
{
    /// <summary>
    /// Player se utiliza como una extensión de User, contiene métodos y atributos
    /// particulares para jugar al juego Batalla Naval. Se creó para respetar el SRP, 
    /// de forma que no se sobrecarga a User de responsabilidades.
    /// Player está contenido en el User. Se crea cuando se crea un User y se reinicia
    /// su información cada vez que se inicia un juego.
    /// </summary>
    public class Player
    {
        private Board RegisterBoard = new Board();  // Tablero con el registro de ataques

        private Board ShipsBoard = new Board(); // Tablero con las naves del Player

        private bool Turn = false; // Representa si es o no el turno del Player

        // Lista con las habilidades del player representadas como string, solo se pueden usar una vez.
        // Cuandos se utiliza una habilidad determinada, la misma se elimina de la lista
        private List<string> specialHabilities = new List<string>{"air attack", "seer", "satellite photo"};
        
        /// <summary>
        /// Retorna el tablero con los barcos
        /// </summary>
        /// <returns>tablero con las naves</returns>
        public Board GetShipsBoard()
        {
            return this.ShipsBoard;
        }

        /// <summary>
        /// Retorna el tablero con el registro de disparos
        /// </summary>
        /// <returns>Tablero con el registro de disparos</returns>
        public Board GetRegisterBoard()
        {
            return this.RegisterBoard;
        }

        /// <summary>
        /// El método accede a ambos tableros de los barcos, los cuales contienen un método que
        /// retorna el tablero representado como una string (BoardToString()), luego une ambas string
        /// en una sola y la retorna.
        /// </summary>
        /// <returns>string con las dos representaciones de los tableros como string</returns>
        public string GetBoardsToPrint()
        {
            string stringBoard = "Tablero con tus naves:\n";
            stringBoard += $"{this.ShipsBoard.BoardToString()}\n\n";
            stringBoard += "Tablero de registro de disparos:\n";
            stringBoard += $"{this.RegisterBoard.BoardToString()}\n";

            return stringBoard;
        }


        /// <summary>
        /// El método accede al tablero con las naves a trávez del método GetShipsAlive,
        /// y retorna la información brindada por el método.
        /// Decidimos no acceder directamente al método del tablero para que el mismo
        /// tenga una mejor privacidad, y evitar que un Handler tenga acceso directo
        /// al tablero.
        /// </summary>
        /// <returns>El número de barcos vivos en el tablero con naves</returns>
        public int GetShipsAlive()
        {
            return ShipsBoard.GetShipsAlive();
        }

        /// <summary>
        /// Retorna un bool representado si es o no el turno del Player
        /// </summary>
        /// <returns>bool, Turno</returns>
        public bool GetTurn()
        {
            return this.Turn;
        }


        /// <summary>
        /// Se ingresa una string, correspondiente al nombre de una habilidad,
        /// y se elimina la misma de la lista de string con las representaciones de 
        /// las habilidades especiales
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

        /// <summary>
        /// Retorna la lista con las string que representa las habilidades especiales del usuario
        /// </summary>
        /// <returns>Lista con string que representan las habilidades especiales</returns>
        public List<string> GetSpecialsHabilities()
        {
           return specialHabilities;
        }

        /// <summary>
        /// Cambia el turno del jugador
        /// </summary>
        public void ChangeTurn()
        {
            if (this.Turn == false)
            {
                this.Turn = true;
            }
            else
            {
                this.Turn = false;
            }
        }
    }
}