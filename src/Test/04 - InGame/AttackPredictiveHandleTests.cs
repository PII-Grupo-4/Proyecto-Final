using NUnit.Framework;
using Battleship;
using Telegram.Bot.Types;
using System;

namespace Library.Tests
{
    // Una vez en el juego, el jugador puede atacar, para ello debe indicar la coordenada
    // de ataque en el mensaje
    public class AttackPredictiveHandlerTest
    {
        AttackPredictiveHandler handler;
        Message message;
        Battleship.User user1;
        Battleship.User user2;

        SearchGameHandler sgameh;

        PositionShipsHandle pshiph;


        [SetUp]
        public void Setup()
        {
            handler = new AttackPredictiveHandler(null);

            sgameh = new SearchPredictiveGameHandler(null);

            pshiph = new PositionShipsHandle(null);

            message = new Message();

            user1 = new Battleship.User(1);
            user2 = new Battleship.User(2);


            UserRegister.AddUser(user1);
            UserRegister.AddUser(user2);

            string response;
            IHandler result;

            message.MessageId = Convert.ToInt32(user1.GetID());
            message.Text = "buscar partida predictiva";
            
            sgameh.Handle(message, out response);

            message.MessageId = Convert.ToInt32(user2.GetID());
            message.Text = "buscar partida predictiva";

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
            message.Text = "p ataque a1";
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
            message.Text = $"p ataque {coor}";
            message.MessageId = Convert.ToInt32(user1.GetID());

            string response;

            IHandler result = handler.Handle(message, out response);

            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo($"Sucedió un error"));

        }

    }
}