using NUnit.Framework;
using Battleship;

namespace Library.Tests
{
    // Existe un handler encargado de posicionar los barcos, sin embargo dicho handler contiene
    // inputs y prints de información dentro del internal handler, por lo que no podemos
    // testearlo directamente como un handler común. La idea en un inicio fue que se ingresara
    // la palabra clave "posicionar barco" acompañada de la coordenada, pero por el momento 
    // no hemos podido realizarlo ya que el ingreso de las distintas coordenadas no evi
    public class PositionShipsTest
    {
        SeeBoardsHandle handler;
        Message message;
        User user1;
        User user2;

        [SetUp]
        public void Setup()
        {
            handler = new SeeBoardsHandle(null);
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
            user1.ChangeStatus("position ships");
            user2.ChangeGameMode("normal");
            user2.ChangeStatus($"in {user2.GetGameMode()} game");

            IHandler result = handler.Handle(message, out response);

            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo($"{user1.GetPlayer().GetBoardsToPrint()}"));

            message.id = user1.GetID();

            result = handler.Handle(message, out response);

            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo($"{user2.GetPlayer().GetBoardsToPrint()}"));
            
        }

    }
}