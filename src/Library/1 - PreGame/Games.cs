using System.Collections.Generic;

namespace Battleship
{
    // La clase Games es una clase que contiene, brinda acceso y crea a los Games.
    public static class Games
    {
        static List<Game> GamesList = new List<Game>();

        static int CounterId = 0;

        static public void CreateGame(User user)
        {
            Game game = new Game(CounterId);
            GamesList.Add(game);
            game.AddUser(user);

            CounterId ++;
        }


        static public Game GetGame(int id)
        {
            foreach (Game game in GamesList)
            {
                if (game.GetID() == id)
                {
                    return game;
                }
            }

            return null;
        }


    }
}