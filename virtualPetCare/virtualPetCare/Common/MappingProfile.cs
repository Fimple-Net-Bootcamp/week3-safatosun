using AutoMapper;
using virtualPetCare.Application.ActivityOperations.Commands.CreateActivity;
using virtualPetCare.Application.ActivityOperations.Queries.GetActivitiesById;
using virtualPetCare.Application.FoodOperations.Queries.GetFoods;
using virtualPetCare.Application.HealthStatus.Commands.PatchHealthStatus;
using virtualPetCare.Application.HealthStatusOperations.Queries.GetHealthStatusByIdQuery;
using virtualPetCare.Application.PetOperations.Commands.CreatePet;
using virtualPetCare.Application.PetOperations.Commands.UpdatePet;
using virtualPetCare.Application.PetOperations.Queries.GetPetById;
using virtualPetCare.Application.PetOperations.Queries.GetPets;
using virtualPetCare.Application.UserOperations.Commands.CreateUser;
using virtualPetCare.Application.UserOperations.Queries.GetUserById;
using virtualPetCare.Entities;

namespace virtualPetCare.Common
{  //This class contains the necessary map for classes.

    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<CreateUserModel,User>();
            CreateMap<User, UserViewModel>();
            CreateMap<User, UserCreateViewModel>();
            CreateMap<CreatePetModel,Pet>();
            CreateMap<Pet,PetCreateViewModel>();
            CreateMap<Pet, PetViewModel>().ForMember(dest => dest.UserName, opt => opt.MapFrom(src=>src.User.Name));
            CreateMap<Pet, PetsViewModel>().ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Name));
            CreateMap<UpdatePetModel, Pet>();
            CreateMap<HealthStatus,HealthStatusViewModel>();
            CreateMap<Pet, PatchHealthStatusModel>().ReverseMap();
            CreateMap<CreateActivityModel,Activity>();
            CreateMap<Activity, ActivityCreateViewModel>();
            CreateMap<Activity, ActivitiesViewModel>();
            CreateMap<Food,FoodViewModel>();
        }
    }
}
