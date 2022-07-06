using NUnit.Framework;
using Battleship;
using System;
using System.IO;

namespace Library.Tests
{   
    /// <summary>
    /// Se testea GameRegister
    /// </summary>
    [TestFixture]
    public class GameRegisterTests
    {
        [Test]
        public void GameRegisterTest()
        {
            UserRegister.CreateUser(15);
            User user1 = UserRegister.GetUser(15);
            UserRegister.CreateUser(16);
            User user2 = UserRegister.GetUser(16);

            int gameId = GamesRegister.CreateGame(user1, user2);
            Game game1 = GamesRegister.GetGameByUserId(user1.GetID());

            Assert.AreEqual(gameId, game1.GetId());
            
            game1.AddUserWinner(user2);
            GamesRegister.SaveGame(game1);

            string summary1 = System.IO.File.ReadAllText("GameSummaries.txt");

            game1.AddUserWinner(user1);
            GamesRegister.SaveGame(game1);

            string summary2 = System.IO.File.ReadAllText("GameSummaries.txt");

            Assert.AreNotEqual(summary1, summary2);
        }
    }
}