using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Api.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        public T? FindById(int id);
        public List<T> FindAll();
        public void Update(T entity);
        public void Add(T entity);
        public void Remove(T entity);
        protected void Save();
    }
}