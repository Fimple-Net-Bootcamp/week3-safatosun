namespace virtualPetCare.Entities
{
    //This class represents the pet table in the database.
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public int? HealthStatusId { get; set; }
        public HealthStatus HealthStatus { get; set; }
        public List<Activity> Activity { get; set; }
        public List<Food> Foods { get; set; } 

    }
}
