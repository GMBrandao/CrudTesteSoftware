namespace CrudTesteSoftware.Domain.DTO
{
    public class CreatePersonRequestDTO
    {
        public CreatePersonRequestDTO(string c, string n, char g, string p, int i)
        {
            this.Cpf = c;
            this.Name = n;
            this.Gender = g;
            this.Phone = p;
            this.IdAddress = i;
        }

        public string Cpf { get; set; }

        public string Name { get; set; }

        public char Gender { get; set; }

        public string Phone { get; set; }

        public int IdAddress { get; set; }
    }
}
