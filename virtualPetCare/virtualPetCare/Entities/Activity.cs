namespace virtualPetCare.Entities
{   
    //This class represents the activity table in the database.
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Pet> Pets { get; set; }
    }
}
