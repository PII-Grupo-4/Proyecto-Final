using System;
using System.Collections;
namespace BatallaNaval
{
    public class Aircraft_Carrier : Ships
    {
        public static string name = "Aircraft carrier";

        public Aircraft_Carrier(int p1x, int p1y, int p2x, int p2y) :base(name, 3, p1x, p1y, p2x, p2y)
        {    
        }
    }
}