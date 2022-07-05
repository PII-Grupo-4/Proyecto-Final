using System.Collections.Generic;

namespace Battleship
{
/// <summary>
/// SpecialHabilities es la clase que contiene las habilidades especiales del jugador
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