using System;
using System.Collections;
namespace BatallaNaval
{
    public class Cruiser : Ships
    {
        public static string name = "Cruiser";
        public static int size=3;

        public Cruiser(int x, int y, int size, Orientation o) :base( x, y, size, o)
        {    
        }
    }
}