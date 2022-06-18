
namespace Battleship
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "posicionar barco".
    /// </summary>
    public class PositionShipHandle : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="PositionShipHandle"/>. Esta clase procesa el mensaje "posicionar barco".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public PositionShipHandle(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"posicionar barco", "Posicionar barco"};
        }

        /// <summary>
        /// Procesa el mensaje "posicionar barco" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override void InternalHandle(Message message, out string response)
        {
            try
            {
                User user = UserRegister.GetUser(message.id);

                if (user.getStatus() != "")
                {
                    response = $"Comando incorrecto. Estado del usuario = {user.getStatus()}";
                    return;
                }
                else
                {
                    response = "";
                } 
            }
            catch
            {
                response = "Sucedió un error";
            }
        }
    }
}