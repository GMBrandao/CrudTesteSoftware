using CrudTesteSoftware.Domain.DTO;
using CrudTesteSoftware.Domain.Interfaces.Repositories;
using CrudTesteSoftware.Domain.Interfaces.Services;
using CrudTesteSoftware.Domain.Models;

namespace CrudTesteSoftware.Domain.Services.Person
{
    public class PersonService : IPersonService
    {
        private IPersonRepository _personRepository;
        private IAddressService _addressService;

        public PersonService(
            IPersonRepository personRepository,
            IAddressService addressService)
        {
            _personRepository = personRepository;
            _addressService = addressService;
        }

        public async Task PostPerson(PersonDTORequest request, int addressReturn)
        {
            try
            {
                CreatePersonRequestDTO person = new(request.Cpf, request.Name, request.Gender, request.Phone, addressReturn);

                await _personRepository.CreatePersonAsync(person);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Models.Person>?> GetPeople()
        {
            try
            {
                var people = _personRepository.GetPeople();

                if (people == null)
                    return null;

                List<Models.Person> peopleResponse = new();

                foreach (PersonResponseDTO person in people)
                {
                    var a = await _addressService.GetAddress(person.IdAddress);
                    peopleResponse.Add(new Models.Person(person.Id, person.Cpf, person.Name, person.Gender, person.Phone, a));
                }

                return peopleResponse;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Models.Person?> GetPerson(int idRequest)
        {
            try
            {
                var person = await _personRepository.GetByIdPersonAsync(idRequest);
                if (person == null)
                    return null;

                var a = await _addressService.GetAddress(person.IdAddress);
                Models.Person personResponse = new(person.Id, person.Cpf, person.Name, person.Gender, person.Phone, a);

                return personResponse;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task PutPerson(PersonDTORequest request, int id, int addressReturn)
        {
            try
            {
                CreatePersonRequestDTO person = new(request.Cpf, request.Name, request.Gender, request.Phone, addressReturn);

                await _personRepository.PutPersonAsync(person, id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeletePerson(int idRequest)
        {
            try
            {
                await _personRepository.DeletePersonAsync(idRequest);
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
