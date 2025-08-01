using TerraTrust.Core.Entities;
using TerraTrust.Core.Interfaces.Repositories;
using TerraTrust.Data.Context;

namespace TerraTrust.Data.Repository
{
    public class PropertyRepository : IBaseRepository<Property>
    {
        private readonly ApplicationDbContext _context;

        public PropertyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Property property)
        {
            await _context.Properties.AddAsync(property);
            await _context.SaveChangesAsync();
            return property.Id;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Property>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Property?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Property property)
        {
            throw new NotImplementedException();
        }
    }
}
