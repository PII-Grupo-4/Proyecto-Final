using System;
using Battleship;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            IPrinter printer = new ConsolePrinter();
            IInputText inputText = new ConsoleInputText();

            User user1 = new User("user1");
            User user2 = new User("user1");
            
            Lobby.AddUser(user1);
            Lobby.AddUser(user2);

            Player player1 = new Player(user1);
            Player player2 = new Player(user2);
            
            Game game = new Game(player1, player2);
            player1.PositionShips(printer, inputText);

            Board board = player1.GetShipsBoard();
            string boardString = board.BoardToString();

            printer.Print(boardString);
        }


        static void CreateUserHandlesTest()
        {
                IHandler UsersHandler = 
                new CreateUserHandle(new RemoveUserHandle(null));
            
            Message message = new Message();
            string response;

            while (true)
            {
                Console.WriteLine("\nIngrese uno de los siguientes comandos:\n -crear usuario\n -eliminar usuario\n -jugar\n -salir");
                Console.Write("> ");

                message.Text = Console.ReadLine();
                if (message.Text.Equals("salir", StringComparison.InvariantCultureIgnoreCase))
                {
                    Console.WriteLine("Salimos");
                    return;
                }

                IHandler result = UsersHandler.Handle(message, out response);

                if (result == null)
                {
                    Console.WriteLine("No entiendo");
                }
                else
                {
                    Console.WriteLine(response);
                }
            }
        }
    }
}
