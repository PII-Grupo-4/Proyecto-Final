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

        [SetUp]
        public void Setup()
        {
            handler = new ExitLobbyHandle(null);
            message = new Message();

            user1 = new Battleship.User(1);
            user2 = new Battleship.User(2);

            message.MessageId = Convert.ToInt32(user1.GetID());

            UserRegister.AddUser(user1);
            UserRegister.AddUser(user2);

        }

        [Test]
        public void TestExitLobbyHandleNormalMode()
        {
            SearchGameHandler handler1 = new SearchGameHandler(null);

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
            SearchPredictiveGameHandler handler1 = new SearchPredictiveGameHandler(null);

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