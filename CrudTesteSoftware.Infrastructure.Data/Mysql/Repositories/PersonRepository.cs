using CrudTesteSoftware.Domain.DTO;
using CrudTesteSoftware.Domain.Interfaces.Repositories;
using CrudTesteSoftware.Infrastructure.Data.Mysql.Connection;
using Dapper;
using MySql.Data.MySqlClient;
using static System.Net.Mime.MediaTypeNames;

namespace CrudTesteSoftware.Infrastructure.Data.Mysql.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        public MySqlConnection _conn;
        public PersonRepository()
        {
            _conn = new MySqlConnection(ConnectionClass.ConnString);
        }

        public PersonRepository(string teste)
        {
            _conn = new MySqlConnection("Server = localhost; Database = Teste; Uid = root; Pwd = root;");
        }

        public IEnumerable<PersonResponseDTO> GetPeople()
        {
            var sql = @$"SELECT 
                            p.Id, 
                            p.Cpf, 
                            p.Name, 
                            p.Gender, 
                            p.Phone, 
                            p.idAddress
                         FROM Person p;";

            _conn.Open();
            var query = _conn.Query<PersonResponseDTO>(sql);
            _conn.Close();

            return query;
        }

        public async Task<PersonResponseDTO> GetByIdPersonAsync(int idRequest)
        {
            var sql = @$"SELECT 
                            p.Id, 
                            p.Cpf, 
                            p.Name, 
                            p.Gender, 
                            p.Phone, 
                            p.idAddress
                         FROM Person p
                         WHERE p.Id = @idRequest;";

            _conn.Open();
            var query = await _conn.QueryFirstOrDefaultAsync<PersonResponseDTO>(
                sql,
                new
                {
                    idRequest
                });
            _conn.Close();

            return query;
        }

        public async Task CreatePersonAsync(CreatePersonRequestDTO data)
        {
            var sql = @$"INSERT INTO Person
                            (
                            Cpf, 
                            Name, 
                            Gender, 
                            Phone, 
                            idAddress
                            )
                         VALUES
                            (
                            @Cpf,
                            @Name,
                            @Gender,
                            @Phone,
                            @idAddress
                            );
                        ";

            await _conn.ExecuteAsync(sql,
            new
            {
                data.Cpf,
                data.Name,
                data.Gender,
                data.Phone,
                idAddress = data.IdAddress
            });
        }

        public async Task DeletePersonAsync(int idRequest)
        {
            var sql = @$"DELETE FROM Person 
                         WHERE Id = @idRequest;";

            _conn.Open();
            await _conn.ExecuteAsync(
                sql,
                new
                {
                    idRequest
                });
            _conn.Close();
        }

        public async Task PutPersonAsync(CreatePersonRequestDTO data, int idRequest)
        {
            var sql = @$"UPDATE Person
                         SET 
                            Cpf = @Cpf, 
                            Name = @Name, 
                            Gender = @Gender,
                            Phone = @Phone,
                            idAddress = @idAddress
                         WHERE Id = @idRequest; 
                        ";

            await _conn.ExecuteAsync(sql,
            new
            {
                data.Cpf,
                data.Name,
                data.Gender,
                data.Phone,
                idAddress = data.IdAddress, 
                idRequest
            });
        }
    }
}
