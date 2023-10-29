using Newtonsoft.Json;

namespace CrudTesteSoftware.Domain.DTO
{
    public class AddressDTO
    {
        [JsonProperty("cep")]
        public string ZipCode { get; set; }

        [JsonProperty("bairro")]
        public string Neighborhood { get; set; }

        [JsonProperty("localidade")]
        public string City { get; set; }

        [JsonProperty("uf")]
        public string State { get; set; }

        [JsonProperty("logradouro")]
        public string Street { get; set; }

        [JsonProperty("complemento")]
        public string Complement { get; set; }
    }
}
