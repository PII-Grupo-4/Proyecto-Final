using System;
using System.Linq;
using Telegram.Bot.Types;

namespace Battleship
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "ver agua".
    /// Se encarga de imprimir los tiros "Agua" de los usuarios para que pueda visualizarlos
    /// </summary>
    public class ViewWaterHandle : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="SeeBoardsHandle"/>. Esta clase procesa el mensaje "ver agua".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public ViewWaterHandle(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"ver agua", "Ver agua", "/ver_agua"};
        }

        /// <summary>
        /// Procesa el mensaje "ver agua" y retorna true; retorna false en caso contrario.
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
                    // Devolviendo los tiros "Agua" como string
                    response = user.GetPlayer().GetWaterToPrint();
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