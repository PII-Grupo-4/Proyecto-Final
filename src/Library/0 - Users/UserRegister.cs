using System.Collections.Generic;

 /// <summary>
/// UserRegister es una clase estática que funciona como base de datos de los usuarios. 
/// Primero se debe crear un usuario, luego se debe acceder al usuario creado.
/// Se accede a los usuarios a travez del nombre, en el caso que no existe, se devuelve un valor null.
/// 
/// UserRegister cumple con el patrón creator, ya que es la misma los agrega, contiene y guarda intancias de User
/// Por ende, debe ser la clase creadora de User
/// </summary>


namespace Battleship
{
    static public class UserRegister
    {
        private static List<User> ListOfUsers = new List<User> ();

        /// <summary>
        /// Agrega a la lista de usuarios
        /// </summary>
        /// <param name="user">usuario a agregar</param>
        public static void CreateUser(long id)
        {
            User user = new User(id);
            ListOfUsers.Add(user);
        }

        /// <summary>
        /// Acceder al registro de usuarios por ID
        /// </summary>
        /// <param name="UserId">identificacion del usuario</param>
        /// <returns>lista de usuarios "registrados"</returns>
        public static User GetUser(long UserId)
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
