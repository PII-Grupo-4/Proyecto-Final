using System.Collections.Generic;

namespace Battleship
{
    public class Ship
    {
        private int Size;

        private int Health;

        private List<List<int>> Coordinates;

        private string Character;

        public Ship(int size)
        {
            this.Size = size;

            this.Health = size;

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

    }
}