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
    // C = Carrier (Size: 5)
    // B = Battleship (Size: 4)
    // S = Submarine (Size: 3)
    // D = Destroyer (Size: 2)

    /// <summary>
    /// Board es el experto en la información de la ubicación de los barcos en el tablero,
    /// por lo tanto es el ideal para posicionar los barcos
    /// </summary>
    public class Board
    {
        private string[,] board = new string[10,10]; //Tablero, El tamaño del tablero es fijo.

        private List<Ship> ShipsList = new List<Ship>{}; // Lista con los barcos

        static List<string> Orientations = new List<string>{"UP", "DOWN", "LEFT", "RIGHT"}; //Orientaciones de colocación posibles

        private List<int> ShipsSize = new List<int>{5,4,3,2}; // Los tamaños de los barcos

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

        // Retorna el número de barcos que hay en el tablero
        public int GetShipsAlive()
        {
            return this.ShipsList.Count;
        }

        public string[,] GetBoard()
        {
            return this.board;
        }

        public List<Ship> GetShipsList()
        {
            return this.ShipsList;
        }

        public void RemoveShip(Ship ship)
        {
            ship.DecreaseHealth();
            this.ShipsList.Remove(ship);
        }

        // Controla si los datos de coordenada y orientación ingresados son correctos
        //  De ser así los envía a PositionShip.
        public string ControlCoordinates(string coordinate, string direction)
        {
            string response = "";
            

            try
            {
                if (this.ShipsList.Count >= 4)
                {
                    return "No se puede agregar más barcos (El tablero ya esta lleno).";
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

                int size = ShipsSize[0];
                bool ShipBool = Position_Ship(size, coordinateList, direction);

                if (ShipBool == false)
                {
                    throw new Exception();
                }
                else
                {
                    ShipsSize.RemoveAt(0);
                    return "El barco se creó correctamente";
                }

            }
            catch
            {
                return response + "Datos incorrectos, el barco no se creó.";
            }
            
        }

        // Posiciona los barcos en la coordenada y orientación indicada
        private bool Position_Ship(int size, List<int> coordinateList, string direction)
        {
            int c1 = coordinateList[0];
            int c2 = coordinateList[1];

            try
            {
                // Para la orientación horizontal
                if(direction == "UP")
                {
                    // Verifico que las coordenadas esten dentro del tablero y no haya otro barco
                    for (int i = c1; i > (c1-size); i -= 1)
                    {
                        if (this.board[i-1, c2-1] != "-")
                        {
                            return false;
                            throw new Exception();
                        }
                    }

                    // Una vez verificado, coloco el barco

                    Ship ship = new Ship(size);
                    for (int i = c1; i > (c1-size); i -= 1)
                    {
                        this.board[i-1, c2-1] = $"{ship.GetCharacter()}";
                        ship.AddCoordinate(i, c2);
                    }
                    ShipsList.Add(ship);
                }
                else if(direction == "DOWN")
                {
                    // Verifico que las coordenadas esten dentro del tablero y no haya otro barco
                    for (int i = c1; i < (c1+size); i += 1)
                    {
                        if (this.board[i-1, c2-1] != "-")
                        {
                            return false;
                            throw new Exception();
                        }
                    }

                    // Una vez verificado, coloco el barco

                    Ship ship = new Ship(size);
                    for (int i = c1; i < (c1+size); i += 1)
                    {
                        this.board[i-1, c2-1] = $"{ship.GetCharacter()}";
                        ship.AddCoordinate(i, c2);
                    }
                    ShipsList.Add(ship);
                }
                
                // Para la orientación vertical
                else if (direction == "RIGHT")
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
                    for (int i = c2; i < (c2+size); i += 1)
                    {
                        this.board[c1-1, i-1] = $"{ship.GetCharacter()}";
                        ship.AddCoordinate(c1, i);
                    }
                    ShipsList.Add(ship);
                }
                else
                {
                    // Verifico que las coordenadas esten dentro del tablero y no haya otro barco
                    for (int i = c2; i > (c2-size); i -= 1)
                    {
                        if (this.board[c1-1, i-1] != "-")
                        {
                            return false;
                            throw new Exception();
                        }
                    }

                    // Una vez verificado, coloco el barco

                    Ship ship = new Ship(size);
                    for (int i = c2; i > (c2-size); i -= 1)
                    {
                        this.board[c1-1, i-1] = $"{ship.GetCharacter()}";
                        ship.AddCoordinate(c1, i);
                    }
                    ShipsList.Add(ship);
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
            List<string> Lyrics = new List<string>{"A", "B", "C", "D", "E", "F", "G", "H", "I", "J"};
            
            string stringBoard = "";

            stringBoard += "   | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | 10|\n";
            stringBoard += "--------------------------------------------\n";

            for (int i = 0; i < 10; i++)
            {   
                stringBoard += $"{Lyrics[i]}  |";
                for (int j = 0; j < 10; j++)
                {
                    stringBoard += $" {this.board[i,j]} |";
                }
                stringBoard += "\n";
                stringBoard += "--------------------------------------------";
                stringBoard += "\n";
            }

            return stringBoard;
        }
    }
}