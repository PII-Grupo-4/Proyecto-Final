
namespace Battleship
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "buscar partida predictiva".
    /// Como se puede observar, tanto las clases search como attack del tipo de juego predictivo,
    /// heredan de search y attack estandar. De esta forma las clases quedan abierta a la extesión
    /// pero cerradas a la mosificación, respetandio el OCP.
    /// </summary>
    public class SearchPredictiveGameHandler : SearchGameHandler
    {
        public SearchPredictiveGameHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"buscar partida predictiva"};
            gameMode = "predictive";
        }
    }
}