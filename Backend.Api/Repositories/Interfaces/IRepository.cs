using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Api.Repositories.Interfaces
{
    public interface IRepository
    {
        T FindById(int id);
        List<T> FindAll();
        void Update(T entity)
        void Add(T entity);
        void Remove(T entity);
    }
}