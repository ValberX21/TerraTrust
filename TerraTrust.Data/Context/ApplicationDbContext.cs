using Microsoft.EntityFrameworkCore;
using TerraTrust.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TerraTrust.Core.Events;
using TerraTrust.Core.Interfaces;

namespace TerraTrust.Data.Context
{
    public class ApplicationDbContext : DbContext, IUnitOfWork
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {
        }

        public Task<int> SaveChangesAsync(CancellationToken ct = default)
                                            => base.SaveChangesAsync(ct);
        public DbSet<Property> Properties { get; set; }
        public DbSet<Owner> Owners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Ignore<DomainEvent>();
            modelBuilder.Entity<DomainEvent>().HasNoKey();

            modelBuilder.Entity<Property>(entity =>
            {
                entity.Property(p => p.Name).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Owner>(entity =>
            {
                entity.Property(o => o.FullName).IsRequired().HasMaxLength(150);
                entity.Property(o => o.DocumentNumber).IsRequired().HasMaxLength(20);
                entity.Property(o => o.Email).IsRequired().HasMaxLength(100);
            });
        }
    }
}
