using AutoMapper;
using Microsoft.EntityFrameworkCore;
using virtualPetCare.DBOperations;

namespace virtualPetCare.Application.FoodOperations.Commands.CreateFoodForPets
{    //This class adds food to the pet with the given pet ID.
    public class CreateFoodForPetCommand 
    {
        public int PetId { get; set; }
        public CreateFoodForPetModel Model { get; set; }

        private readonly VirtualPetCareDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateFoodForPetCommand(VirtualPetCareDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var pet = _dbContext.Pets.SingleOrDefault(p=>p.Id==PetId);

            if (pet is null)
            {
                throw new InvalidOperationException("The pet not found.");
            }

            var food = _dbContext.Foods.Include(f=>f.Pets).SingleOrDefault(f =>f.Id== Model.FoodId);

            if (food is null)
            {
                throw new InvalidOperationException("The food not found.");
            }

            food.Pets.Add(pet);
            _dbContext.SaveChanges();

        }

    }
    //This class take the Food Id from the user.
    public class CreateFoodForPetModel
    {
        public int FoodId { get; set; }
    }
    
}
