using System;

namespace BatallaNaval
{
    public class Player
    {
        private int PlayerId;
        public string Nickname;

        public Player(string nickname)
        {
            Random randomId = new Random();
            this.Nickname = nickname;
            this.PlayerId = randomId.Next(0,100000);

        }
        public int GetPlayerId()
        {
            return this.PlayerId;
        }
    }
}
