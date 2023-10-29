using CrudTesteSoftware.Domain.DTO;
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
        public IEnumerable<PersonResponseDTO> GetPeople();
        Task<PersonResponseDTO> GetByIdPersonAsync(int idRequest);
        Task CreatePersonAsync(CreatePersonRequestDTO data);
        Task PutPersonAsync(CreatePersonRequestDTO data, int idRequest);
        Task DeletePersonAsync(int idRequest);
    }
}
