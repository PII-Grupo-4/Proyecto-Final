using NUnit.Framework;
using Battleship;
using Telegram.Bot.Types;
using System;

namespace Library.Tests
{
    // el usuario puede ver sus dos tableros mientras posiciona los barcos y mientras juega
    // cuando desee
    [TestFixture]
    public class ViewHitsHandleTest
    {
        private ViewHitsHandle handler;
        private Message message;
        private Battleship.User user1;
        private Battleship.User user2;
        private Telegram.Bot.Types.User userTelegram1;
        private Telegram.Bot.Types.User userTelegram2;

        private IPrinter Printer;

        [SetUp]
        public void Setup()
        {
            Printer = new ConsolePrinter();
            
            handler = new ViewHitsHandle(null);
            message = new Message();

            UserRegister.CreateUser(1);
            UserRegister.CreateUser(2);
            
            user1 = UserRegister.GetUser(1);
            user2 = UserRegister.GetUser(2);

            userTelegram1 = new Telegram.Bot.Types.User();
            userTelegram1.Id = 1;

            userTelegram2 = new Telegram.Bot.Types.User();
            userTelegram2.Id = 2;

            message.From = userTelegram1;
        }

        [Test]
        public void TestViewHitsHandlerWithoutValues()
        {
            message.Text = handler.Keywords[0];
            string response;
            user1.ChangeStatus("position ships");
            user2.ChangeGameMode("normal");
            user2.ChangeStatus($"in {user2.GetGameMode()} game");

            IHandler result = handler.Handle(message, out response);

            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo($"{user1.GetPlayer().GetHitsToPrint()}"));

            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo($"{user2.GetPlayer().GetHitsToPrint()}"));            
        }

         [Test]
        public void TestViewHitsHandlerWithValues()
        {
            message.Text = handler.Keywords[0];
            string response;
            user1.ChangeStatus($"in {user1.GetGameMode()} game");
            user2.ChangeGameMode("normal");
            user2.ChangeStatus($"in {user2.GetGameMode()} game");

            IHandler result = handler.Handle(message, out response);
            
            Board registerBoard = user2.GetPlayer().GetRegisterBoard();
            registerBoard.AddHitsCounter();
            Board boardWithShips = user1.GetPlayer().GetShipsBoard();
            boardWithShips.AddHitsCounter();
            message.From = userTelegram2;
            result = handler.Handle(message, out response);

            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo($"{user2.GetPlayer().GetHitsToPrint()}"));  
            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo($"{user1.GetPlayer().GetHitsToPrint()}"));

        }

    }
}