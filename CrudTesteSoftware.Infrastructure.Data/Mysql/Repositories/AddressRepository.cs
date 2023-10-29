using CrudTesteSoftware.Domain.Interfaces.Repositories;
using CrudTesteSoftware.Domain.Models;
using CrudTesteSoftware.Infrastructure.Data.Mysql.Connection;
using Dapper;
using MySql.Data.MySqlClient;

namespace CrudTesteSoftware.Infrastructure.Data.Mysql.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        public MySqlConnection _conn;
        public AddressRepository()
        {
            _conn = new MySqlConnection(ConnectionClass.ConnString);
        }

        public async Task<Address> GetByIdAddressAsync(int idRequest)
        {
            var sql = @$"SELECT 
                            Id,
                            Number,
                            Complement,
                            ZipCode,
                            Street,
                            Neighborhood,
                            City,
                            State
                        FROM Address
                        WHERE Id = @Id";

            _conn.Open();
            var query = await _conn.QueryFirstOrDefaultAsync<Address>(
                sql,
                new
                {
                    Id = idRequest
                });
            _conn.Close();

            return query;
        }

        public async Task<int> CreateAddressAsync(Address data)
        {
            var sql = @$"INSERT INTO Address
                            (
                            Number,
                            Complement,
                            ZipCode,
                            Street,
                            Neighborhood,
                            City,
                            State
                            )
                         VALUES
                            (
                            @Number,
                            @Complement,
                            @ZipCode,
                            @Street,
                            @Neighborhood,
                            @City,
                            @State
                            );
                        ";

            await _conn.ExecuteAsync(sql,
            new
            {
                data.Number,
                data.Complement,
                data.ZipCode,
                data.Street,
                data.Neighborhood,
                data.City,
                data.State,
            });

            return await _conn.QueryFirstOrDefaultAsync<int>($@"SELECT Id FROM Address ORDER BY Id DESC");
        }
    }
}