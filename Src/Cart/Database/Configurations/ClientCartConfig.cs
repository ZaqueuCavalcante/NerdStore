using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NerdStore.Cart.Domain;

namespace NerdStore.Cart.Database.Configurations
{
    public class ClientCartConfig : IEntityTypeConfiguration<ClientCart>
    {
        public void Configure(EntityTypeBuilder<ClientCart> clientCart)
        {
            clientCart.ToTable("client_carts");

            clientCart.HasKey(cc => cc.Id);

            clientCart.Property(cc => cc.ClientId).IsRequired();

            clientCart.HasMany(cc => cc.Items)
                .WithOne()
                .HasPrincipalKey(cc => cc.Id)
                .HasForeignKey(ci => ci.CartId);
        }
    }
}
