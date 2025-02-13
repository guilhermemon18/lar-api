using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Api.Context;
using Backend.Api.Models;
using Backend.Api.Repositories.Interfaces;

namespace Backend.Api.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext context) : base(context)
        {
        }

        public User? FindByEmail(string email)
        {
            return _dbSet.Where(user => user.Email == email).FirstOrDefault();
        }

        public User? FindByName(string name)
        {
            return _dbSet.Where(user => user.Name == name).FirstOrDefault();
        }
    }
}