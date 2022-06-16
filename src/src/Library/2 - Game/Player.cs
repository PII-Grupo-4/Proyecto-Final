
namespace Battleship
{
    public class Player
    {
        private User user {get; set;}

        private Board RegisterBoard = new Board();

        private Board ShipsBoard = new Board();

        public Player(User user)
        {
            this.user = user;

        }

        public User GetUser()
        {
            return this.user;
        }

        public Board GetShipsBoard()
        {
            return this.ShipsBoard;
        }

        public Board GetRegisterBoard()
        {
            return this.RegisterBoard;
        }
    }
}