using System;
using System.Collections;


namespace BatallaNaval
{
    public abstract class Ships
    {
        public ArrayList cord = new ArrayList();

        private int x;
        private int y;
        private int Size;
        private string Name;

        private Orientation o;
         private int[] plage;


         public Ships(int x, int y, int size, Orientation o)
        {
            this.x = x;
            this.y = y;
            this.Size = size;
            this.o = o;
            this.plage = new int[this.Size];
            for (int i = 0; i < this.Size; i++)
            {
                if (o == Orientation.Horizontal)
                    plage[i] = this.x + i;
                else
                    plage[i] = this.y + i;
            }
        }

        
        public bool IsAtCoordinates(int x, int y)
        {
            if (o == Orientation.Horizontal)
            {
                return (y == this.y && this.plage.Contains(x));
            }
            else
            {
                return (x == this.x && this.plage.Contains(y));
            }
        }

        public int GetCoordinateX()
        {
            return x;
        }
        public int GetCoordinateY()
        {
            return y;
        }
        public int[] GetPlage()
        {
            return plage;
        }
        public int GetSize()
        {
            return Size;
        }
        public Orientation GetOrientation()
        {
            return o;
        }


    }
}