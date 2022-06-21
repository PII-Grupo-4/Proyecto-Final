
namespace Battleship
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "buscar partida predictiva".
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