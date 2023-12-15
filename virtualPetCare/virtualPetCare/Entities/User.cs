namespace virtualPetCare.Entities
{   //This class represents the user table in the database.
    public class User
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public List<Pet> Pets { get; set; }
        
    }
}
 