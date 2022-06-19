using System.Collections.Generic;
using System.IO;

namespace Battleship
{
    // Crea, contiene y elimina los Games
    public static class GamesRegister
    {
        private static List<Game> GamesInPlay = new List<Game>{};

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
        

        // Recibe un game, lo guarda en el archivo GameSummaries.txt y lo eliminar de GamesInPlay
        // Aún no funciona
        public static void SaveGame(Game game)
        {
            string gameToSave = game.GameInString();
            
            StreamWriter writetext = new StreamWriter("./GameSummaries.txt");
            writetext.WriteLine(gameToSave);

            foreach (Game game1 in GamesInPlay)
            {
                if (game1 == game)
                {
                    GamesInPlay.Remove(game1);
                    break;
                }
            }  
        }
    }
}