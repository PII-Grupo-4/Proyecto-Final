using System.Collections.Generic;

namespace Battleship
{
    // La clase Games es una clase que contiene, brinda acceso y crea a los Games.
    public static class MatchUsers
    {
        static List<User> Lobby = new List<User>();

        static public void AddUser(User user)
        {
            Lobby.Add(user);
        }
    }
}