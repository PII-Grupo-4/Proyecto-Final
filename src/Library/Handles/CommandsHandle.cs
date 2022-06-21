using System;

namespace Battleship
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "comandos".
    /// </summary>
    public class CommandsHandle : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CommandsHandle"/>. Esta clase procesa el mensaje "Comandos".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public CommandsHandle(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"comandos", "comando"};
        }

        /// <summary>
        /// Procesa el mensaje "comandos" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override void InternalHandle(Message message, out string response)
        {
            try
            {
                User user = UserRegister.GetUser(message.id);
                string forInGame = "\n- ver tableros\n- aereo <fila> (ejemplo:aereo A)\n- vidente\n- satelite <columna (ejemplo: satelite 1)>\n- cambiar turno\n- salir";

                if (user.getStatus() == "start")
                {
                    response = $"\nComandos en estado '{user.getStatus()}'\n- buscar partida\n- buscar partida predictiva\n- ver partidas jugadas\n- cambiar turno\n- salir";
                }
                else if(user.getStatus() == "lobby")
                {
                    response = $"\nComandos en estado '{user.getStatus()}'\n- salir lobby\n- cambiar turno\n- salir";
                } 
                else if(user.getStatus() == "position ships")
                {
                    response = $"\nComandos en estado '{user.getStatus()}'\n- posicionar barcos <coordenada> <orientación> (ejemplo: 'posicionar barco a1 down')\n      Orientaciones = up, down, left, right\n- ver tableros\n- cambiar turno\n- salir";
                } 
                else if(user.getStatus() == $"in normal game")
                {
                    response = $"\nComandos en estado '{user.getStatus()}'\n- atacar <coordenada> (ejemplo: 'atacar A1'){forInGame}";
                }
                else if(user.getStatus() == $"in predictive game")
                {
                    response = $"\nComandos en estado '{user.getStatus()}'\n- p ataque <coordenada> (ejemplo: 'p ataque A1'){forInGame}";
                }
                else
                {
                    throw new Exception();
                }
            }
            catch
            {
                response = "Sucedió un error";
            }
        }
    }
}