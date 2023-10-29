namespace CrudTesteSoftware.Domain.DTO
{
    public class PersonDTORequest
    {
        public string Cpf { get; set; }

        public string Name { get; set; }

        public char Gender { get; set; }

        public string Phone { get; set; }

        public AddressDTORequest Address { get; set; }
    }
}
