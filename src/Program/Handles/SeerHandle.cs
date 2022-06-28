using System;
using System.Collections.Generic;
using System.Linq;
using Telegram.Bot.Types;

namespace Battleship
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa los comandos "vidente".
    /// </summary>
    public class SeerHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="SeerHandler"/>. Esta clase procesa el mensaje "vidente".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public SeerHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"vidente"};
        }

        /// <summary>
        /// Procesa los mensajes "vidente" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override void InternalHandle(Message message, out string response)
        {
            try
            {
                User user = UserRegister.GetUser(message.From.Id);

                if (user.GetTurn() == false)
                {
                    response = "Aún no es tu turno";
                    return;
                }

                if (user.getStatus() != $"in {user.GetGameMode()} game")
                {
                    // Estado de user incorrecto
                    response = $"Comando incorrecto. Estado del usuario = {user.getStatus()}";
                    return;
                }
                else
                {
                    Game game = null;
                    User userAttacked = null;
                    try
                    {
                        // Accediendo al otro usuario(player)
                        int gameId = user.GetPlayer().GetGameId();
                        game = GamesRegister.GetGameInPlay(gameId);

                        userAttacked = game.GetOtherUserById(user.GetID());

                        if (userAttacked.getStatus() != $"in {user.GetGameMode()} game")
                        {
                            response = "El contricante no ha posicionado los barcos.";
                            return;
                        }
                    }
                    catch
                    {
                        response = "Error - No se encontró al otro usuario.";
                        return;
                    }
                    
                    try
                    {
                        if (!user.GetPlayer().GetSpecialsHabilities().Contains("seer"))
                        {
                            response = "Ya has utilizado la habilidad vidente";
                            return;
                        }

                        response = Logic.Seer(userAttacked);

                        user.GetPlayer().UseHability("seer");

                        response += "\n\n\n\n------Turno cambiado------\n\n"; 
                        user.ChangeTurn();
                        userAttacked.ChangeTurn();
                    }
                    catch
                    {
                        response = "Sucedió un error";
                    }
                } 
            }
            catch
            {
                response = "Sucedió un error, vuelve a intentar";
            }
        }
        
    }
}