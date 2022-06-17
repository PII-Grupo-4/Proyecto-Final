using System;
using System.Collections.Generic;

namespace Battleship
{
    // Board es un array de strings de dos dimensiones, cada elemento contiene una de las 4 string posibles.
    // o = lugar sin disparar
    // - = agua
    // x = tocado
    // # = hundido
    // BARCOS:
    // C = Carrier (5)
    // B = Battleship (4)
    // S = Submarine (3) (Hay dos submarinos)
    // D = Destroyer (2)
    public class Board
    {
        private string[,] board = new string[10,10];

        private List<Ship> ShipsList = new List<Ship>{};

        static List<string> Row = new List<string>{"A", "B", "C", "D", "E", "F", "G", "H", "I", "J"};
        static List<string> Column = new List<string>{"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"};

        static List<string> Orientations = new List<string>{"UP", "DOWN", "LEFT", "RIGHT"};

        public Board()
        {
            // lleno el tablero de "o"
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    board[i,j] = "o";
                }
            }
        }

        public int GetShipsAlive()
        {
            return this.ShipsList.Count;
        }

        public void AddShip(int size, string coordinate, string direction)
        {
            try
            {
                if (this.ShipsList.Count >= 5)
                {
                    // Printer.AddText("No se puede agregar más barcos (El tablero ya esta lleno).");
                    throw new Exception();
                }
                
                if ((size < 2) || (size > 5))
                {
                    // Printer.AddText("Tamaño de barco incorrecto.");
                    throw new Exception();
                }

                direction = direction.ToUpper();
                if (!Orientations.Contains(direction))
                {
                    // Printer.AddText("Dirección incorrecta, ingrese una de las siguientes: \nUp\nDown\nLeft\nRight");
                    throw new Exception();
                }

                List<int> coordinateList = FixCoordinate(coordinate);

                if (coordinateList == (new List<int>{}))
                {
                    // Printer.AddText("La coordenada indicada no es correcta. Por favor ingrese una coordenda del tipo 'LetraNumero' (ej: A1).");
                    throw new Exception();
                }

                bool ShipBool = Position_Ship(size, coordinateList, direction);

                if (ShipBool == false)
                {
                    throw new Exception();
                }
                else
                {
                    // Printer.AddText("El barco se creó correctamente");
                    return;
                }

            }
            catch
            {
                // Printer.AddText("Datos incorrectos, el barco no se creó.");
            }
            
        }


        // FixCoordinate recibe una coordenada en forma de string (ej "A3") y la transforma en una lista de dos int.
        public List<int> FixCoordinate(string coordinate)
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


        private bool Position_Ship(int size, List<int> coordinateList, string direction)
        {
            int directionInt = 1;
            if (direction == "UP" || direction == "LEFT") {directionInt = -1; }
            
            int c1 = coordinateList[0];
            int c2 = coordinateList[1];

            try
            {
                // Para la orientación vertical
                if (direction == "UP" || direction == "DOWN")
                {
                    // Verifico que las coordenadas esten dentro del tablero y no haya otro barco
                    for (int i = c2; i < (c2+size); i += directionInt)
                    {
                        string boardCoordinate = this.board[c1, i];
                        if (boardCoordinate != "o")
                        {
                            // Printer.AddText("Ya existe un barco en las coordenadas indicadas.");
                            throw new Exception();
                        }
                    }

                    // Una vez verificado, coloco el barco

                    Ship ship = new Ship(size);
                    for (int i = c2; i < (c2+size); i += directionInt)
                    {
                        string boardCoordinate = this.board[c1, i];
                        boardCoordinate = $"{ship.GetCharacter()}";
                        ship.AddCoordinate(c1, i);
                    }
                }
                // Para la orientación horizontal
                else
                {
                    // Verifico que las coordenadas esten dentro del tablero y no haya otro barco
                    for (int i = c1; i < (c1+size); i += directionInt)
                    {
                        string boardCoordinate = this.board[i, c2];
                        if (boardCoordinate != "o")
                        {
                            // Printer.AddText("Ya existe un barco en las coordenadas indicadas.");
                            throw new Exception();
                        }
                    }

                    // Una vez verificado, coloco el barco

                    Ship ship = new Ship(size);
                    for (int i = c1; i < (c1+size); i += directionInt)
                    {
                        string boardCoordinate = this.board[i, c2];
                        boardCoordinate = $"{ship.GetCharacter()}";
                        ship.AddCoordinate(i, c2);
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}