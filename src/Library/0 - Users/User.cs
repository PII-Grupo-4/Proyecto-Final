
namespace Battleship
{
    public class User
    {
        private long Id {get; set; } 
        private string Status; // Estado del usuario, se usa para los handles

        private Player player = new Player();

        private string GameMode; // Modo de juego que el jugador selecciona

        private bool Turn = false;

        public User(long id)
        {
            this.Id = id;

            this.Status = "start";
        }
       

        public long GetID()
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

        public bool GetTurn()
        {
            return this.Turn;
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