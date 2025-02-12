using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Api.Context;
using Backend.Api.Models;
using Backend.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Api.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(ApplicationContext context) : base(context)
        {
        }


        public override Person? FindById(int id)
        {
            // return _dbSet.Find(id);
            return _dbSet.Include(p => p.Phones).Where(p => p.Id == id).FirstOrDefault();
        }

        public override List<Person> FindAll()
        {
            return _dbSet.Include(p => p.Phones).ToList();
        }
    }
}