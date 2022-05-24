using System;
using System.Collections;

namespace BatallaNaval
{
    public abstract class Ships
    {
        public ArrayList cord = new ArrayList();
        private int Size;
        private string Name;

        public Ships(string name, int size, int pos1x, int pos1y, int pos2x, int pos2y){
            
            if ((Math.Max(pos1x,pos2x) - Math.Min(pos1x,pos2x)) < 1 && (Math.Max(pos1y,pos2y) - Math.Min(pos1y,pos2y)) < 1){
                Console.WriteLine("No es posible la creacion del barco puesto que las coordenadas no concuerdan con el tamaño del barco");
            }
            else if ((Math.Max(pos1x,pos2x) - Math.Min(pos1x,pos2x)) == (size - 1) || (Math.Max(pos1y,pos2y) - Math.Min(pos1y,pos2y)) == (size-1) )
            {
                this.Name = name;
                this.Size = size;
                this.cord.Add($"{pos1x},{pos1y}");
                this.cord.Add($"{pos2x},{pos2y}");
            }
            else{
                Console.WriteLine("No es posible la creacion del barco puesto que las coordenadas no concuerdan con el tamaño del barco");

            }
        }

    }
}