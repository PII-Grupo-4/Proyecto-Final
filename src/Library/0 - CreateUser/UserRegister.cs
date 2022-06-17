using System.Collections.Generic;

// UserRegister es una clase estática que funciona como base de datos de los usuarios.
// Primero se debe crear un usuario, luego se debe acceder al usuario creado.
// Se accede a los usuarios a travez del nombre, en el caso que no existe, se devuelve un valor null.

namespace Battleship
{
    static public class UserRegister
    {
        static List<User> ListOfUsers = new List<User> ();

        public static string AddUser(User user)
        {
            ListOfUsers.Add(user);
            return $"El usuario {user.GetName()} se ha creado correctamente";
        }

        
        public static string RemoveUser(User user)
        {
            foreach (User user1 in ListOfUsers)
            {
                if (user1.GetID() == user.GetID())
                {
                    ListOfUsers.Remove(user);
                    return $"El usuario {user.GetName()} se ha eliminado del registro correctamente";
                }
            }

            return $"El usuario {user.GetName()} no está registrado.";
        }

    }
}
