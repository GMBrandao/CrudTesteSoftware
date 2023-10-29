using CrudTesteSoftware.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudTesteSoftware.Domain.Interfaces.Repositories
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetPersonAsync();
        Task<Person> GetByIdPersonAsync(int idRequest);
        //Task<int> CreatePersonAsync(CreatePersonCommand data);
        //Task<int> PutPersonAsync(UpdatePersonCommand data);
        //Task<Unit> DeletePersonAsync(int idRequest);
    }
}
