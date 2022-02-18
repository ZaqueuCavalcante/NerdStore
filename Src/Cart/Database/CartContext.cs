using Microsoft.EntityFrameworkCore;
using NerdStore.Cart.Domain;

namespace NerdStore.Cart.Database
{
    public class CartContext : DbContext
    {
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<ClientCart> ClientCarts { get; set; }

        public CartContext(DbContextOptions<CartContext> options) : base(options) {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasDefaultSchema("cart");

            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
