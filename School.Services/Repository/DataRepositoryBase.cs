using Microsoft.EntityFrameworkCore;
using School.Models.Database;
using School.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.Services.Repository
{
    public abstract class DataRepositoryBase<T> : IDataRepository<T> where T : class
    {
        protected SchoolContext schoolContext { get; set; }

        public DataRepositoryBase(SchoolContext schoolContext)
        {
            this.schoolContext = schoolContext;
        }
        public virtual async Task<bool> CreateAsync(T entity)
        {
            try
            {
                schoolContext.Set<T>().Add(entity);
                await schoolContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EntityExists(entity))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            return true;
        }

        public virtual async Task<bool> EditAsync(T entity)
        {
            try
            {
                schoolContext.Set<T>().Update(entity);
                await schoolContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntityExists(entity))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        public virtual async Task<IEnumerable<T>> GetAsync()
        {
            return await schoolContext.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetAsync(params object[] ids)
        {
            return await schoolContext.Set<T>().FindAsync(ids);
        }

        public virtual async Task<T> RemoveAsync(params object[] ids)
        {
            T entity = await GetAsync(ids);

            if (entity != null)
            {
                schoolContext.Set<T>().Remove(entity);
                await schoolContext.SaveChangesAsync();
            }
            return entity;
        }

        public abstract bool EntityExists(T entity);

    }
}
