using System.Collections.Generic;

namespace Battleship
{
    // La clase Games es una clase que contiene, brinda acceso y crea a los Games.
    public static class Lobby
    {
        static List<User> ListOfUser = new List<User>();

        static public void AddUser(User user)
        {
            ListOfUser.Add(user);
        }

        static public User GetAndRemoveUser()
        {
            User user = ListOfUser[0];
            ListOfUser.Remove(user);
            return user;
        }  

        static public void RemoveUser(User user)
        {
            ListOfUser.Remove(user);
        }

        static public int NumberUsersLobby()
        {
            return ListOfUser.Count;
        }

    }
}