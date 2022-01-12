using System.Collections.Generic;

namespace NewProject_RealizedSale.Repositories.Abstractions
{
    public interface IBaseRepository<T> 
        where T : class
    {
        T Get(int id);

        IList<T> GetAll();

        void Create(T entity);

        void CreateList(IList<T> entities);

        void Delete(T entity);

        void Complete();

        void Update(T entity);
    }
}
