using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace School.Services.Interfaces
{
    public interface IDataRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAsync();

        Task<TEntity> GetAsync(params object[] id);

        Task<bool> EditAsync(TEntity entity);

        Task<bool> CreateAsync(TEntity entity);

        Task<TEntity> RemoveAsync(params object[] id);

    }
}
