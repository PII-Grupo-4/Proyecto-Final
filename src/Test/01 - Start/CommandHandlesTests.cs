using NUnit.Framework;
using Battleship;
using Telegram.Bot.Types;
using System;

namespace Library.Tests
{   // El handle se comandos se encarga de retornar los posibles comandos en base
    // al estado actual del user
    public class CommandsHandleTests
    {
        CommandsHandle handler;
        Message message;
        Battleship.User user1;
        Battleship.User user2;

        [SetUp]
        public void Setup()
        {
            handler = new CommandsHandle(null);
            message = new Message();

            user1 = new Battleship.User(1);
            user2 = new Battleship.User(2);

            message.MessageId = Convert.ToInt32(user1.GetID());

            UserRegister.AddUser(user1);
            UserRegister.AddUser(user2);
        }

        [Test]
        public void TestCommandsHandle()
        {
            message.Text = handler.Keywords[0];
            string response;
            user1.ChangeStatus("start");

            IHandler result = handler.Handle(message, out response);

            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo($"\nComandos en estado '{user1.getStatus()}'\n- buscar partida\n- buscar partida predictiva\n- ver partidas jugadas\n- cambiar turno\n- salir"));

            user1.ChangeGameMode("normal");
            user1.ChangeStatus($"in {user1.GetGameMode()} game");
            string forInGame = "\n- ver tableros\n- aereo <fila> (ejemplo:aereo A)\n- vidente\n- satelite <columna (ejemplo: satelite 1)>\n- cambiar turno\n- salir";

            result = handler.Handle(message, out response);

            Assert.That(result, Is.Not.Null);


            Assert.That(response, Is.EqualTo($"\nComandos en estado '{user1.getStatus()}'\n- atacar <coordenada> (ejemplo: 'atacar A1'){forInGame}"));
        }
    }
}