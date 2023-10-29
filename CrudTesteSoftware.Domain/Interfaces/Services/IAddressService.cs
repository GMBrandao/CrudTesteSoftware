using CrudTesteSoftware.Domain.DTO;
using CrudTesteSoftware.Domain.Models;

namespace CrudTesteSoftware.Domain.Interfaces.Services
{
    public interface IAddressService
    {
        public Task<Address>GetAddress(int idRequest);

        public Task<int> PostAddress(AddressDTORequest addressDTORequest);
    }
}
