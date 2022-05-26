using System;
using System.Collections;
namespace BatallaNaval
{
    public class Submarine : Ships
    {
        public static string name = "Submarine";

        public Submarine(int p1x, int p1y, int p2x, int p2y) :base(name, 3, p1x, p1y, p2x, p2y)
        {    
        }
    }
}