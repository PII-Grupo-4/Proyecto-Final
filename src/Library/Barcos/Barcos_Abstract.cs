using System;
using System.Collections;

namespace BatallaNaval
{
    public abstract class Barcos_Abstract
    {
        public ArrayList poss = new ArrayList();
        private int Tamaño;
        private string Nombre;

        public Barcos_Abstract(string nombre, int tamaño, int pos1x, int pos1y, int pos2x, int pos2y){
            
            if ((Math.Max(pos1x,pos2x) - Math.Min(pos1x,pos2x)) < 1 && (Math.Max(pos1y,pos2y) - Math.Min(pos1y,pos2y)) < 1){
                Console.WriteLine("No es posible la creacion del barco puesto que las coordenadas no concuerdan con el tamaño del barco");
            }
            else if ((Math.Max(pos1x,pos2x) - Math.Min(pos1x,pos2x)) == (tamaño - 1) || (Math.Max(pos1y,pos2y) - Math.Min(pos1y,pos2y)) == (tamaño-1) )
            {
                this.Nombre = nombre;
                this.Tamaño = tamaño;
                this.poss.Add($"{pos1x},{pos1y}");
                this.poss.Add($"{pos2x},{pos2y}");
            }
            else{
                Console.WriteLine("No es posible la creacion del barco puesto que las coordenadas no concuerdan con el tamaño del barco");

            }
        }

    }
}