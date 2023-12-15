using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using virtualPetCare.Application.UserOperations.Commands.CreateUser;
using virtualPetCare.Application.UserOperations.Queries.GetUserById;

namespace virtualPetCare.Controllers
{  //The requests related to users are directed to this class.
    [ApiController]
    [Route("api/v1/users")]
    public class UserController : ControllerBase
    {
        private readonly CreateUserCommand _createUserCommand;
        private readonly GetUserByIdQuery _getUserByIdQuery;

        public UserController(CreateUserCommand createUserCommand, GetUserByIdQuery getUserByIdQuery)
        {
            _createUserCommand = createUserCommand;
            _getUserByIdQuery = getUserByIdQuery;
        }
        //Returns information for a specific user.
        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute]int id)
        {
            _getUserByIdQuery.UserId= id;
            var user = _getUserByIdQuery.Handle();
            return Ok(user);
            
        }
        //Creates a new user.
        [HttpPost]
        public IActionResult Create([FromBody]CreateUserModel userModel )
        {
            _createUserCommand.Model = userModel;
            var user =_createUserCommand.Handle();

            return CreatedAtAction(nameof(GetById), new {id=user.Id},user);
        }

    }
}
