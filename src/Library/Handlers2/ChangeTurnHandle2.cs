
namespace Battleship
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "cambiar turno".
    /// </summary>
    public class ChangeTurnHandle : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ChangeTurnHandle"/>. Esta clase procesa el mensaje "cambiar turno".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public ChangeTurnHandle(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"cambiar turno", "cambio"};
        }

        /// <summary>
        /// Procesa el mensaje "cambiar turno" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override void InternalHandle(Message message, out string response)
        {
            Logic.ChangeTurn(message);
            response = "\n\n------Turno cambiado------\n\n";    
        }
    }
}