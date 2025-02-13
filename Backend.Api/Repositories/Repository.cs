using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Api.Context;
using Backend.Api.Repositories.Interfaces;


using Microsoft.EntityFrameworkCore;

namespace Backend.Api.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationContext _context;
        protected readonly DbSet<T> _dbSet;
        public Repository(ApplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual T? FindById(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual List<T> FindAll()
        {
            return _dbSet.ToList();
        }

        public virtual void Update(T entity)
        {
            _dbSet.Update(entity);
            Save();
        }

        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
            Save();
        }

        public virtual void Remove(T entity)
        {
            _dbSet.Remove(entity);
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}