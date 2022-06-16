
namespace Battleship
{
    public class User
    {

        private string Name {get; set; } 
        private int id {get; set; } 


        public User(string name, int idNumber)
        {
            this.Name = name;
            this.id = idNumber;
        }


        public string GetName()
        {
            return this.Name;
        }         

        public int GetID()
        {
            return this.id;
        } 

    }
}