using System;
using System.Linq;
using Telegram.Bot.Types;

namespace Battleship
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "cuenta".
    /// Se encarga de devolver la cuenta de los diferentes caracteres implementados en el tablero
    /// </summary>
    public class CountBoardHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CountBoardHandler"/>. Esta clase procesa el mensaje "cuenta".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public CountBoardHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"cuenta"};
        }

        /// <summary>
        /// Procesa el mensaje "cuenta" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override void InternalHandle(Message message, out string response)
        {
            try
            {
                User user = UserRegister.GetUser(message.From.Id);

                if (user.getStatus() != "position ships" && user.getStatus() != $"in {user.GetGameMode()} game")
                {
                    // Estado de user incorrecto
                    response = $"Comando incorrecto. Estado del usuario = {user.getStatus()}";
                    return;
                }
                 else
                {
                    // Devolviendo cantidad de aciertos o agua en el tablero
                    response = user.GetPlayer().GetCountCaracters();
                    response += $"{user.GetPlayer().GetCountCaracters()}Fueron al agua \n {user.GetPlayer().GetCountCaracters2()}Fueron a barcos ";
                }
                
            }
            catch(UserNotCreatedException)
            {
                response = "Debe crear un usuario\nIngrese 'Crear Usuario':\n";
            }
            catch
            {
                response = "Sucedió un error, vuelve a intentar";
            }
        }
    }
}