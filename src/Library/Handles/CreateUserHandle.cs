
namespace Battleship
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "crear usuario".
    /// </summary>
    public class CreateUserHandle : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CreateUserHandler"/>. Esta clase procesa el mensaje "crear usuario".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public CreateUserHandle(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"crear usuario"};
        }

        /// <summary>
        /// Procesa el mensaje "crear usuario" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override void InternalHandle(Message message, out string response)
        {
            IPrinter printer = new ConsolePrinter();

            string nameUser = "";

            while (nameUser == "")
            {
                printer.Print("Ingrese el nombre del usuario (no puede ser vacio):");
                
            }
            
            

            response = "";
        }
    }
}