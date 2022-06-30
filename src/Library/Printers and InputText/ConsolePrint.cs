using System;

namespace Battleship
{
    public class ConsolePrinter: IPrinter
    {
        public void Print(string textToPrint, long id)
        {
            Console.WriteLine(textToPrint);
        }
    }
}