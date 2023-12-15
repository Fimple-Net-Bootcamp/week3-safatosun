using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using virtualPetCare.Application.PetOperations.Commands.CreatePet;
using virtualPetCare.Application.PetOperations.Commands.UpdatePet;
using virtualPetCare.Application.PetOperations.Queries.GetPetById;
using virtualPetCare.Application.PetOperations.Queries.GetPets;

namespace virtualPetCare.Controllers
{   //The requests related to pets are directed to this class.

    [ApiController]
    [Route("api/v1/pets")]
    public class PetController : ControllerBase
    {
        private readonly CreatePetCommand _createPetCommand;
        private readonly GetPetByIdQuery _getPetByIdQuery;
        private readonly GetPetsQuery _getPetsQuery;
        private readonly UpdatePetCommand _updatePetCommand;

        public PetController(CreatePetCommand createPetCommand, GetPetByIdQuery getPetByIdQuery, GetPetsQuery getPetsQuery, UpdatePetCommand updatePetCommand)
        {
            _createPetCommand = createPetCommand;
            _getPetByIdQuery = getPetByIdQuery;
            _getPetsQuery = getPetsQuery;
            _updatePetCommand = updatePetCommand;
        }
        //Lists all pets.
        [HttpGet]
        public IActionResult GetAll()
        {
            var pets = _getPetsQuery.Handle();
            return Ok(pets);    
        }
        //Returns information for a specific pet.

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute]int id)
        {
            _getPetByIdQuery.PetId = id;
            var pet = _getPetByIdQuery.Handle();
            return Ok(pet); 
        }
        //Creates new pet.
        [HttpPost]
        public IActionResult Create([FromBody]CreatePetModel createPetModel)
        {
            _createPetCommand.Model = createPetModel;
            var pet = _createPetCommand.Handle();
            return CreatedAtAction(nameof(GetById), new {id=pet.Id},pet);
        }
        //Updates the pet's information.

        [HttpPut("{id:int}")]
        public IActionResult Update([FromRoute]int id,[FromBody]UpdatePetModel updatePetModel)
        {
            _updatePetCommand.PetId= id;    
            _updatePetCommand.Model= updatePetModel;
            _updatePetCommand.Handle();
            return Ok();

        }
        
    }
}
