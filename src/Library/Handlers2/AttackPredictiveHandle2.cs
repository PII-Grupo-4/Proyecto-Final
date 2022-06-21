using System;
using System.Linq;

namespace Battleship
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "atacar p".
    /// </summary>
    public class AttackPredictiveHandler : AttackHandle
    {
        public AttackPredictiveHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"predictivo ataque", "p ataque"};

            gameMode = "predictive";
        }

        protected override string Attack(User user, User userAttacked, Message message)
        {
            string[] coordinates = message.Text.Split(' ');

            string stringCoordinate = coordinates[2];

            return Logic.AttackPredictive(stringCoordinate, user, userAttacked);
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