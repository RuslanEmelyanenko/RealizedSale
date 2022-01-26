using System.Collections.Generic;

namespace NewProject_RealizedSale.Repositories.Abstractions
{
    public interface IBaseRepository<T> where T : class
    {
        T Get(int id);
        IList<T> GetAll();
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}