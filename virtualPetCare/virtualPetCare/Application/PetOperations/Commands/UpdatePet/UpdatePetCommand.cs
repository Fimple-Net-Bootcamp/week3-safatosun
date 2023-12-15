using AutoMapper;
using virtualPetCare.DBOperations;
using virtualPetCare.Entities;

namespace virtualPetCare.Application.PetOperations.Commands.UpdatePet
{   //This class update the object according to given id and model parameters.
    public class UpdatePetCommand
    {
        public int PetId { get; set; }
        public UpdatePetModel Model { get; set; }   

        private readonly VirtualPetCareDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdatePetCommand(VirtualPetCareDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var pet = _dbContext.Pets.SingleOrDefault(pet=> pet.Id == PetId);   
            
            if(pet is null)
            {
                throw new InvalidOperationException("Pet not found.");
            }

            pet.Name = Model.Name;  
            pet.UserId = Model.UserId; 
            pet.HealthStatusId= Model.HealthStatusId;   
            _dbContext.SaveChanges();

        }

    }
    //This class receive the data to be updated from the user
    public class UpdatePetModel
    {
        public string Name { get; set; }
        public int UserId { get; set; }
        public int HealthStatusId { get; set; }
    }


}
