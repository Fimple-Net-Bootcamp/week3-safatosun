using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using virtualPetCare.Application.HealthStatus.Commands.PatchHealthStatus;
using virtualPetCare.Application.HealthStatusOperations.Queries.GetHealthStatusByIdQuery;

namespace virtualPetCare.Controllers
{   //The requests related to health statuses are directed to this class.

    [ApiController]
    [Route("api/v1/healthStatuses")]
    public class HealthStatusController : ControllerBase
    {
        private readonly GetHealthStatusByIdQuery _healthStatusByIdQuery;
        private readonly PatchHealthStatusCommand _patchHealthStatusCommand;

        public HealthStatusController(GetHealthStatusByIdQuery healthStatusByIdQuery, PatchHealthStatusCommand patchHealthStatusCommand)
        {
            _healthStatusByIdQuery = healthStatusByIdQuery;
            _patchHealthStatusCommand = patchHealthStatusCommand;
        }
        //Returns the health status of a specific pet.
        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute]int id)
        {
            _healthStatusByIdQuery.PetId = id;
            var healthStatus = _healthStatusByIdQuery.Handle();
            return Ok(healthStatus);
        }
        //Updates the pet's health status.
        [HttpPatch("{id:int}")]
        public IActionResult Patch([FromRoute] int id, [FromBody] JsonPatchDocument<PatchHealthStatusModel> jsonPatch)
        {
            _patchHealthStatusCommand.PetId = id;
            _patchHealthStatusCommand.Model = jsonPatch;
            _patchHealthStatusCommand.Handle();
            return Ok();
        }

    }
}
 