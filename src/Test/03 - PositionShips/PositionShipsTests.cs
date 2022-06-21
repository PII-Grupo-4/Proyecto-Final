using NUnit.Framework;
using Battleship;

namespace Library.Tests
{
    // El siguiente Handler es el encargado de posicionar los barcos, se le indica la 
    // coordenada y la orientación del mismo. Por convensión se coloca del mas grande
    // al mas pequeño. En total hay 4 barcos que varian el tamaño desde 2 a 5 lugares c/u
    public class PositionShipsHandleTest
    {
        PositionShipsHandle handler;
        Message message;
        User user1;
        User user2;

        Game game;

        [SetUp]
        public void Setup()
        {
            handler = new PositionShipsHandle(null);
            message = new Message();

            user1 = new User("a");
            user2 = new User("b");

            message.id = user1.GetID();

            UserRegister.AddUser(user1);
            UserRegister.AddUser(user2);

            game = new Game(user1, user2);

            GamesRegister.AddGame(game);
        }

        [Test]
        public void TestPositionShipsHandle()
        {
            message.Text = "posicionar barco a1 down";
            string response;
            user1.ChangeStatus("position ships");

            IHandler result = handler.Handle(message, out response);

            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo($"El barco se creó correctamente"));

            for (int i = 2; i < 5; i++)
            {
                message.Text = $"posicionar barco a{i} down";
                result = handler.Handle(message, out response);
            }

            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo($"Los barcos estan listos"));
            
        }


        [TestCase("a1 up")]
        [TestCase("j10 down")]
        public void InvalidCoordinates(string coor)
        {
            message.Text = $"posicionar barco {coor}";
            string response;
            user1.ChangeStatus("position ships");

            IHandler result = handler.Handle(message, out response);

            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo("Datos incorrectos, el barco no se creó."));
            
        }

    }
}