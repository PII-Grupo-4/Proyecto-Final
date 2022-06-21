using NUnit.Framework;
using Battleship;
using System.IO;

namespace Library.Tests
{
    // El handler para ver resumenes del juego, se encarga de mostrar en pantalla todos 
    // los juegos finalizados hasta el momento, cada juego tiene una id propia.
    public class SeeGameSummariesHandlerTests
    {
        SeeGameSummariesHandler handler;
        Message message;
        User user1;
        User user2;

        Game game;

        [SetUp]
        public void Setup()
        {
            handler = new SeeGameSummariesHandler(null);
            message = new Message();

            user1 = new User("a");
            user2 = new User("b");

            UserRegister.AddUser(user1);
            UserRegister.AddUser(user2);

            game = new Game(user1, user2);
            GamesRegister.AddGame(game);
        }

        [Test]
        public void TestSeeGameSummariesHandler()
        {
            game.AddUserWinner(user1);

            message.Text = handler.Keywords[0];
            message.id = user1.GetID();
            string response;
            user1.ChangeStatus("start");

            StreamWriter writetext = new StreamWriter("GameSummaries.txt", false);
            writetext.WriteLine(game.GameInString());
            writetext.Close();

            // El resumen del juego se puede ver en la siguiente ubicación:
            //          ./src/Test/bin/Debug/net5.0/GameSummaries.txt

            string summaries = File.ReadAllText("GameSummaries.txt");
            

            IHandler result = handler.Handle(message, out response);

            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo(summaries));
        }

    }
}