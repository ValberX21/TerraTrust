using TerraTrust.Core.Entities;
using TerraTrust.Core.Interfaces.Repositories;
using TerraTrust.Data.Context;

namespace TerraTrust.Data.Repository
{
    public class OwnerRepository : IBaseRepository<Owner>
    {
        private readonly ApplicationDbContext _context;

        public OwnerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Owner owner)
        {
            await _context.Owners.AddAsync(owner);
            await _context.SaveChangesAsync();
            return owner.Id;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Owner>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Owner?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Owner property)
        {
            throw new NotImplementedException();
        }
    }
}
