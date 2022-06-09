using System;
using System.Collections;
namespace BatallaNaval
{
    public class Submarine : Ships
    {
        public static string name = "Submarine";
        public static int size=1;

        public Submarine(int x, int y, int size, Orientation o) :base( x, y, size, o)
        {    
        }
    }
}