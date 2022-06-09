using System;
using System.Collections;
namespace BatallaNaval
{
    public class Cruiser : Ships
    {
        public static string name = "Cruiser";

        public Cruiser(int x, int y, int size, Orientation o) :base( x, y, size, o)
        {    
        }
    }
}