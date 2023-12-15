using AutoMapper;
using Microsoft.EntityFrameworkCore;
using virtualPetCare.DBOperations;

namespace virtualPetCare.Application.ActivityOperations.Queries.GetActivitiesById
{   //This class returns the activities according to given pet id value.
    public class GetActivitiesByIdQuery
    {
        public int PetId { get; set; }

        private readonly VirtualPetCareDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetActivitiesByIdQuery(VirtualPetCareDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<ActivitiesViewModel> Handle()
        {
                     
            var activities = _dbContext.Activities.Include(a=>a.Pets).Where(a=>a.Pets.Any(p=> p.Id==PetId)).ToList();

            List<ActivitiesViewModel> activitiesViewModel = _mapper.Map<List<ActivitiesViewModel>>(activities);

            return activitiesViewModel;
        }

    }
    //View Model to return to the user.
    public class ActivitiesViewModel
    {
        public  String Name;
    }
}
