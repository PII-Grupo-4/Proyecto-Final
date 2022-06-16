using NUnit.Framework;
using Battleship;
using System.Collections.Generic;

namespace Library.Tests
{
    [TestFixture]
    public class UserTests
    {
        User user1;
        User user2;

        Game game1;

        GameLogic gameLogic1;

        [Test]
        public void RegisterUsers()
        {
            // Se crean los usuarios para jugar
            UserRegister.CreateUser("Usuario1");
            UserRegister.CreateUser("Usuario2");

            // Se accede a los usuarios creados a travez del nombre
            user1 = UserRegister.GetUserByName("Usuario1");
            user2 = UserRegister.GetUserByName("Usuario2");

            // Verificamos que lo anterior funciono correctamente comparando al id que deberían tener cada usuario (0 y 1)
            Assert.AreEqual(0, user1.GetID());
            Assert.AreEqual(1, user2.GetID());
        }

        [Test]
        public void MatchUsers()
        {
            RegisterUsers();

            Games.CreateGame(user1);

            // Una vez creado el juego, otro usuario debe unirse para empezar la partida. Para unirse lo hace 
            // a travez de la id de la partida. Las partidas se muestran en pantalla con su id, y el usuario
            // ingresa la id de la que se quiere unir.

            game1 = Games.GetGame(0);
            game1.AddUser(user2);

            Assert.AreEqual(0, game1.GetID());
            Assert.AreEqual(2, game1.GetUsersQuantity());
        }

        [Test]
        public void PositionShips()
        {
            MatchUsers();

            game1.StartGame();
            gameLogic1 = game1.GetGameLogic();

            // El administrados le pide a cada usuario la coordenada y orientación de cada barco
            // Las coordenadas deben ser escritas en formato LetraNúmero, y la orientación debe ser 
            // alguna de las siguientes:
            //      -up
            //      -down
            //      -left
            //      -right
            // Si los datos ingresados no son correctos, el barco no se coloca.
            gameLogic1.PositionShip(1, 2, "A1", "down");


            // Printer.PrintBoardsInConsole(gameLogic1)

            // gameLogic.Attack(Player 1)

            // 
        }


        /*
            Como se puede observar en los dos últimos casos (casos especiales), FixCoordinate toma como valida
            la coordenada ingresada si los primeros caracteres son correctos, ignorando el restde caracteres.
            Se se ingresa columna "11", se toma como si fuera "1", lo mismo para "12", "1$", "1ñ", etc.
        */
        [TestCase("a1", 1, 1)]
        [TestCase("B8", 2, 8)]
        [TestCase("J10", 10, 10)]
        [TestCase("A11", 1, 1)] // Caso especial
        [TestCase("A13498efruj456", 1, 1)] // Caso especial

        public void FixCoordinate_ValidCoordinates(string coordinate, int row, int column)
        {
            Board board = new Board();
            List<int> coordenateList = board.FixCoordinate(coordinate);

            List<int> expected = new List<int>{row, column};
            
            Assert.AreEqual(expected, coordenateList);
        }


        [TestCase("aliwhdbuilebawndeaw3")]
        [TestCase("aa")]
        [TestCase("11")]
        [TestCase("K1")]
        public void FixCoordinate_InvalidCoordinates(string coordinate)
        {
            Board board = new Board();
            List<int> coordenateList = board.FixCoordinate(coordinate);

            List<int> expected = new List<int>{};
            
            Assert.AreEqual(expected, coordenateList);
        }
    }
}