using System;
using Battleship;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            // Se crean los usuarios para jugar
            UserRegister.CreateUser("Usuario1");
            Printer.InConsole();
            UserRegister.CreateUser("Usuario2");
            Printer.InConsole();

            // Se accede a los usuarios creados a travez del nombre
            User user1 = UserRegister.GetUserByName("Usuario1");
            User user2 = UserRegister.GetUserByName("Usuario2");

            Games.CreateGame(user1);
            Printer.InConsole();
            Game game1 = Games.GetGame(0);
            game1.AddUser(user2);
            Printer.InConsole();   

            int usersQuantity = game1.GetUsersQuantity();     
            Console.WriteLine(usersQuantity);

            game1.StartGame();
            GameLogic gameLogic1 = game1.GetGameLogic();

            gameLogic1.PositionShip(1, 2, "A1", "down");
            Printer.InConsole();
        }
    }
}
