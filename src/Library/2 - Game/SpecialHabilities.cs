using System.Collections.Generic;

namespace Battleship
{
/// <summary>
/// SpecialHabilities es la clase que contiene las habilidades especiales del jugador.
/// Las contiene en una lista representadas como string.
/// Anteriormente, el Player contenia dicha lista, pero creamos una nueva clase por si en un futuro
/// se quieren agregar nuevas habilidades, y así evitamos que Player tenga otra causa de modificación.
/// La logica de las habilidades se encuentran en Logic, esta clase solamente es utilizada como control
/// de que habilidades todavia no ha utilizado el Player, ya que solamente se pueden utilizar una vez 
/// en el juego.
/// </summary>
    public class SpecialHabilities
    {

        /// <summary>
        /// Lista con las habilidades del player representadas como string, solo se pueden usar una vez.
        /// Cuandos se utiliza una habilidad determinada, la misma se elimina de la lista 
        /// </summary>
        /// <value></value>
        private List<string> specialHabilitiesList = new List<string>{"air attack", "seer", "satellite photo"};
        


        /// <summary>
        /// Se ingresa una string, correspondiente al nombre de una habilidad,
        /// y se elimina la misma de la lista de string con las representaciones de 
        /// las habilidades especiales
        /// "air attack", "seer", "satellite photo"
        /// </summary>
        /// <param name="hability"></param>
        public void UseHability(string hability)
        {
            foreach (string h in this.specialHabilitiesList)
            {
                if (h == hability)
                {
                    this.specialHabilitiesList.Remove(h);
                    break;
                }  
            }
        }

        /// <summary>
        /// Retorna la lista con las string que representa las habilidades especiales del usuario
        /// </summary>
        /// <returns>Lista con string que representan las habilidades especiales</returns>
        public List<string> GetSpecialsHabilities()
        {
           return specialHabilitiesList;
        }
    }
}