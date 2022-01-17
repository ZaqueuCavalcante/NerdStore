using Microsoft.EntityFrameworkCore;
using NerdStore.Clients.Domain;

namespace NerdStore.Clients.Database
{
    public class ClientsContext : DbContext
    {
        // public DbSet<Product> Products { get; set; }

        public ClientsContext(DbContextOptions<ClientsContext> options) : base(options) {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasDefaultSchema("clients");

            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
