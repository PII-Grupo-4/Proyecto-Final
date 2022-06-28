using System;
using System.Linq;
using Telegram.Bot.Types;

namespace Battleship
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "buscar partida".
    /// </summary>
    public class SearchGameHandler : BaseHandler
    {
        protected string gameMode; // Para el modo de juego
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="SearchGameHandler"/>. Esta clase procesa el mensaje "buscar partida".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public SearchGameHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"buscar partida"};
            gameMode = "normal";
        }

        /// <summary>
        /// Procesa el mensaje "Buscar partida" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override void InternalHandle(Message message, out string response)
        {
            try
            {
                User user = UserRegister.GetUser(message.From.Id);

                if (user.getStatus() != "start")
                {
                    // Estado de user incorrecto
                    response = $"Comando incorrecto. Estado del usuario = {user.getStatus()}";
                    return;
                }
                else
                {
                    if (Lobby.NumberUsersLobby(gameMode) >= 1)
                    {
                        // Si ya hay otro usuario en el Lobby, se crea la partida
                        User user2 = Lobby.GetAndRemoveUser(gameMode);
                        user.RestartPlayer();
                        user2.RestartPlayer();

                        Game game = new Game(user, user2);
                        GamesRegister.AddGame(game);

                        user.GetPlayer().AddGameId(game.GetId());
                        user2.GetPlayer().AddGameId(game.GetId());

                        user.ChangeTurn();

                        user.ChangeGameMode(gameMode);
                        user.ChangeStatus("position ships");
                        user2.ChangeStatus("position ships");

                        response = $"Se ha unido a una partida con id {game.GetId()}";
                        user2.ChangeTextToPrint(response);
                    }
                    else
                    {
                        // Agregando el usuario al Lobby
                        user.ChangeGameMode(gameMode);
                        Lobby.AddUser(user);
                        user.ChangeStatus("lobby");
                        response = $"Entraste a la sala de espera. Modo de juego: {gameMode}";
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