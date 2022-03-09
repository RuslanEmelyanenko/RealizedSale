using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewProject_RealizedSale.Repositories.Abstractions
{
    public interface IBaseRepository<T> where T : class
    {
        T Get(int id);
        IList<T> GetAll();
        Task<IList<T>> GetAllAsync();
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}