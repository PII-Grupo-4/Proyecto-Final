
namespace Battleship
{
    public class User
    {

        static int UserID_counter = 0;
        private string Name {get; set; } 
        private int Id {get; set; } 


        public User(string name)
        {
            this.Name = name;
            this.Id = UserID_counter;
            UserID_counter ++;
        }


        public string GetName()
        {
            return this.Name;
        }         

        public int GetID()
        {
            return this.Id;
        } 

    }
}