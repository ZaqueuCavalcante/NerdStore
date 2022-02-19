using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NerdStore.Catalog.Domain;

namespace NerdStore.Catalog.Database.Configurations
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> product)
        {
            product.ToTable("products");

            product.HasKey(p => p.Id);
        }
    }
}
