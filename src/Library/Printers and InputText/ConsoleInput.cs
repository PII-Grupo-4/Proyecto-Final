using System;

namespace Battleship
{
    public class ConsoleInputText: IInputText
    {
        public void Print(string textToPrint)
        {
            Console.WriteLine(textToPrint);
        }
    }
}