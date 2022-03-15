using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewProject_RealizedSale.Repositories.Abstractions
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetAsync(int id);
        IList<T> GetAll();
        Task<IList<T>> GetAllAsync();
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}