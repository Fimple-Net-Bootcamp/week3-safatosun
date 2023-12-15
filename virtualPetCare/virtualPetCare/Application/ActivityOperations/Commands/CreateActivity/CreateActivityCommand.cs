using AutoMapper;
using virtualPetCare.DBOperations;
using virtualPetCare.Entities;

namespace virtualPetCare.Application.ActivityOperations.Commands.CreateActivity
{   //This class creates new activity.
    public class CreateActivityCommand
    {
        public CreateActivityModel Model { get; set; }
        private readonly VirtualPetCareDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateActivityCommand(VirtualPetCareDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }


        public ActivityCreateViewModel Handle()
        {
            var activity = _dbContext.Activities.SingleOrDefault(activity => activity.Name.ToLower() == Model.Name.ToLower());

            if (activity is not null)
                throw new InvalidOperationException("The activity already exists.");

            activity = _mapper.Map<Activity>(Model);

            _dbContext.Activities.Add(activity);
            _dbContext.SaveChanges();

            var result = _mapper.Map<ActivityCreateViewModel>(activity);
            return result;

        }


    }
    //This class take the activity name from user.
    public class CreateActivityModel
    {
        public string Name { get; set; }
    }
    //This class returns the activity which created with the parameters.
    public class ActivityCreateViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }

}
