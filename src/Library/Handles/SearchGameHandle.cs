
namespace Battleship
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "buscar partida".
    /// </summary>
    public class SearchGameHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="SearchGameHandler"/>. Esta clase procesa el mensaje "buscar partida".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public SearchGameHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"buscar partida", "Buscar partida", "BUSCAR PARTIDA"};
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
                User user = UserRegister.GetUser(message.id);

                if (user.getStatus() != "start")
                {
                    // Estado de user incorrecto
                    response = $"Comando incorrecto. Estado del usuario = {user.getStatus()}";
                    return;
                }
                else
                {
                    if (Lobby.NumberUsersLobby() >= 1)
                    {
                        // Si ya hay otro usuario en el Lobby, se crea la partida
                        User user2 = Lobby.GetAndRemoveUser();
                        user.RestartPlayer();
                        user2.RestartPlayer();

                        Game game = new Game(user, user2);
                        GamesRegister.AddGame(game);

                        user.GetPlayer().AddGameId(game.GetId());
                        user2.GetPlayer().AddGameId(game.GetId());

                        user.ChangeStatus(3);
                        user2.ChangeStatus(3);

                        response = $"Se ha unido a una partida con id {game.GetId()}";
                    }
                    else
                    {
                        // Agregando el usuario al Lobby
                        Lobby.AddUser(user);
                        user.ChangeStatus(2);
                        response = "Entraste a la sala de espera.";
                    }
                }
            }
            catch
            {
                response = "Sucedió un error.";
            }
        }
    }
}