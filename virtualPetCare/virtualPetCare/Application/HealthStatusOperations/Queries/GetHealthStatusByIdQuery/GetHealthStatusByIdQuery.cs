using AutoMapper;
using Microsoft.EntityFrameworkCore;
using virtualPetCare.DBOperations;
using virtualPetCare.Entities;

namespace virtualPetCare.Application.HealthStatusOperations.Queries.GetHealthStatusByIdQuery
{   //It returns the health status of the pet with the given pet ID.
    public class GetHealthStatusByIdQuery
    {
        public int PetId { get; set; }

        private readonly VirtualPetCareDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetHealthStatusByIdQuery(VirtualPetCareDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public HealthStatusViewModel Handle()
        {
            var healthStatus = _dbContext.HealthStatuses.Include(h => h.Pets).Where(h => h.Pets.Any(p => p.Id == PetId)).SingleOrDefault();

            if (healthStatus is null)
                throw new InvalidOperationException("Pet Health Status Not Found.");

            HealthStatusViewModel healthStatusViewModel = _mapper.Map<HealthStatusViewModel>(healthStatus);

            return healthStatusViewModel;

        }

    }
    //Model view to return the health satus to user
    public class HealthStatusViewModel
    {
        public string Name { get; set; }
    }

}
