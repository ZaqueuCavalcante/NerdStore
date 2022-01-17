using Microsoft.EntityFrameworkCore;
using NerdStore.Catalog.Domain;

namespace NerdStore.Catalog.Database
{
    public class CatalogContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options) {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasDefaultSchema("catalog");

            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
