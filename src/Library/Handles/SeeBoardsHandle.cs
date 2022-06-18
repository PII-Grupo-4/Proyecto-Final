
namespace Battleship
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "ver tableros".
    /// </summary>
    public class SeeBoardsHandle : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="SeeBoardsHandle"/>. Esta clase procesa el mensaje "ver tableros".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public SeeBoardsHandle(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"ver tableros", "Ver tableros", "VER TABLEROS", "TABLEROS", "tableros", "Tableros"};
        }

        /// <summary>
        /// Procesa el mensaje "ver tableros" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override void InternalHandle(Message message, out string response)
        {
            try
            {
                User user = UserRegister.GetUser(message.id);

                if (user.getStatus() != "position ships" && user.getStatus() != "in game")
                {
                    response = $"Comando incorrecto. Estado del usuario = {user.getStatus()}";
                    return;
                }
                else
                {
                    response = user.GetPlayer().GetBoardsToPrint();
                }
                
            }
            catch
            {
                response = "Sucedió un error";
            }
        }
    }
}