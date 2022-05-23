using System;
using System.Collections;
namespace BatallaNaval
{
    public class Destroyer : Ships
    {
        public static string name = "Destroyer";

        public Destroyer(int p1x, int p1y, int p2x, int p2y) :base(name, 3, p1x, p1y, p2x, p2y)
        {    
        }
    }
}
