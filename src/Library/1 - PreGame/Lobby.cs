using System.Collections.Generic;

namespace Battleship
{

    // Sala de espera para encontrar juego
    
    public static class Lobby
    {
        static List<User> UsersInLobby = new List<User>();

        static public void AddUser(User user)
        {
            UsersInLobby.Add(user);
        }

        // Se ingresa el modo de juego, y se retorna al primer usuario que este esperando para jugar
        static public User GetAndRemoveUser(string gameMode)
        {
            foreach (User user in UsersInLobby)
            {
                if (user.GetGameMode() == gameMode)
                {
                    UsersInLobby.Remove(user);
                    return user;
                }  
            }

            return null;
        }  

        static public void RemoveUser(User user)
        {
            UsersInLobby.Remove(user);
        }

        // Posibles modos de juego:
        //      normal = Clásico
        static public int NumberUsersLobby(string gameMode)
        {
            int numberOfUser = 0;

            foreach (User user in UsersInLobby)
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