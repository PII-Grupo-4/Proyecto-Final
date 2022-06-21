
namespace Battleship
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "posicionar barco".
    /// </summary>
    public class PositionShipsHandle : BaseHandler
    {
        private IPrinter Printer;
        private IInputText InputText;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="PositionShipsHandle"/>. Esta clase procesa el mensaje "posicionar barcos".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public PositionShipsHandle(BaseHandler next, IPrinter printer, IInputText inputText) : base(next)
        {
            this.Keywords = new string[] {"posicionar barcos", "Posicionar barcos", "POSICIONAR BARCOS"};
            this.Printer = printer;
            this.InputText = inputText;
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
                    response = $"Comando incorrecto. Estado del usuario = {user.getStatus()}";
                    return;
                }
                else
                {
                    string intructions = "";
                    int sizeShip;

                    // Posicionando naves
                    while (user.GetPlayer().GetShipsBoard().GetShipsAlive() < 4 && intructions != "salir")
                    {
                        sizeShip = 5 - user.GetPlayer().GetShipsBoard().GetShipsAlive();
                        try
                        {
                            Printer.Print(user.GetPlayer().GetShipsBoard().BoardToString());

                            Printer.Print($"\nIngrese las coordenadas y la orientacion separadas por un espacio. Tamaño del barco = {sizeShip}.\n    coordenadas: LetraNumero (ejemplo: A1)\n    orientacion: 'UP', 'DOWN', 'LEFT' o 'RIGHT'.\n Ingrese 'salir' para volver.");
                            intructions = InputText.Input();
                            string[] coordinates = intructions.Split(' ');

                            Printer.Print(user.GetPlayer().GetShipsBoard().ControlCoordinates(coordinates[0], coordinates[1]));
                        }
                        catch
                        {
                            Printer.Print("Coordenadas ingresadas incorrectas.");
                        }
                    }
                    if (intructions == "salir")
                    {
                        // Saliendo de posicionar naves
                        response = "Saliendo de posicionar barcos";
                        return;
                    }

                    // Cambiando el estado del user
                    Printer.Print(user.GetPlayer().GetShipsBoard().BoardToString());
                    user.ChangeStatus($"in {user.GetGameMode()} game");
                    response = "Los barcos estan listos";
                } 
            }
            catch
            {
                response = "Sucedió un error";
            }
        }
    }
}