using System.Net;
using Microsoft.AspNetCore.Mvc;
using pessoas_api.Dtos.Request;
using pessoas_api.Dtos.Response;
using pessoas_api.Exceptions;
using pessoas_api.Services;

namespace pessoas_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(typeof(ErrorResponse), 422)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult<PersonResponseDto>> CreatePerson(PersonCreationDto personCreationDto)
        {
            PersonResponseDto createdPerson = await _personService.CreateAsync(personCreationDto);

            return StatusCode((int) HttpStatusCode.Created, createdPerson);
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        [Produces("application/json")]
        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<PersonResponseDto>> GetPerson(long id)
        {
            var personResponseDto = await _personService.GetAsync(id);
            return Ok(personResponseDto);
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult<List<PersonResponseDto>>> GetAllPeople()
        {
            var personResponseDto = await _personService.GetAllAsync();
            return Ok(personResponseDto);
        }

        [ProducesResponseType(400)]
        [ProducesResponseType(typeof(ErrorResponse), 422)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        [Produces("application/json")]
        [HttpPut]
        public async Task<ActionResult<PersonResponseDto>> UpdatePerson(PersonUpdateDto personUpdateDto)
        {
            var personResponseDto = await _personService.UpdateAsync(personUpdateDto);
            return Ok(personResponseDto);
        }

        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(typeof(ErrorResponse), 404)]
        [Produces("application/json")]
        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeletePerson(long id)
        {
            await _personService.DeleteAsync(id);
            return NoContent();
        }
        
    }
}
