
namespace Battleship
{
    public class User
    {
        static int UserID_counter = 0;
        private string Name {get; set; } 
        private int Id {get; set; } 
        private string Status; // Estado del usuario, se usa para los handles
        private string TextToPrint = "";
        // TextToPrint Se utiliza para cuando se debe imprimir un mensaje pero es el turno del 
        // contricante. Por lo que cuando llegue su turno, se imprime.

        private Player player = new Player();

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
        /// 1=start | 2=lobby | 3=position ships | 4=in game
        /// </summary>
        /// <param name="StatusNumber">int numero correspondiente al nuevo estado</param>
        public void ChangeStatus(int StatusNumber)
        {
            if (StatusNumber == 1)
            {
                this.Status = "start";
            }
            else if (StatusNumber == 2)
            {
                this.Status = "lobby";
            }
            else if (StatusNumber == 3)
            {
                this.Status = "position ships";
            }
            else if (StatusNumber == 4)
            {
                this.Status = "in game";
            }
        }

        // Reinicia al Player para un nuevo juego
        public void RestartPlayer()
        {
            this.player = new Player();
        }


        public string GetTextToPrint()
        {
            return this.TextToPrint;
        }
        public void ChangeTextToPrint(string text)
        {
            this.TextToPrint = text;
        }
    }
}