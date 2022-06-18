using System.Collections.Generic;

// UserRegister es una clase estática que funciona como base de datos de los usuarios.
// Primero se debe crear un usuario, luego se debe acceder al usuario creado.
// Se accede a los usuarios a travez del nombre, en el caso que no existe, se devuelve un valor null.

namespace Battleship
{
    static public class UserRegister
    {
        static List<User> ListOfUsers = new List<User> ();

        public static void AddUser(User user)
        {
            ListOfUsers.Add(user);
        }

        public static User GetUser(int UserId)
        {
            foreach (User user in ListOfUsers)
                {
                    if (user.GetID() == UserId)
                    {
                        return user;
                    }
                }
            
            return null;
        }
    }
}
