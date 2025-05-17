using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LotsOfFun.Dto;
using LotsOfFun.Model;
using LotsOfFun.Repository;
using Microsoft.EntityFrameworkCore;

namespace LotsOfFun.Services
{
    public class PersonService
    {

        private readonly LotsOfFunDbContext _dbContext;
        private readonly IMapper _mapper;

        public PersonService(LotsOfFunDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
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

        public async Task<PersonDetailDto?> GetDetails(int id)
        {
            var person = await _dbContext.People
                .Include(p => p.Address)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (person == null)
                return null;

            return _mapper.Map<PersonDetailDto>(person);
        }

        public async Task<Person?> Create(Person person)
        {
             await _dbContext.People.AddAsync(person);
             await _dbContext.SaveChangesAsync();
             return person;
        }

        public async Task<Person?> Update(int id, UpdatePersonDto personDto)
        {
            var person = await Get(id);
            if (person == null) return null;

            _mapper.Map(personDto, person); // maps basic fields

            // Address requires separate mapping because it's nested
            _mapper.Map(personDto, person.Address);

            await _dbContext.SaveChangesAsync();
            return person;

        }

        public async Task Delete(int id)
        {
            var person = await Get(id);
             _dbContext.People.Remove(person);
             await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<string> GetNewsletterSubscriberEmails()
        {
            return _dbContext.People
                .Where(p => p.NewsLetter)
                .Select(p => p.Email)
                .Where(email => !string.IsNullOrEmpty(email))
                .ToList();
        }
    }
}
