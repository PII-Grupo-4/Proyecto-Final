
namespace Battleship
{
    public class User
    {
        private static int UserID_counter = 0;
        private string Name {get; set; } 
        private int Id {get; set; } 
        private string Status; // Estado del usuario, se usa para los handles
        private string TextToPrint = "";
        // TextToPrint Se utiliza para cuando se debe imprimir un mensaje pero es el turno del 
        // contricante. Por lo que cuando llegue su turno, se imprime.

        private Player player = new Player();

        private string GameMode; // Modo de juego que el jugador selecciona

        public User(string name)
        {
            this.Name = name;

            this.Id = UserID_counter;
            UserID_counter ++;

            this.Status = "start";
        }


        public string GetName()
        {
            return this.Name;
        }         

        public int GetID()
        {
            return this.Id;
        } 

        public string getStatus()
        {
            return this.Status;
        }

        public Player GetPlayer()
        {
            return this.player;
        }

        /// <summary>
        /// User Status: 1=start | 2=lobby | 3=position ships | 4=in game
        /// start: Antes de empezar
        /// Lobby: A la espera del rival
        /// Position ships: Juego creado, posicionando barcos
        /// In game: Jugando
        /// </summary>
        /// <param name="StatusNumber">int número correspondiente al nuevo estado</param>
        public void ChangeStatus(string status)
        {
            this.Status = status;
        }

        /// <summary>
        /// Reinicia al Player para un nuevo juego
        /// </summary>
        public void RestartPlayer()
        {
            this.player = new Player();
        }

        public string GetTextToPrint()
        {
            return this.TextToPrint;
        }
        /// <summary>
        /// Cuando es el turno de un usuario, la response de los handlers la imprime para este, 
        /// cuando queremos que se imprima para el otro usuario, modificamos 
        /// TextToPrint, y cuando es el turno de este segundo usuario, se imprime el mismo
        /// </summary>
        /// <param name="text"> texto a imprimir</param>
        public void ChangeTextToPrint(string text)
        {
            this.TextToPrint = text;
        }
        /// <summary>
        /// Obtener el modo de juego
        /// </summary>
        /// <returns>Modo de juego</returns>
        public string GetGameMode()
        {
            return this.GameMode;
        }
        /// <summary>
        /// Cambiar el modo de juego
        /// </summary>
        /// <param name="gameMode">Modo de juego al que queremos cambiarnos</param>
        public void ChangeGameMode(string gameMode)
        {
            this.GameMode = gameMode;
        }
    }
}