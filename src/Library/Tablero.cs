using System;
using System.Collections.Generic;

//Adaptar y mover a logica

namespace BatallaNaval
{
    class Tablero
    {
        private int id;

        private int gameMode;

        List<Barco> shipsAlive = new List<Barco>();

        List<Jugador> playerActive = new List<Jugador>();

        public Tablero(int gameMode, Jugador player1, Jugador player2)
        {
            Random randomId = new Random();
            this.id = randomId.Next(1,100);
            this.gameMode = gameMode;
            this.playerActive.Add(player1);
            this.playerActive.Add(player2);

        }
    }
}