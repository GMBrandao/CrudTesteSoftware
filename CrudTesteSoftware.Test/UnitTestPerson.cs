using MySql.Data.MySqlClient;
using Dapper;
using CrudTesteSoftware.Domain.Models;
using CrudTesteSoftware.Domain.DTO;
using CrudTesteSoftware.Infrastructure.Data.Mysql.Repositories;
using CrudTesteSoftware.Domain.Interfaces.Repositories;
using CrudTesteSoftware.Domain.Interfaces.Services;
using CrudTesteSoftware.Domain.Services.Address;
using CrudTesteSoftware.Api.Controllers;

namespace CrudTesteSoftware.Test
{
    public class UnitTestPerson
    {
        private MySqlConnection? _conn;

        private void InitializeDatabase()
        {
            using (_conn = new MySqlConnection("Server=localhost;Database=Teste;Uid=root;Pwd=root;"))
            {
                _conn.Open();

                _conn.Execute(@$"CREATE TABLE Address(
                                Id int NOT NULL AUTO_INCREMENT,
                                Number int NOT NULL,
                                Complement varchar(100) NOT NULL,
                                ZipCode varchar(100) NOT NULL,
                                Street varchar(100) NOT NULL,
                                Neighborhood varchar(100) NOT NULL,
                                City varchar(100) NOT NULL,
                                State varchar(100) NOT NULL,

                                CONSTRAINT PK_Address PRIMARY KEY(Id)
                            );"
                             );

                _conn.Execute(@$"CREATE TABLE Person(
                                Id int NOT NULL AUTO_INCREMENT,
                                Cpf varchar(11) NOT NULL,
                                Name varchar(100) NOT NULL,
                                Gender char(1) NOT NULL,
                                Phone varchar(15) NOT NULL,
                                idAddress int NOT NULL,

                                CONSTRAINT PK_Person PRIMARY KEY(Id),
                                CONSTRAINT FK_Person_Address FOREIGN KEY (idAddress) REFERENCES Address(Id)
                            );"
                             );

                string insertAddress = @"INSERT INTO Address
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

                string insertPerson = @$"INSERT INTO Person
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

                _conn.Execute(insertAddress, new Address(630, "Na esquina", "14800165", "Rua dos Libanezes", "Jardim do Carmo", "Araraquara", "SP"));

                var listPerson = new List<CreatePersonRequestDTO>
                {
                    new CreatePersonRequestDTO { Cpf = "12345678901", Name = "Jose", Gender = 'M', Phone = "987654321", IdAddress = 1 },
                    new CreatePersonRequestDTO { Cpf = "12345678910", Name = "Fabiana", Gender = 'F', Phone = "987654321", IdAddress = 1 }
                };

                _conn.Execute(insertPerson, listPerson);
            }
        }

        private void EndDatabaseTables()
        {
            using (_conn = new MySqlConnection("Server=localhost;Database=Teste;Uid=root;Pwd=root;"))
            {
                _conn.Execute("DROP TABLE Person");
                _conn.Execute("DROP TABLE Address");
                _conn.Close();
            }
        }

        [Fact]
        public async void GetPeople()
        {
            InitializeDatabase();

            var people = new PersonRepository("teste").GetPeople();

            List<Person> peopleResponse = new();

            foreach (PersonResponseDTO person in people)
            {
                var a = await new AddressService(new AddressRepository()).GetAddress(person.IdAddress);
                peopleResponse.Add(new Person(person.Id, person.Cpf, person.Name, person.Gender, person.Phone, a));
            }

            EndDatabaseTables();

            Assert.Equal(2, peopleResponse.Count());
        }

        [Fact]
        public async void CreatePerson()
        {
            InitializeDatabase();

            var personRepository = new PersonRepository("teste");

            await personRepository.CreatePersonAsync(
                new CreatePersonRequestDTO 
                    {
                        Cpf = "9a765x321",
                        Name = "Gabriel",
                        Gender = 'M',
                        Phone = "987654321",
                        IdAddress = 1 
                    }
                );

            var person = await personRepository.GetByIdPersonAsync(3);

            EndDatabaseTables();

            bool validation = person.Cpf.Any(char.IsLetter);

            Assert.False(validation);
        }

        [Fact]
        public async void PutPerson()
        {
            InitializeDatabase();

            var personRepository = new PersonRepository("teste");

            await personRepository.PutPersonAsync(
                new CreatePersonRequestDTO
                {
                    Cpf = "987654321",
                    Name = "Gabriel",
                    Gender = 'M',
                    Phone = "987654321",
                    IdAddress = 1
                },
                2
                );

            var person = await personRepository.GetByIdPersonAsync(2);

            EndDatabaseTables();

            Assert.Equal("Gabriel", person.Name);
        }

        [Fact]
        public async void DeletePerson()
        {
            InitializeDatabase();

            var personRepository = new PersonRepository("teste");

            await personRepository.DeletePersonAsync(2);

            var people = personRepository.GetPeople();

            List<Person> peopleResponse = new();

            foreach (PersonResponseDTO person in people)
            {
                var a = await new AddressService(new AddressRepository()).GetAddress(person.IdAddress);
                peopleResponse.Add(new Person(person.Id, person.Cpf, person.Name, person.Gender, person.Phone, a));
            }

            EndDatabaseTables();

            Assert.Single(peopleResponse);
            Assert.Equal("Jose", peopleResponse.First().Name);
        }

        [Fact]
        public void GetAddress()
        {

        }
    }
}
