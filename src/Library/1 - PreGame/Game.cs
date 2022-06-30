using System.IO;
using System.Collections.Generic;

namespace Battleship
{
    // La clase Games es una clase que contiene, brinda acceso y crea los Games.
    public class Game
    {
        private int Id {get; set;}

        private User User1 {get; set;}
        private User User2 {get; set;}

        private User UserWinner;

        public Game(User user1, User user2)
        {
            this.Id = CounterId();

            this.User1 = user1;

            this.User2 = user2;
        }

        public int GetId()
        {
            return this.Id;
        }

        /// <summary>
        /// Método para tener una permanencia de la id de los juegos
        /// </summary>
        private int CounterId()
        {
            int counterId;
            try
            {
                counterId = int.Parse(File.ReadAllText("CounterIdGame.txt"));
            }
            catch
            {
                counterId = 0;
            }

            int newCounterId = counterId + 1;

            StreamWriter writetext = new StreamWriter("CounterIdGame.txt", false);
            writetext.WriteLine($"{newCounterId}");
            writetext.Close();

            return counterId;
        }

        /// <summary>
        /// Se ingresa la id de un usuario, y se retorna el otro usuario
        /// </summary>
        /// <param name="id">id del usuario</param>
        /// <returns>el otro usuario</returns>
        public User GetOtherUserById(long id)
        {
            if (User1.GetID() == id)
            {
                return User2;
            }
            else if (User2.GetID() == id)
            {
                return User1;
            }
            else
            {
                return null;    
            }
        }

        public void AddUserWinner(User user)
        {
            this.UserWinner = user;
        }

        public string GameInString()
        {
            string summary = $"Game id = {this.Id}\n";
            summary += $"User 1 id= {User1.GetID()}";
            summary += $" - Ships alive = {User1.GetPlayer().GetShipsAlive()}\n";
            summary += $"User 2 id= {User1.GetID()}";
            summary += $" - Ships alive = {User2.GetPlayer().GetShipsAlive()}\n";
            summary += $"Winner = {UserWinner.GetID()}\n";
            return summary;
        }

        // Retorna una lista con las id de ambos usuarios
        public List<long> GetUsersId()
        {
            List<long> usersId = new List<long>{this.User1.GetID(), this.User2.GetID()};

            return usersId;
        }
    }
}