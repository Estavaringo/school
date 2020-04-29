using Microsoft.EntityFrameworkCore;
using School.Models.Database;
using School.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.Services.Repository
{
    public abstract class DataRepositoryBase<T> : IDataRepository<T> where T : class
    {
        protected SchoolContext _schoolContext { get; set; }

        public DataRepositoryBase(SchoolContext schoolContext)
        {
            _schoolContext = schoolContext;
        }
        public async Task<bool> CreateAsync(T entity)
        {
            try
            {
                _schoolContext.Set<T>().Add(entity);
                await _schoolContext.SaveChangesAsync();
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

        public async Task<bool> EditAsync(T entity)
        {
            try
            {
                _schoolContext.Set<T>().Update(entity);
                await _schoolContext.SaveChangesAsync();
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

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await _schoolContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(params object[] ids)
        {
            return await _schoolContext.Set<T>().FindAsync(ids);
        }

        public async Task<T> RemoveAsync(params object[] ids)
        {
            T entity = await GetAsync(ids);

            if (entity != null)
            {
                _schoolContext.Set<T>().Remove(entity);
                await _schoolContext.SaveChangesAsync();
            }
            return entity;
        }

        public abstract bool EntityExists(T entity);

    }
}
