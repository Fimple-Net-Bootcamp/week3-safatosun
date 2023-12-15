namespace virtualPetCare.Entities
{
    //This class represents the food table in the database.
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Pet> Pets { get; set; }
    }
}
