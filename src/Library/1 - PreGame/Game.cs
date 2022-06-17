using System.Collections.Generic;

namespace Battleship
{
    public class Game
    {
        private int ID {get; set;}

        private List<User> Users = new List<User>();

        private GameLogic gameLogic;

        public Game(int id)
        {
            this.ID = id;
        }

        public int GetID()
        {
            return this.ID;
        }


        public void AddUser(User user)
        {
            if (Users.Count < 2)
            {
                if (!(this.Users.Contains(user)))
                {
                    this.Users.Add(user);
                    // Printer.AddText($"El usuario {user.GetName()} se ha unido a la partida {this.ID}.");
                }
                else
                {
                    // Printer.AddText($"El usuario {user.GetName()} ya está en la partida {this.ID}.");
                }
            }
            else
            {
                // Printer.AddText($"el usuario no se agrega porque la partida está llena.");
            }
            
        }

        public int GetUsersQuantity()
        {
            return Users.Count; 
        }

        public GameLogic GetGameLogic()
        {
            if (gameLogic != null)
            {
                return this.gameLogic;
            }

            return null;
        }

        public void StartGame()
        {
            if (Users.Count == 2)
            {
                gameLogic = new GameLogic(this.Users[0], this.Users[1]);
            }
            else
            {
                // Printer.AddText("No se puede iniciar la partida porque no contiene dos jugadores.");
            }
        }

    }
}