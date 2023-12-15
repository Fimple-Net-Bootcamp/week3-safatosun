using AutoMapper;
using Microsoft.Identity.Client;
using virtualPetCare.DBOperations;

namespace virtualPetCare.Application.UserOperations.Queries.GetUserById
{ //This class returns the user whose Id value is given.
    public class GetUserByIdQuery
    {
        public int UserId { get; set; } 
        
        private readonly VirtualPetCareDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUserByIdQuery(VirtualPetCareDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public UserViewModel Handle()
        {
            var user = _dbContext.Users.Where(user=> user.Id ==UserId).SingleOrDefault();
            if (user is null)
                throw new InvalidOperationException("User not found.");

            UserViewModel viewModel = _mapper.Map<UserViewModel>(user);
            return viewModel;   

        }

    }
    //View model to return to user
    public class UserViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
    }
}
