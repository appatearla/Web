using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data
{
    public interface IRepository<T>
    {
        Task<IList<T>> Get();

        Task<T> Get(string id);

        Task<T> Create(T entity);

        Task<T> Update(T entity, string id);

        Task Delete(string id);
    }
}
