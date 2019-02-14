using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLib.Abstractions
{
    public interface IRepository<TEntity>
    {
        //Queries
        Task<IEnumerable<TEntity>> GetAsync();
        Task<TEntity> GetAsync(int id);

        //Commands
        Task<int> AddAsync(TEntity entity);
        Task<int> UpdateAsync(TEntity entity);
        Task<int> RemoveAsync(TEntity entity);
    }
}
