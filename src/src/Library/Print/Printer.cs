using System;

namespace Battleship
{
    // Se carga un mensaje en Printer, y luego se activa el método correspondiente para imprimir en el medio deseado.
    // De esta forma respertamos el SRP, ya que la clase Printer es la única que se debe cambiar en caso de querer
    // imprimir en un nuevo medio.
    static public class Printer
    {
        static private string message = ""; 
        
        static public void ChangeMessage(string messageToPrint)
        {
            message = messageToPrint;
        }

        static public void AddText(string text)
        {
            message += $"\n{text}";
        }

        static public void InConsole()
        {
            Console.WriteLine(message);
            message = "";
        }

        static public void PrintBoardsInConsole(GameLogic gameLogic)
        {
            // AddText(game.GetBoardsToPrint(Player1))
            // InConsole();
            // AddText(game.GetBoardsToPrint(Player2))
            // InConsole();
        }
    }
}