using AutoMapper;
using Microsoft.EntityFrameworkCore;
using virtualPetCare.Application.ActivityOperations.Commands.CreateActivity;
using virtualPetCare.DBOperations;

namespace virtualPetCare.Application.ActivityOperations.Commands.CreateActivityForPet
{ //This class add the activity to the pet with the given pet ID.
    public class CreateActivityForPetCommand
    {
        public int PetId { get; set; }
        public CreateActivityForPetModel Model { get; set; }
        private readonly VirtualPetCareDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateActivityForPetCommand(VirtualPetCareDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public void Handle()
        {

            var pet = _dbContext.Pets.SingleOrDefault(p=>p.Id==PetId);
            if (pet is null)
                throw new InvalidOperationException("The pet not found.");

            var activity = _dbContext.Activities.Include(a=>a.Pets).SingleOrDefault(activity => activity.Id == Model.ActivityId);

            if (activity is null)
                throw new InvalidOperationException("The activity not found.");

            activity.Pets.Add(pet);
            _dbContext.SaveChanges();

                    
        }
        //This class take the activity id from user.
        public class CreateActivityForPetModel
        {
            public int ActivityId { get; set; }
        }

    }
}
