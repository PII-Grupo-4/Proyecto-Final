using System;

namespace Battleship
{
    public class ConsoleInputText: IInputText
    {
        public string Input()
        {
            return Console.ReadLine();
        }
    }
}