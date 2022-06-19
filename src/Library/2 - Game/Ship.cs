using System.Collections.Generic;

namespace Battleship
{
    public class Ship
    {
        private int Size{get; set;}

        private int Health{get; set;}  // Contiene la cantiadad de casillas sin disparar del barco

        private List<List<int>> Coordinates{get; set;} // Coordenadas sin disparar del barco

        private string Character{get; set;} //Character correspondiente al barco

        public Ship(int size)
        {
            this.Size = size;

            this.Health = size;

            // En base al tamaño, le asigna un caracter al barco
            if (size == 2)
            {
                this.Character = "D";
            }
            if (size == 3)
            {
                this.Character = "S";
            }
            if (size == 4)
            {
                this.Character = "B";
            }
            if (size == 5)
            {
                this.Character = "C";
            }

            Coordinates = new List<List<int>>{};
        }

        public string GetCharacter()
        {
            return this.Character;
        }

        public void AddCoordinate(int column, int row)
        {
            List<int> coordinate = new List<int>{column, row};
            this.Coordinates.Add(coordinate);
        }

        public List<List<int>> GetCoordinates()
        {
            return this.Coordinates;
        }

        public int GetHealth()
        {
            return this.Health;
        }

        public void DecreaseHealth()
        {
            this.Health --;
        }

        public int GetSize()
        {
            return this.Size;
        }

    }
}