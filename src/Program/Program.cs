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

            printer.Print("Ingrese el nombre del primer usuario");
            string userName1 = inputText.Input();
            printer.Print("Ingrese el nombre del segundo usuario");
            string userName2 = inputText.Input();

            User user1 = new User(userName1);
            User user2 = new User(userName2);

            UserRegister.AddUser(user1);
            UserRegister.AddUser(user2);

            IHandler handler = new CommandsHandle(
                new ChangeTurnHandle(
                new SearchGameHandler(
                new ExitLobbyHandle(
                new SeeBoardsHandle(
                new PositionShipsHandle(
                new AttackHandle(null,  printer, inputText), 
                printer, inputText)
                )))));
                
            Message message = new Message();
            string response;
            message.Turn = 1;
            User nextUser;

            while (true)
            {
                if (message.Turn == 1)
                {
                    nextUser = user1;
                }
                else
                {
                    nextUser = user2;
                }

                printer.Print($"Usuario {nextUser.GetName()}. Escriba un comando, 'comandos' (para ver comandos y estado) o 'salir':");
                printer.Print("> ");

                message.id = nextUser.GetID();
                message.Text = inputText.Input();
                if (message.Text.Equals("salir", StringComparison.InvariantCultureIgnoreCase))
                {
                    printer.Print("Salimos");
                    return;
                }

                IHandler result = handler.Handle(message, out response);

                if (result == null)
                {
                    printer.Print("No entiendo\n");
                }
                else
                {
                    printer.Print(response+"\n");
                }
            }
        }

        static void Pruebas()
        {

        }

    }
}
