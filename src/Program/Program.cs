using System;
using Battleship;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
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
