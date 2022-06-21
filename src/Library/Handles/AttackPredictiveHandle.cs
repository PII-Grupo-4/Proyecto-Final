
namespace Battleship
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "atacar p".
    /// </summary>
    public class AttackPredictiveGameHandler : AttackHandle
    {
        public AttackPredictiveGameHandler(BaseHandler next, IPrinter printer, IInputText inputText) : base(next, printer, inputText)
        {
            this.Keywords = new string[] {"atacar predictiva", "atacar p", "Atacar p", "ATACAR p"};

            gameMode = "predictive";
        }

        protected override string Attack(User user, User userAttacked)
        {
            Printer.Print(user.GetPlayer().GetBoardsToPrint());

            Printer.Print(("\nIngrese las coordenadas de ataque con formato LetraNumero (ejemplo: A1)."));
            string stringCoordinate = InputText.Input();

            return Logic.AttackPredictive(stringCoordinate, user, userAttacked);
        }
    }
}