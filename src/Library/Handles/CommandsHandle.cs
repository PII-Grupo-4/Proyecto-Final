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
            this.Keywords = new string[] {"comandos", "Comandos", "COMANDOS", "comando", "Comando", "COMANDO"};
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

                if (user.getStatus() == "start")
                {
                    response = $"\nComandos en estado '{user.getStatus()}'\n- buscar partida\n- ver partidas jugadas\n- cambiar turno\n- salir";
                }
                else if(user.getStatus() == "lobby")
                {
                    response = $"\nComandos en estado '{user.getStatus()}'\n- salir lobby\n- cambiar turno\n- salir";
                } 
                else if(user.getStatus() == "position ships")
                {
                    response = $"\nComandos en estado '{user.getStatus()}'\n- posicionar barcos\n- ver tableros\n- cambiar turno\n- salir";
                } 
                else if(user.getStatus() == "in game")
                {
                    response = $"\nComandos en estado '{user.getStatus()}'\n- atacar\n- ver tableros\n- cambiar turno\n- salir";
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