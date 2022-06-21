using NUnit.Framework;
using Battleship;

namespace Library.Tests
{
    // Una vez en el juego, el jugador puede atacar, para ello debe indicar la coordenada
    // de ataque en el mensaje
    public class AttackHandleTest
    {
        AttackHandle handler;
        Message message;
        User user1;
        User user2;

        Game game;

        SearchGameHandler sgameh;

        PositionShipsHandle pshiph;


        [SetUp]
        public void Setup()
        {
            handler = new AttackHandle(null);

            sgameh = new SearchGameHandler(null);

            pshiph = new PositionShipsHandle(null);

            message = new Message();

            user1 = new User("a");
            user2 = new User("b");


            UserRegister.AddUser(user1);
            UserRegister.AddUser(user2);

            string response;
            IHandler result;

            message.id = user1.GetID();
            message.Text = "buscar partida";
            
            sgameh.Handle(message, out response);

            message.id = user2.GetID();
            message.Text = "buscar partida";

            sgameh.Handle(message, out response);

            for (int i = 1; i < 6; i++)
            {
                message.Text = $"posicionar barco a{i} down";
                result = pshiph.Handle(message, out response);
            }  

            message.id = user1.GetID();

            for (int i = 1; i < 6; i++)
            {
                message.Text = $"posicionar barco a{i} down";
                result = pshiph.Handle(message, out response);
            }  
        }

        [Test]
        public void TestAttackHandle()
        {
            message.Text = "atacar a1";
            message.id = user1.GetID();

            string response;

            IHandler result = handler.Handle(message, out response);

            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo($"Tocado\n\n\n\n------Turno cambiado------\n\n"));

        }


        [TestCase("a0")]
        [TestCase("k4")]
        public void InvalidCoordinates(string coor)
        {
            message.Text =$"atacar {coor}";
            message.id = user1.GetID();

            string response;

            IHandler result = handler.Handle(message, out response);

            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo($"Sucedió un error"));

        }

    }
}