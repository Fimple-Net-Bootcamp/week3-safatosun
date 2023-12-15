namespace virtualPetCare.Entities
{   //This class represents the healthstatus table in the database.
    public class HealthStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Pet> Pets { get; set; }
    }
}
