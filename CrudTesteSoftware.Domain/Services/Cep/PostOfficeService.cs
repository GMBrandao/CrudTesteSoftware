using CrudTesteSoftware.Domain.DTO;
using CrudTesteSoftware.Domain.Interfaces.Services;
using Newtonsoft.Json;

namespace CrudTesteSoftware.Domain.Services.Cep
{
    public class PostOfficeService
    {
        static readonly HttpClient address = new HttpClient();
        public static async Task<AddressDTO?> GetAddressAsync(string zipCode)
        {
            try
            {
                HttpResponseMessage response = await address.GetAsync("https://viacep.com.br/ws/" + zipCode + "/json/");
                response.EnsureSuccessStatusCode();
                string ender = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AddressDTO>(ender);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
