using System;

namespace Battleship
{
    public class ConsolePrinter: IPrinter
    {
        public void Print(string textToPrint)
        {
            Console.WriteLine(textToPrint);
        }
    }
}