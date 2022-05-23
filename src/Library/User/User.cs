using System.Collections.Generic;

namespace BatallaNaval
{
    public class User
    {
        private string name {get; set; } 
        private int id {get; set; } 

        private GameSummariesRegister ListOfGameSummaries;


        private GameSummariesRegister GetGameSummaries(){
            return ListOfGameSummaries;
        }

    }
}