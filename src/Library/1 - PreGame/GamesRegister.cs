using System.Collections.Generic;

namespace Battleship
{
    public static class GamesRegister
    {
        private static List<Game> GamesInPlay = new List<Game>{};

        private static List<Game> GamesPlayed = new List<Game>{};

        public static void AddGame(Game game)
        {
            GamesInPlay.Add(game);
        }

        public static Game GetGameInPlay(int gameId)
        {
            foreach (Game game in GamesInPlay)
            {
            if (game.GetId() == gameId)
            {
                return game;
            }
            }

            return null;
        }
    }
}