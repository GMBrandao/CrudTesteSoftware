using CrudTesteSoftware.Domain.Models;

namespace CrudTesteSoftware.Domain.Interfaces.Repositories
{
    public interface IAddressRepository
    {
        public Task<Address> GetByIdAddressAsync(int idRequest);

        public Task<int> CreateAddressAsync(Address data);
    }
}
