using System;
using System.Linq;

namespace Battleship
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "posicionar barco".
    /// </summary>
    public class PositionShipsHandle : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="PositionShipsHandle"/>. Esta clase procesa el mensaje "posicionar barcos".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public PositionShipsHandle(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"posicionar barco", "posicionar nave"};
        }

        /// <summary>
        /// Procesa el mensaje "posicionar barcos" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override void InternalHandle(Message message, out string response)
        {
            try
            {
                User user = UserRegister.GetUser(message.id);

                if (user.getStatus() != "position ships")
                {
                    // Estado de user incorrecto
                    response = $"Comando incorrecto Estado del usuario = {user.getStatus()}";
                    return;
                }
                else
                {
                    // Posicionando naves
                    try
                    {
                        string[] coordinates = message.Text.Split(' ');

                        response = user.GetPlayer().GetShipsBoard().ControlCoordinates(coordinates[2], coordinates[3]);
                        
                        if (user.GetPlayer().GetShipsBoard().GetShipsAlive() >= 4)
                        {
                            user.ChangeStatus($"in {user.GetGameMode()} game");
                            response = "Los barcos estan listos";
                        }
                    }
                    catch
                    {
                        response = ("Coordenadas ingresadas incorrectas.");
                    }
                } 
            }
            catch
            {
                response = "Sucedió un error";
            }
        }

        
        protected override bool CanHandle(Message message)
        {
            try
            {
                string[] words = message.Text.Split(' ');

                if (this.Keywords.Contains(words[0]+" "+words[1]))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            

        }
        
    }
}