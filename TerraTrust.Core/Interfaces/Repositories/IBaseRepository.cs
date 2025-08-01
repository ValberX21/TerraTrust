using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraTrust.Core.Entities;

namespace TerraTrust.Core.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class 
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<int> AddAsync(T property);
        Task UpdateAsync(T property);
        Task DeleteAsync(int id);
    }
}
