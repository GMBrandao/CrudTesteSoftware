using CrudTesteSoftware.Domain.DTO;

namespace CrudTesteSoftware.Domain.Models
{
    public class Address
    {
        public Address()
        {
        }

        public Address(AddressDTO addressDTO, AddressDTORequest addressDTORequest)
        {
            this.Number = addressDTORequest.Number;
            this.Complement = addressDTORequest.Complement;
            this.ZipCode = addressDTO.ZipCode;
            this.Street = addressDTO.Street;
            this.Neighborhood = addressDTO.Neighborhood;
            this.City = addressDTO.City;
            this.State = addressDTO.State;
        }

        public int Id { get; set; }

        public int Number { get; set; }

        public string? Complement { get; set; }

        public string? ZipCode { get; set; }

        public string Street { get; set; }

        public string Neighborhood { get; set; }

        public string City { get; set; }

        public string State { get; set; }

    }
}
