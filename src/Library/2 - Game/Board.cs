using System;
using System.Collections.Generic;

namespace Battleship
{
    // Board es un array de strings de dos dimensiones, cada elemento contiene una de las 4 string posibles.
    // - = lugar sin disparar
    // o = agua
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

        static List<string> Orientations = new List<string>{"UP", "DOWN", "LEFT", "RIGHT"};

        public Board()
        {
            // lleno el tablero de "o"
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    board[i,j] = "-";
                }
            }
        }

        public int GetShipsAlive()
        {
            return this.ShipsList.Count;
        }

        public string AddShip(int size, string coordinate, string direction)
        {
            string response = "";

            try
            {
                if (this.ShipsList.Count >= 5)
                {
                    return "No se puede agregar más barcos (El tablero ya esta lleno).";
                    throw new Exception();
                }
                
                if ((size < 2) || (size > 5))
                {
                    return "Tamaño de barco incorrecto.";
                    throw new Exception();
                }

                List<int> coordinateList = Logic.FixCoordinate(coordinate);

                if (coordinateList == (new List<int>{}))
                {
                    return "La coordenada indicada no es correcta. Por favor ingrese una coordenda del tipo 'LetraNumero' (ej: A1).";
                    throw new Exception();
                }

                direction = direction.ToUpper();
                if (!Orientations.Contains(direction))
                {
                    return "Dirección incorrecta, ingrese una de las siguientes: \nUp\nDown\nLeft\nRight";
                    throw new Exception();
                }                

                bool ShipBool = Position_Ship(size, coordinateList, direction);

                if (ShipBool == false)
                {
                    throw new Exception();
                }
                else
                {
                    return "El barco se creó correctamente";
                }

            }
            catch
            {
                return response + "Datos incorrectos, el barco no se creó.";
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
                if (direction == "RIGHT")
                {
                    // Verifico que las coordenadas esten dentro del tablero y no haya otro barco
                    for (int i = c2; i < (c2+size); i += 1)
                    {
                        if (this.board[c1-1, i-1] != "-")
                        {
                            return false;
                            throw new Exception();
                        }
                    }

                    // Una vez verificado, coloco el barco

                    Ship ship = new Ship(size);
                    for (int i = c2; i < (c2+size); i += directionInt)
                    {
                        this.board[c1-1, i-1] = $"{ship.GetCharacter()}";
                        ship.AddCoordinate(c1, i);
                    }
                }
                // Para la orientación horizontal
                else
                {
                    // Verifico que las coordenadas esten dentro del tablero y no haya otro barco
                    for (int i = c1; i > (c1-size); i += directionInt)
                    {
                        if (this.board[i-1, c2-1] != "-")
                        {
                            return false;
                            throw new Exception();
                        }
                    }

                    // Una vez verificado, coloco el barco

                    Ship ship = new Ship(size);
                    for (int i = c1; i > (c1-size); i += directionInt)
                    {
                        this.board[i-1, c2-1] = $"{ship.GetCharacter()}";
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


        // Devuelve el Board como una string, para que pueda imprimirse más tarde
        public string BoardToString()
        {
            string stringBoard = "";

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    stringBoard += $" {this.board[i,j]}";
                }
                stringBoard += "\n";
            }

            return stringBoard;
        }
    }
}