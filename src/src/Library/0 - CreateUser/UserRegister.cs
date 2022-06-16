using System.Collections.Generic;

// UserRegister es una clase estática que funciona como base de datos de los usuarios.
// Primero se debe crear un usuario, luego se debe acceder al usuario creado.
// Se accede a los usuarios a travez del nombre, en el caso que no existe, se devuelve un valor null.

namespace Battleship
{
    static public class UserRegister
    {
        static List<User> ListOfUsers = new List<User> ();

        static int UserID_counter = 0;


        public static void CreateUser(string name)
        {
            bool addBool = true; // Para verificar que no se agregue otro usuario con el mismo nombre

            foreach (User user in ListOfUsers)
            {
                if (user.GetName() == name)
                {
                    addBool = false;
                    break;
                }
            }

            if (addBool == true)
            {
                ListOfUsers.Add(new User(name, UserID_counter));
                UserID_counter ++;
                Printer.ChangeMessage($"El usuario {name} se ha creado correctamente");
            }
            else
            {
                Printer.ChangeMessage($"Ya existe un usuario con el nombre {name}. El usuario no se ha creado");
            }  

        }

        
        public static void RemoveUser(string name)
        {
            foreach (User user in ListOfUsers)
            {
                if (user.GetName() == name)
                {
                    ListOfUsers.Remove(user);
                    Printer.ChangeMessage($"El usuario {name} se ha eliminado correctamente");
                }
            }

            Printer.ChangeMessage($"No existe ningún usuario con nombre {name}.");
        }


        public static User GetUserByName(string name)
        {
            foreach (User user in ListOfUsers)
            {
                if (user.GetName() == name)
                {
                    return user;
                }
            }

            return null;
        }

        public static User GetUserByID(int id)
        {
            foreach (User user in ListOfUsers)
            {
                if (user.GetID() == id)
                {
                    return user;
                }
            }

            return null;
        }

    }
}
