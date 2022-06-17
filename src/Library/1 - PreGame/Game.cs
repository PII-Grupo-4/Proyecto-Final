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


        public string AddUser(User user)
        {
            if (Users.Count < 2)
            {
                if (!(this.Users.Contains(user)))
                {
                    this.Users.Add(user);
                    return $"El usuario {user.GetName()} se ha unido a la partida {this.ID}.";
                }
                else
                {
                    return $"El usuario {user.GetName()} ya está en la partida {this.ID}.";
                }
            }
            else
            {
                return "el usuario no se agrega porque la partida está llena.";
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

        public string StartGame()
        {
            if (Users.Count == 2)
            {
                gameLogic = new GameLogic(this.Users[0], this.Users[1]);
                return "Partida iniciada";
            }
            else
            {
                return "No se puede iniciar la partida porque no contiene dos jugadores.";
            }
        }

    }
}