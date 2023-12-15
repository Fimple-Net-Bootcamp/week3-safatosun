using AutoMapper;
using Microsoft.EntityFrameworkCore;
using virtualPetCare.DBOperations;

namespace virtualPetCare.Application.PetOperations.Queries.GetPetById
{   //A specific pet is returned according to the given id value.
    public class GetPetByIdQuery
    {
        public int PetId { get; set; }

        private readonly VirtualPetCareDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetPetByIdQuery(VirtualPetCareDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public PetViewModel Handle()
        {
            var pet = _dbContext.Pets.Include(p=>p.User).SingleOrDefault(pet=> pet.Id==PetId);

            if (pet is null)
                throw new InvalidOperationException("Pet Not Found.");

            PetViewModel viewModel = _mapper.Map<PetViewModel>(pet);    
            return viewModel;

        }

    }
    //Model view to return to user
    public class PetViewModel
    {
        public string Name { get; set; }
        public string UserName { get; set; }
    }

}
