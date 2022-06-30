using NUnit.Framework;
using Battleship;
using Telegram.Bot.Types;
using System;

namespace Library.Tests
{
    // El handle se encarga de buscar partida en modo predictivo.
    // El primer usuario que busca, se manda al lobby (sala de espera).
    // Si ya hay un usuario en el lobby, y este busca el mismo modo de juego, 
    // entonces se los matchea y se inicia el juego.
    public class SearchPredictiveGameHandlerTests
    {
        SearchPredictiveGameHandler handler;
        Message message;
        Battleship.User user1;
        Battleship.User user2;

        [SetUp]
        public void Setup()
        {
            handler = new SearchPredictiveGameHandler(null);
            message = new Message();

            user1 = new Battleship.User(1);
            user2 = new Battleship.User(2);

            message.MessageId = Convert.ToInt32(user1.GetID());

            UserRegister.AddUser(user1);
            UserRegister.AddUser(user2);
        }

        [Test]
        public void TestSearchPredictiveGameHandler()
        {
            message.Text = handler.Keywords[0];
            string response;
            user1.ChangeStatus("start");

            IHandler result = handler.Handle(message, out response);

            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo($"Entraste a la sala de espera. Modo de juego: predictive"));
            Assert.AreEqual("lobby", user1.getStatus());

            
        }

        [Test]
        public void AddOtherUser()
        {
            TestSearchPredictiveGameHandler();
            string response;

            user2.ChangeStatus("start");
            message.MessageId = Convert.ToInt32(user2.GetID());

            IHandler result = handler.Handle(message, out response);
            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo($"Se ha unido a una partida con id {user2.GetPlayer().GetGameId()}"));
            Assert.AreEqual("position ships", user1.getStatus());
            Assert.AreEqual("position ships", user2.getStatus());
        }
    }
}