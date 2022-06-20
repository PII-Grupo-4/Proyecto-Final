using System.Collections.Generic;

namespace Battleship
{

    // Sala de espera para encontrar juego
    
    public static class Lobby
    {
        static List<User> ListOfUser = new List<User>();

        static public void AddUser(User user)
        {
            ListOfUser.Add(user);
        }

        // Se ingresa el modo de juego, y se retorna al primer usuario que este esperando para jugar
        static public User GetAndRemoveUser(string gameMode)
        {
            foreach (User user in ListOfUser)
            {
                if (user.GetGameMode() == gameMode)
                {
                    ListOfUser.Remove(user);
                    return user;
                }  
            }

            return null;
        }  

        static public void RemoveUser(User user)
        {
            ListOfUser.Remove(user);
        }

        // Posibles modos de juego:
        //      normal = Clásico
        static public int NumberUsersLobby(string gameMode)
        {
            int numberOfUser = 0;

            foreach (User user in ListOfUser)
            {
                if (user.GetGameMode() == gameMode)
                {
                    numberOfUser ++;
                }  
            }

            return numberOfUser;
        }

    }
}