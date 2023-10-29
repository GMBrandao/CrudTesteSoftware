namespace CrudTesteSoftware.Domain.Models
{
    public class Person
    {
        public int Id { get; set; }

        public string Cpf { get; set; }

        public string Name { get; set; }

        public char Gender { get; set; }

        public string Phone { get; set; }

        public Address Address { get; set; }
    }
}
