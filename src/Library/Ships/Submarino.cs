using System;
using System.Collections;
namespace BatallaNaval
{
    public class Submarino : Ships
    {
        public static string nombre = "Submarino";

        public Submarino(int p1x, int p1y, int p2x, int p2y) :base(nombre, 3, p1x, p1y, p2x, p2y)
        {    
        }
    }
}