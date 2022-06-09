using System;
using System.Collections;
namespace BatallaNaval
{
    public class Aircraft_Carrier : Ships
    {
        public static string name = "Aircraft carrier";

        public Aircraft_Carrier(int x, int y, int size, Orientation o) :base( x, y, size, o)
        {    
        }
    }
}