using System;
using System.Linq;
using Telegram.Bot.Types;

namespace Battleship
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "ver tocados".
    /// Se encarga de imprimir los tiros "Tocados" de los usuarios para que pueda visualizarlos
    /// </summary>
    public class ViewHitsHandle : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="SeeBoardsHandle"/>. Esta clase procesa el mensaje "ver tocados".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public ViewHitsHandle(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"ver tocados", "Ver tocados", "/ver_tocados"};
        }

        /// <summary>
        /// Procesa el mensaje "ver tocados" y retorna true; retorna false en caso contrario.
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
                    // Devolviendo los tiros "tocados" como string
                    response = user.GetPlayer().GetHitsToPrint();
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