using System;
using System.Collections.Generic;

namespace Battleship
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa los comandos "ataque aereo", "vidente", "satelite".
    /// </summary>
    public class SpecialHabilitiesHandler : BaseHandler
    {
        protected IPrinter Printer;
        protected IInputText InputText;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="SpecialHabilitiesHandler"/>. Esta clase procesa el mensaje "ataque aereo", "vidente", "satelite".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public SpecialHabilitiesHandler(BaseHandler next, IPrinter printer, IInputText inputText) : base(next)
        {
            string a = "ataque aereo";
            string b = "vidente";
            string c = "satelite";
            this.Keywords = new string[] {a, a.ToUpper(), "Ataque aereo", b, b.ToUpper(), "Vidente", c, "satelite", c.ToUpper(), };
            this.Printer = printer;
            this.InputText = inputText;
        }

        /// <summary>
        /// Procesa los mensajes "ataque aereo", "vidente", "satelite" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override void InternalHandle(Message message, out string response)
        {
            try
            {
                User user = UserRegister.GetUser(message.id);

                if (user.getStatus() != $"in {user.GetGameMode()} game")
                {
                    // Estado de user incorrecto
                    response = $"Comando incorrecto. Estado del usuario = {user.getStatus()}";
                    return;
                }
                else
                {
                    Game game = null;
                    User userAttacked = null;
                    try
                    {
                        // Accediendo al otro usuario(player)
                        int gameId = user.GetPlayer().GetGameId();
                        game = GamesRegister.GetGameInPlay(gameId);

                        userAttacked = game.GetOtherUserById(user.GetID());

                        if (userAttacked.getStatus() != $"in {user.GetGameMode()} game")
                        {
                            response = "El contricante no ha posicionado los barcos.";
                            return;
                        }
                    }
                    catch
                    {
                        response = "Error - No se encontró al otro usuario.";
                        return;
                    }
                    
                    try
                    {
                        if (message.Text == "ataque aereo" || message.Text == "Ataque aereo" || message.Text == "ATAQUE AEREO")
                        {
                            if (!user.GetPlayer().GetSpecialsHabilities().Contains("air attack"))
                            {
                                response = "Ya has utilizado la habilidad ataque aereo";
                                return;
                            }

                            Printer.Print(user.GetPlayer().GetBoardsToPrint());

                            Printer.Print(("\nIngrese la fila para realizar el ataque aereo (ejemplo: A)."));
                            string theRow = InputText.Input();

                            if (!Logic.GetRow().Contains(theRow.ToUpper()))
                            {
                                response = "Fila ingresada incorrecta";
                                return;
                            }

                            Logic.AirAttack(theRow, user, userAttacked);

                            user.GetPlayer().UseHability("air attack");

                            response = "Fila atacada con exito";
                        }
                        else if (message.Text == "vidente" || message.Text == "Vidente" || message.Text == "VIDENTE")
                        {
                            if (!user.GetPlayer().GetSpecialsHabilities().Contains("seer"))
                            {
                                response = "Ya has utilizado la habilidad vidente";
                                return;
                            }

                            response = Logic.Seer(userAttacked);

                            user.GetPlayer().UseHability("seer");
                            
                        }
                        else if (message.Text == "satelite" || message.Text == "Satelite" || message.Text == "SATELITE")
                        {
                            if (!user.GetPlayer().GetSpecialsHabilities().Contains("satellite photo"))
                            {
                                response = "Ya has utilizado la habilidad satelite";
                                return;
                            }

                            Printer.Print(user.GetPlayer().GetBoardsToPrint());

                            Printer.Print(("\nIngrese la columna de la foto satelital (ejemplo: 1):"));
                            string theColumn = InputText.Input();

                            List<string> validColumns = new List<string>{"1", "2", "3", "4", "5", "6", "7", "8", "9", "10"};

                            if (!validColumns.Contains(theColumn))
                            {
                                response = "Columna ingresada incorrecta";
                                return;
                            }

                            int columnInt = int.Parse(theColumn);

                            response = "Foto satelital recibida:\n";

                            response += Logic.Satelitte(columnInt, userAttacked.GetPlayer().GetShipsBoard().GetBoard());

                            user.GetPlayer().UseHability("satellite photo");
                        }
                        else
                        {
                            throw new Exception();
                        }

                        response += "\n\n\n\n------Turno cambiado------\n\n"; 
                        Logic.ChangeTurn(message);
                    }
                    catch
                    {
                        response = "Sucedió un error";
                    }
                } 
            }
            catch
            {
                response = "Sucedió un error";
            }
        }
    }
}