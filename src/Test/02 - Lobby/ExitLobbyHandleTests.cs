using NUnit.Framework;
using Battleship;
using Telegram.Bot.Types;
using System;

namespace Library.Tests
{
    // Si un jugador esta en el lobby, y aún no ha conseguido pareja, tiene la posibilidad
    // de salir del mismo cunado lo desee. Este handler se encarga de eso.
    public class ExitLobbyHandleTests
    {
        ExitLobbyHandle handler;
        Message message;
        Battleship.User user1;
        Battleship.User user2;

        IPrinter Printer;

        [SetUp]
        public void Setup()
        {
            Printer = new ConsolePrinter();
            
            handler = new ExitLobbyHandle(null);
            message = new Message();

            UserRegister.CreateUser(1);
            UserRegister.CreateUser(2);
            
            user1 = UserRegister.GetUser(1);
            user2 = UserRegister.GetUser(1);

            message.MessageId = Convert.ToInt32(user1.GetID());

        }

        [Test]
        public void TestExitLobbyHandleNormalMode()
        {
            SearchGameHandler handler1 = new SearchGameHandler(null, Printer);

            message.Text = handler1.Keywords[0];
            string response;
            user1.ChangeStatus("start");

            IHandler result = handler1.Handle(message, out response);
            
            message.Text = handler.Keywords[0];
            user1.ChangeStatus("lobby");

            result = handler.Handle(message, out response);

            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo("Has salido de la sala de espera"));
            Assert.AreEqual("start", user1.getStatus());  
        }

        [Test]
        public void TestExitLobbyHandlePredictiveMode()
        {
            SearchPredictiveGameHandler handler1 = new SearchPredictiveGameHandler(null, Printer);

            message.Text = handler1.Keywords[0];
            string response;
            user1.ChangeStatus("start");

            IHandler result = handler1.Handle(message, out response);
            
            message.Text = handler.Keywords[0];
            user1.ChangeStatus("lobby");

            result = handler.Handle(message, out response);

            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo("Has salido de la sala de espera"));
            Assert.AreEqual("start", user1.getStatus());  
        }

    }
}