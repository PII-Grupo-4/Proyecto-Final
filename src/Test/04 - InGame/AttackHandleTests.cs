using NUnit.Framework;
using Battleship;
using Telegram.Bot.Types;
using System;

namespace Library.Tests
{
    // Una vez en el juego, el jugador puede atacar, para ello debe indicar la coordenada
    // de ataque en el mensaje
    public class AttackHandleTest
    {
        AttackHandle handler;
        Message message;
        Battleship.User user1;
        Battleship.User user2;

        SearchGameHandler sgameh;

        PositionShipsHandle pshiph;

        IPrinter Printer;

        [SetUp]
        public void Setup()
        {
            Printer = new ConsolePrinter();
            
            handler = new AttackHandle(null, Printer);

            sgameh = new SearchGameHandler(null, Printer);

            pshiph = new PositionShipsHandle(null, Printer);

            message = new Message();

            UserRegister.CreateUser(1);
            UserRegister.CreateUser(2);
            
            user1 = UserRegister.GetUser(1);
            user2 = UserRegister.GetUser(1);

            string response;
            IHandler result;

            message.MessageId = Convert.ToInt32(user1.GetID());
            message.Text = "buscar partida";
            
            sgameh.Handle(message, out response);

            message.MessageId = Convert.ToInt32(user2.GetID());
            message.Text = "buscar partida";

            sgameh.Handle(message, out response);

            for (int i = 1; i < 6; i++)
            {
                message.Text = $"posicionar barco a{i} down";
                result = pshiph.Handle(message, out response);
            }  

            message.MessageId = Convert.ToInt32(user1.GetID());

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
            message.MessageId = Convert.ToInt32(user1.GetID());

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
            message.MessageId = Convert.ToInt32(user1.GetID());

            string response;

            IHandler result = handler.Handle(message, out response);

            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo($"Sucedió un error"));

        }

    }
}