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

        public PersonController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public async Task<IEnumerable<Person>> GetPerson()
        {
            return null;
        }

        [HttpGet("idAddress", Name = "GetAddresById")]
        public async Task<Address> GetAddress(int id)
        {
            return await _addressService.GetAddress(id); ;
        }

        [HttpPost]
        public async Task<int> PostPerson([FromBody] PersonDTORequest request)
        {
            var i  = await _addressService.PostAddress(request.Address);
            return i;
        }
    }
}
