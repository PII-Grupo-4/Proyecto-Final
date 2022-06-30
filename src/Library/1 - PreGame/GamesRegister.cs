using System.Collections.Generic;
using System.IO;

namespace Battleship
{
    /// <summary>
    /// Cream contiene y elimina los Games
    /// </summary>
    public static class GamesRegister
    {
        private static List<Game> GamesInPlay = new List<Game>{};

        public static int CreateGame(User user1, User user2)
        {
            Game game = new Game(user1, user2);
            GamesInPlay.Add(game);
            
            return game.GetId();
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

        public static void RemoveGame(Game game)
        {
            foreach (Game game1 in GamesInPlay)
            {
                if (game1 == game)
                {
                    GamesInPlay.Remove(game1);
                    break;
                }
            }  
        }
        

        /// <summary>
        /// Recibe un game, lo guarda en el archivo GameSummaries.txt y lo elimina de GamesInPlay
        /// </summary>
        public static void SaveGame(Game game)
        {
            string gameToSave = game.GameInString();
            
            StreamWriter writetext = new StreamWriter("GameSummaries.txt", true);
            writetext.WriteLine(gameToSave);
            writetext.Close();

            foreach (Game game1 in GamesInPlay)
            {
                if (game1 == game)
                {
                    GamesInPlay.Remove(game1);
                    break;
                }
            }  
        }

        /// <summary>
        /// Se ingresa la id de un User, se busca el Game que contiene a dicho
        /// jugador y se retorna dicho Game.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Game GetGameByUserId(long id)
        {
            foreach (Game game in GamesInPlay)
            {
                List<long> listWithUserId= game.GetUsersId();
                if (listWithUserId[0] == id || listWithUserId[1] == id)
                {
                    return game;
                }
            }

            return null;
        }
    }
}