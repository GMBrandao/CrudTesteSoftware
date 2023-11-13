namespace CrudTesteSoftware.Domain.Models
{
    public class Person
    {
        public Person(int i, string c, string n, char g, string p, Address a)
        {
            this.Id = i;
            this.Cpf = c;
            this.Name = n;
            this.Gender = g;
            this.Phone = p;
            this.Address = a;
        }

        public Person() {}

        public int Id { get; set; }

        public string Cpf { get; set; }

        public string Name { get; set; }

        public char Gender { get; set; }

        public string Phone { get; set; }

        public Address Address { get; set; }
    }
}
