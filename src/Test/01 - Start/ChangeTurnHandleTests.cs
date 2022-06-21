using NUnit.Framework;
using Battleship;

namespace Library.Tests
{   
    // Dicho Handle se encarga de cambiar de turno, turn es un atributo de message, 
    // y es utilizado en el program para ver de que usuario es el turno de ingresar
    // o pedir datos
    public class ChangeTurnHandleTests
    {
        ChangeTurnHandle handler;
        Message message;
        User user1;
        User user2;

        [SetUp]
        public void Setup()
        {
            handler = new ChangeTurnHandle(null);
            message = new Message();

            user1 = new User("a");
            user2 = new User("b");

            UserRegister.AddUser(user1);
            UserRegister.AddUser(user2);
        }

        [Test]
        public void TestChangeTurnHandle()
        {
            message.Text = handler.Keywords[0];
            string response;
            message.Turn = 1;

            IHandler result = handler.Handle(message, out response);

            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo($"\n\n------Turno cambiado------\n\n"));
            Assert.AreEqual(2, message.Turn);
        }

    }
}