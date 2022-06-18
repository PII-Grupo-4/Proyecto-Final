using System.Collections.Generic;

namespace Battleship
{
    public class Game
    {
        private static int CounterId = 0;
        private int Id {get; set;}


        // private string GameSummary; // Cuando finalize la partida, aquí se guarda el resumen de la misma.

        private User User1 {get; set;}
        private User User2 {get; set;}

        private User UserWinner;

        public Game(User user1, User user2)
        {
            this.Id = CounterId;
            CounterId ++;

            this.User1 = user1;

            this.User2 = user2;
        }

        public int GetId()
        {
            return this.Id;
        }

        public User GetOtherUserById(int id)
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
    }
}