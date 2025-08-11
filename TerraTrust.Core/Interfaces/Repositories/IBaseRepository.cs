using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerraTrust.Core.Entities;

namespace TerraTrust.Core.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity 
    {
        Task<T?> GetByIdAsync(int id, CancellationToken ct = default);

        Task<IReadOnlyList<T>> GetPagedAsync(int page, int pageSize, CancellationToken ct = default);
        Task<int> CountAsync(CancellationToken ct = default); 
        
        
        Task<T> AddAsync(T entity, CancellationToken ct = default);
       
        Task<bool> UpdateAsync(T entity, CancellationToken ct = default);
        Task<bool> RemoveAsync(int id, CancellationToken ct = default);
    }
}
