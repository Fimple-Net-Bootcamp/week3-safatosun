using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using virtualPetCare.Application.ActivityOperations.Commands.CreateActivity;
using virtualPetCare.Application.ActivityOperations.Commands.CreateActivityForPet;
using virtualPetCare.Application.ActivityOperations.Queries.GetActivitiesById;
using static virtualPetCare.Application.ActivityOperations.Commands.CreateActivityForPet.CreateActivityForPetCommand;

namespace virtualPetCare.Controllers
{
    //The requests related to animals are directed to this class.
    [ApiController]
    [Route("api/v1/activities")]
    public class ActivityController : ControllerBase
    {
        private readonly CreateActivityCommand _createActivityCommand;
        private readonly GetActivitiesByIdQuery _getActivitiesByIdQuery;
        private readonly CreateActivityForPetCommand _createActivityForPetCommand;

        public ActivityController(CreateActivityCommand createActivityCommand, GetActivitiesByIdQuery getActivitiesByIdQuery, CreateActivityForPetCommand createActivityForPetCommand)
        {
            _createActivityCommand = createActivityCommand;
            _getActivitiesByIdQuery = getActivitiesByIdQuery;
            _createActivityForPetCommand = createActivityForPetCommand;
        }

        //Adds a new activity
        [HttpPost]
        public IActionResult Create(CreateActivityModel createActivityModel)
        {
            _createActivityCommand.Model = createActivityModel;
            var activity = _createActivityCommand.Handle();
            return StatusCode(201, activity);
        }
        
        //Adds a new activity for the pet.
        [HttpPost("{id:int}")]
        public IActionResult CreateById([FromRoute] int id,[FromBody] CreateActivityForPetModel createActivityModel)
        {
            _createActivityForPetCommand.PetId = id;
            _createActivityForPetCommand.Model = createActivityModel;
            _createActivityForPetCommand.Handle();
            return StatusCode(201);
        }
        //Lists activities the pet can do.
        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute]int id)
        {
            _getActivitiesByIdQuery.PetId = id;
            var result = _getActivitiesByIdQuery.Handle();
            return Ok(result);  
        }



    }
}
