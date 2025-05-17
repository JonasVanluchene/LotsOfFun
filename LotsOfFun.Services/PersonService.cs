using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LotsOfFun.Model;
using LotsOfFun.Repository;
using Microsoft.EntityFrameworkCore;

namespace LotsOfFun.Services
{
    public class PersonService
    {

        private readonly LotsOfFunDbContext _dbContext;

        public PersonService(LotsOfFunDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<IList<Person>> GetAll()
        {
            return await _dbContext.People.ToListAsync();  
        }

        public async Task<Person?> Get(int id)
        {
            var person = await _dbContext.People.FirstOrDefaultAsync(p => p.Id == id);
            if (person == null)
            {
                throw new KeyNotFoundException($"Person with ID {id} not found.");
            }
            return person;
        }


        public async Task<Person?> Create(Person person)
        {
             await _dbContext.People.AddAsync(person);
             await _dbContext.SaveChangesAsync();
             return person;
        }

        public async Task<Person?> Update(int id, Person person)
        {
            var dbPerson = await Get(id);
            if (dbPerson is null)
            {
                return null;
            }
            dbPerson.FirstName = person.FirstName;
            dbPerson.LastName = person.LastName;
            dbPerson.Email =  person.Email;
            dbPerson.Phone = person.Phone;

            dbPerson.Address.Street = person.Address.Street;
            dbPerson.Address.Number = person.Address.Number;
            dbPerson.Address.UnitNumber = person.Address.UnitNumber;
            dbPerson.Address.PostalCode = person.Address.PostalCode;
            dbPerson.Address.City = person.Address.City;
            dbPerson.Address.Street = person.Address.Street;
            dbPerson.Address.Number = person.Address.Number;
            dbPerson.Address.UnitNumber = person.Address.UnitNumber;
            dbPerson.Address.PostalCode = person.Address.PostalCode;
            dbPerson.Address.City = person.Address.City;
            dbPerson.NewsLetter = person.NewsLetter;

            await _dbContext.SaveChangesAsync();
            return dbPerson;

        }
    }
}
