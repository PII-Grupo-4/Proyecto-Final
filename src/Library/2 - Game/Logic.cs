using System;
using System.Collections.Generic;

namespace Battleship
{
    public static class Logic
    {
        static List<string> Row = new List<string>{"A", "B", "C", "D", "E", "F", "G", "H", "I", "J"};
        static List<string> Column = new List<string>{"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"};

        // Recibe dos usuarios y una coordenada.
        // En caso de que la coordenada sea correcta, realiza el ataque.
        public static string Attack(string coordinate, User user, User userAttacked)
        {
            Board boardWithShips = userAttacked.GetPlayer().GetShipsBoard();
            Board registerBoard = user.GetPlayer().GetRegisterBoard();
            string response = "";

            List<int> coordinateList = FixCoordinate(coordinate);
            if (coordinateList == new List<int>{})
            {
                return "Las coordenadas ingresadas son incorrectas";
            }

            string coordinateInBoard = boardWithShips.GetBoard()[coordinateList[0]-1, coordinateList[1]-1];
            if (coordinateInBoard == "x" || coordinateInBoard == "#" || coordinateInBoard == "o")
            {
                return "Ya se atacó en dicha coordenada";
            }
            else if(coordinateInBoard == "-")
            {
                response = "Agua";
                boardWithShips.GetBoard()[coordinateList[0]-1, coordinateList[1]-1] = "o";
                registerBoard.GetBoard()[coordinateList[0]-1, coordinateList[1]-1] = "o";
                return response;
            }
            else
            {
                foreach (Ship ship in boardWithShips.GetShipsList())
                {
                    if (ship.GetCharacter() == coordinateInBoard)
                    {
                        if (ship.GetHealth() == 1)
                        {
                            boardWithShips.RemoveShip(ship);
                            response = "Hundido";
                            List<List<int>> shipCoordinates = ship.GetCoordinates();
                            for (int i = 0; i < ship.GetSize(); i++)
                            {
                                boardWithShips.GetBoard()[shipCoordinates[i][0]-1, shipCoordinates[i][1]-1] = "#";
                                registerBoard.GetBoard()[shipCoordinates[i][0]-1, shipCoordinates[i][1]-1] = "#";
                            }
                            break;
                        }
                        else
                        {
                            ship.DecreaseHealth();
                            response = "Tocado";
                            boardWithShips.GetBoard()[coordinateList[0]-1, coordinateList[1]-1] = "x";
                            registerBoard.GetBoard()[coordinateList[0]-1, coordinateList[1]-1] = "x";
                            break;
                        }
                    }
                }
                

                return response;
            }
        }


        // FixCoordinate recibe una coordenada en forma de string (ej "A3") y la transforma en una lista de dos int.
        // Si son incorrectas, retorna una lista vacia
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

        // Cambia el turno de los usuarios
        public static void ChangeTurn(Message message)
        {
            if (message.Turn == 1)
            {
                message.Turn = 2;
            }
            else
            {
                message.Turn = 1;
            }
        }
    }
}