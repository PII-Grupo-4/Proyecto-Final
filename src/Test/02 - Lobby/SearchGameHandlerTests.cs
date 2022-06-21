using NUnit.Framework;
using Battleship;

namespace Library.Tests
{
    // El handle se encarga de buscar partida en modo normal.
    // El primer usuario que busca, se manda al lobby (sala de espera).
    // Si ya hay un usuario en el lobby, y este busca el mismo modo de juego, 
    // entonces se los matchea y se inicia el juego.
    public class SearchGameHandlerTests
    {
        SearchGameHandler handler;
        Message message;
        User user1;
        User user2;

        [SetUp]
        public void Setup()
        {
            handler = new SearchGameHandler(null);
            message = new Message();

            user1 = new User("a");
            user2 = new User("b");

            message.id = user1.GetID();

            UserRegister.AddUser(user1);
            UserRegister.AddUser(user2);
        }

        [Test]
        public void TestSearchGameHandler()
        {
            message.Text = handler.Keywords[0];
            string response;
            user1.ChangeStatus("start");

            IHandler result = handler.Handle(message, out response);

            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo($"Entraste a la sala de espera. Modo de juego: normal"));
            Assert.AreEqual("lobby", user1.getStatus());

            
        }

        [Test]
        public void AddOtherUser()
        {
            TestSearchGameHandler();
            string response;

            user2.ChangeStatus("start");
            message.id = user2.GetID();

            IHandler result = handler.Handle(message, out response);
            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo($"Se ha unido a una partida con id {user2.GetPlayer().GetGameId()}"));
            Assert.AreEqual("position ships", user1.getStatus());
            Assert.AreEqual("position ships", user2.getStatus());
        }
    }
}