using System;
using System.Collections;
namespace BatallaNaval
{
    public class Destroyer : Ships
    {
        public static string name = "Destroyer";
        public static int size=2;

        public Destroyer(int x, int y, int size, Orientation o) :base( x, y, size, o)
        {    
        }
    }
}
