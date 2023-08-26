using Microsoft.AspNetCore.Mvc;
using pessoas_api.Dtos.Request;
using pessoas_api.Dtos.Response;
using pessoas_api.Exceptions;
using pessoas_api.Services;
using System.Net;

namespace pessoas_api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(typeof(ErrorResponse), 422)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult<AddressResponseDto>> CreateAddress(AddressCreationDto addressCreationDto)
        {
            AddressResponseDto createdAddress = await _addressService.CreateAsync(addressCreationDto);

            return StatusCode((int)HttpStatusCode.Created, createdAddress);
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        [Produces("application/json")]
        [Route("{id}")]
        [HttpGet]
        public async Task<ActionResult<AddressResponseDto>> GetPerson(long id)
        {
            var addressResponseDto = await _addressService.GetAsync(id);
            return Ok(addressResponseDto);
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult<List<AddressResponseDto>>> GetAllAddresses()
        {
            var personResponseDto = await _addressService.GetAllAsync();
            return Ok(personResponseDto);
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(typeof(ErrorResponse), 422)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
        [Produces("application/json")]
        [HttpPut]
        public async Task<ActionResult<AddressResponseDto>> UpdateAddress(AddressUpdateDto addressUpdateDto)
        {
            var personResponseDto = await _addressService.UpdateAsync(addressUpdateDto);
            return Ok(personResponseDto);
        }

        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(typeof(ErrorResponse), 404)]
        [Produces("application/json")]
        [Route("{id}")]
        [HttpDelete]
        public async Task<ActionResult> DeleteAddress(long id)
        {
            await _addressService.DeleteAsync(id);
            return NoContent();
        }

    }
}
