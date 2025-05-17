using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LotsOfFun.Model;
using LotsOfFun.Repository;

namespace LotsOfFun.Services
{
    public class PersonService
    {

        private readonly LotsOfFunDbContext _dbContext;

        public PersonService(LotsOfFunDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public IList<Person> GetAll()
        {
            return _dbContext.People.ToList();  
        }
    }
}
