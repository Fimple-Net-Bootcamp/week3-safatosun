using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using virtualPetCare.Application.PetOperations.Queries.GetPetById;
using virtualPetCare.DBOperations;

namespace virtualPetCare.Application.HealthStatus.Commands.PatchHealthStatus
{   //This class update the pet's health status.
    public class PatchHealthStatusCommand
    {
        public int PetId { get; set; }
        public JsonPatchDocument<PatchHealthStatusModel> Model { get; set; }

        private readonly VirtualPetCareDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly GetPetByIdQuery _getPetByIdQuery;

        public PatchHealthStatusCommand(VirtualPetCareDbContext dbContext, IMapper mapper, GetPetByIdQuery getPetByIdQuery)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _getPetByIdQuery = getPetByIdQuery;
        }

        public void Handle()
        {
            var pet = _dbContext.Pets.SingleOrDefault(p=>p.Id == PetId);   
            
            if(pet is null)
            {
                throw new InvalidOperationException("Pet not found.");
            }

            var petToPatch = _mapper.Map<PatchHealthStatusModel>(pet);

            Model.ApplyTo(petToPatch);

            var healthStatus = _dbContext.HealthStatuses.SingleOrDefault(h => h.Id == petToPatch.HealthStatusId);
            if(healthStatus is null)
            {
                throw new InvalidOperationException("Health status not found.");
            }

            _mapper.Map(petToPatch,pet);

            _dbContext.SaveChanges();   

        }
    }
    //This model is used to take the healthStatusId from the user.
    public class PatchHealthStatusModel
    {
        public int HealthStatusId { get; set; }
    }

}
