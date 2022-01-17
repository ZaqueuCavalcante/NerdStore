using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NerdStore.Clients.Domain;

namespace NerdStore.Clients.Database.Configurations
{
    public class ProductConfig : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> client)
        {
            client.ToTable("clients");

            client.HasKey(c => c.Id);

            client.HasOne<Address>(c => c.Address)
                .WithOne()
                .IsRequired(false);
        }
    }
}
