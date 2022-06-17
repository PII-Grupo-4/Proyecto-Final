using System;
using System.Collections.Generic;

namespace Battleship
{
    public static class Logic
    {
        static List<string> Row = new List<string>{"A", "B", "C", "D", "E", "F", "G", "H", "I", "J"};
        static List<string> Column = new List<string>{"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"};

        public static string Ataque(string coordinate, Board RegisterBoard, Board BoardWithShips)
        {

            return "";
        }

        // FixCoordinate recibe una coordenada en forma de string (ej "A3") y la transforma en una lista de dos int.
        public static List<int> FixCoordinate(string coordinate)
        {
            List<int> coordinateList = new List<int>();
            string coordinateString;
            int coordinate1;
            int coordinate2;

            try
            {
                coordinateString = coordinate.Substring(0, 1);
                coordinate1 = Row.IndexOf(coordinateString.ToUpper()) + 1;

                if (coordinate1 == 0) //Si la letra no se encuentra entre la A y la J, IndexOf devuelve -1 (-1+1=0)
                {
                    return coordinateList;
                }
                
                try
                {
                    if (coordinate.Substring(1, 2) == "10")
                    {
                        coordinate2 = 10;
                    }
                    else
                    {
                        throw new Exception();
                    }  
                }
                catch
                {
                    coordinateString = coordinate.Substring(1, 1);
                    coordinate2 = Column.IndexOf(coordinateString) + 1;

                    if (coordinate2 < 1)
                    {
                        return coordinateList;
                    }
                }

                coordinateList.Add(coordinate1);
                coordinateList.Add(coordinate2);

                return coordinateList;

                
            }
            catch
            {
                    return coordinateList;
            }
        }
    }
}