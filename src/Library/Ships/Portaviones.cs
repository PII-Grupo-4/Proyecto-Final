using System;
using System.Collections;
namespace BatallaNaval
{
    public class Portaviones : Ships
    {
        public static string nombre = "Portaviones";

        public Portaviones(int p1x, int p1y, int p2x, int p2y) :base(nombre, 3, p1x, p1y, p2x, p2y)
        {    
        }
    }
}