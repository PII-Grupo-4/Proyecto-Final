using System;
using System.Collections;
namespace BatallaNaval
{
    public class Battleship : Ships
    {
        public static string name = "Battleship";

        public Battleship(int x, int y, int size, Orientation o) :base( x, y, size, o)
        {    
        }
    }
}