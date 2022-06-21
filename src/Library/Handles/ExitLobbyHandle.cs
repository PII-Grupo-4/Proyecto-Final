
namespace Battleship
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "buscar partida".
    /// </summary>
    public class ExitLobbyHandle : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ExitLobbyHandle"/>. Esta clase procesa el mensaje "salir lobby".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public ExitLobbyHandle(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"salir lobby", "Salir lobby", "SALIR LOBBY"};
        }

        /// <summary>
        /// Procesa el mensaje "salir lobby" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override void InternalHandle(Message message, out string response)
        {
            try
            {
                User user = UserRegister.GetUser(message.id);

                if (user.getStatus() != "lobby")
                {
                    // Estado de user incorrecto
                    response = $"Comando incorrecto. Estado del usuario = {user.getStatus()}";
                    return;
                }
                else
                {
                    Lobby.RemoveUser(user);
                    user.ChangeStatus("start");
                    response = "Has salido de la sala de espera";
                }
            }
            catch
            {
                response = "Sucedió un error.";
            }
        }
    }
}