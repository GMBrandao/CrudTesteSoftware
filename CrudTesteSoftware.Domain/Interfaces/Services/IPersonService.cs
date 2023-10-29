using CrudTesteSoftware.Domain.DTO;
using CrudTesteSoftware.Domain.Models;

namespace CrudTesteSoftware.Domain.Interfaces.Services
{
    public interface IPersonService
    {
        public Task PostPerson(PersonDTORequest request, int addressReturn);
        public Task<IEnumerable<Person>?> GetPeople();
        public Task<Person?> GetPerson(int idRequest);
        public Task PutPerson(PersonDTORequest request, int id, int addressReturn);
        public Task DeletePerson(int idRequest);
    }
}
