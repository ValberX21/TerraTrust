using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraTrust.Core.Interfaces.Repositories;
using TerraTrust.Data.Context;

namespace TerraTrust.Data.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();

        }

        public async Task<T> AddAsync(T entity, CancellationToken ct = default)
        {
            await _dbSet.AddAsync(entity);     
            return entity;
        }

        public async Task<IEnumerable<T>> GetPagedAsync(int page, int pagesize, CancellationToken ct = default)
        {
            return await _dbSet
                 .AsNoTracking()
                 .Skip(page)
                 .Take(pagesize)
                 .ToListAsync(ct);
        }

        public async Task<T?> GetByIdAsync(int id, CancellationToken ct = default)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<bool> RemoveAsync(int id, CancellationToken ct = default)
        {
            var entity = await _dbSet.FindAsync(id);    
            if (entity != null)
            {
                _dbSet.Remove(entity);
                return true;    
            }
            else
            {
                return false; 
            }   

        }

        public async Task<bool> UpdateAsync(T entity, CancellationToken ct = default)
        {
            try
            {
                _dbSet.Update(entity);
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
            catch (Exception)
            {
                return false;

            }
        }
    }
}
