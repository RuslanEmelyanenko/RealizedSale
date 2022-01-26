using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using NewProject_RealizedSale.Models;
using NewProject_RealizedSale.Repositories.Abstractions;

namespace NewProject_RealizedSale.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    { 
        protected DbSet<T> Entities { get; set; }
        protected SaleContext DbContext { get; set; }

        protected BaseRepository(SaleContext dbContext)
        {
            DbContext = dbContext;
            Entities = dbContext.Set<T>();
        }

        public T Get(int id)
        {
            return Entities.Find(id);
        }

        public IList<T> GetAll()
        {
            return Entities.ToList();
        }

        public void Create(T entity)
        {
            Entities.Add(entity);
        }

        public void Update(T entity)
        {
            DbContext.Update(entity); 
        }

        public void Delete(T entity)
        {
            Entities.Remove(entity);
        }

        public void Save()
        {
            DbContext.SaveChanges();
        }
    }
}