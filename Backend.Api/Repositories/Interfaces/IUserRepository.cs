using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Api.Models;

namespace Backend.Api.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        public User? FindByEmail(string email);
        public User? FindByName(string name);

    }
}