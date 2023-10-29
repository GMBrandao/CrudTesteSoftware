using CrudTesteSoftware.Domain.DTO;
using CrudTesteSoftware.Domain.Interfaces.Services;
using CrudTesteSoftware.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudTesteSoftware.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private IAddressService _addressService;
        private IPersonService _personService;

        public PersonController(IAddressService addressService, IPersonService personService)
        {
            _addressService = addressService;
            _personService = personService;
        }

        [HttpGet]
        public Task<IEnumerable<Person>?> GetPeople()
        {
            return _personService.GetPeople();
        }

        [HttpGet("id", Name = "GetPersonById")]
        public async Task<Person?> GetPerson(int id)
        {
            return await _personService.GetPerson(id);
        }

        [HttpGet("idAddress", Name = "GetAddresById")]
        public async Task<Address> GetAddress(int id)
        {
            return await _addressService.GetAddress(id);
        }

        [HttpPost]
        public async Task PostPerson([FromBody] PersonDTORequest request)
        {
            int addressReturn  = await _addressService.PostAddress(request.Address);

            await _personService.PostPerson(request, addressReturn);
        }

        [HttpPut("id")]
        public async Task PutPerson([FromBody] PersonDTORequest request, int id)
        {
            int addressReturn = await _addressService.PostAddress(request.Address);

            await _personService.PutPerson(request, id, addressReturn);
        }

        [HttpDelete("id", Name = "DeletePerson")]
        public async Task DeletePerson(int id)
        {
            await _personService.DeletePerson(id);
        }
    }
}
