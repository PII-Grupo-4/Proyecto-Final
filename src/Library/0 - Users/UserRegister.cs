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

        
        public static string RemoveUser(int userId)
        {
            foreach (User user1 in ListOfUsers)
            {
                if (user1.GetID() == userId)
                {
                    ListOfUsers.Remove(user1);
                    return $"El usuario {user1.GetName()} se ha eliminado del registro correctamente";
                }
            }

            return $"No existe ningun usuario con la Id ingresada.";
        }

    }
}
