
namespace Battleship
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "eliminar usuario".
    /// </summary>
    public class RemoveUserHandle : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="RemoveUserHandler"/>. Esta clase procesa el mensaje "eliminar usuario".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public RemoveUserHandle(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"eliminar usuario"};
        }

        /// <summary>
        /// Procesa el mensaje "eliminar usuario" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override void InternalHandle(Message message, out string response)
        {
            IPrinter printer = new ConsolePrinter();
            IInputText inputText = new ConsoleInputText(); 

            string userId = "";

            printer.Print("Ingrese la Id del usuario que quiere eliminar:");
            userId = inputText.Input();

            try
            {
                int IntId = int.Parse(userId);

                response = UserRegister.RemoveUser(IntId);
            }
            catch
            {
                response = "Id incorrecta, debe ser un número.";
            }
            
        }
    }
}