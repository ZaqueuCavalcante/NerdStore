using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NerdStore.Identity.Domain;

namespace NerdStore.Identity.Database
{
    public class IdentityContext : IdentityDbContext<User, Role, string>
    {
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options) {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasDefaultSchema("identity");

            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
