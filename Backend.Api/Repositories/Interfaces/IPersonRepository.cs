using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Api.Models;

namespace Backend.Api.Repositories.Interfaces
{
    public interface IPersonRepository : IRepository<Person>
    {
        //dá para colocar mais métodos para implementar se necessário e forçar a ter outros comportamentos.
    }
}