using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NerdStore.Cart.Domain;

namespace NerdStore.Cart.Database.Configurations
{
    public class CartItemConfig : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> cartItem)
        {
            cartItem.ToTable("cart_items");

            cartItem.HasKey(ci => ci.Id);

            cartItem.Property(ci => ci.CartId).IsRequired();
            cartItem.Property(ci => ci.ProductId).IsRequired();
        }
    }
}
