using Microsoft.EntityFrameworkCore;
using virtualPetCare.Entities;

namespace virtualPetCare.DBOperations
{   //This class represent the database and its tables.
    public class VirtualPetCareDbContext : DbContext
    {
        public VirtualPetCareDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Pet> Pets { get; set; }           
        public DbSet<HealthStatus> HealthStatuses { get; set; }
        public DbSet<Activity> Activities { get; set; } 
        public DbSet<Food> Foods { get; set; }  

    }
}
