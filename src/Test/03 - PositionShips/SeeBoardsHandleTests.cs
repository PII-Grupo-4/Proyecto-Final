using NUnit.Framework;
using Battleship;
using Telegram.Bot.Types;
using System;

namespace Library.Tests
{
    // el usuario puede ver sus dos tableros mientras posiciona los barcos y mientras juega
    // cuando desee
    public class SeeBoardsHandleTest
    {
        SeeBoardsHandle handler;
        Message message;
        Battleship.User user1;
        Battleship.User user2;

        IPrinter Printer;

        [SetUp]
        public void Setup()
        {
            Printer = new ConsolePrinter();
            
            handler = new SeeBoardsHandle(null);
            message = new Message();

            UserRegister.CreateUser(1);
            UserRegister.CreateUser(2);
            
            user1 = UserRegister.GetUser(1);
            user2 = UserRegister.GetUser(1);

            message.MessageId = Convert.ToInt32(user1.GetID());
        }

        [Test]
        public void TestSearchGameHandler()
        {
            message.Text = handler.Keywords[0];
            string response;
            user1.ChangeStatus("position ships");
            user2.ChangeGameMode("normal");
            user2.ChangeStatus($"in {user2.GetGameMode()} game");

            IHandler result = handler.Handle(message, out response);

            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo($"{user1.GetPlayer().GetBoardsToPrint()}"));

            message.MessageId = Convert.ToInt32(user1.GetID());

            result = handler.Handle(message, out response);

            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo($"{user2.GetPlayer().GetBoardsToPrint()}"));
            
        }

    }
}