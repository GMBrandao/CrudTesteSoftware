using CrudTesteSoftware.Domain.DTO;
using CrudTesteSoftware.Domain.Interfaces.Repositories;
using CrudTesteSoftware.Domain.Interfaces.Services;
using CrudTesteSoftware.Domain.Services.Cep;

namespace CrudTesteSoftware.Domain.Services.Address
{
    public class AddressService : IAddressService
    {
        private IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<Models.Address?> GetAddress(int idRequest)
        {
            try
            {
                var address = await _addressRepository.GetByIdAddressAsync(idRequest);

                return address == null ? null : address;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<int> PostAddress(AddressDTORequest addressDTORequest)
        {
            try
            {
                AddressDTO? addressDTO = new();
                addressDTO = await PostOfficeService.GetAddressAsync(addressDTORequest.ZipCode);
                Models.Address address = new(addressDTO, addressDTORequest);

                return await _addressRepository.CreateAddressAsync(address);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
