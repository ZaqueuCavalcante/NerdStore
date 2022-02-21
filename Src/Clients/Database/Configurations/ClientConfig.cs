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

            client.Property(c => c.Cpf).IsRequired();
            client.Property(c => c.Name).IsRequired();
            client.Property(c => c.Email).IsRequired();

            client.Property(c => c.IsExcluded)
                .IsRequired()
                .HasDefaultValue(false);

            client.HasOne(c => c.Address)
                .WithOne()
                .HasForeignKey<Client>(c => c.AddressId)
                .IsRequired(false);
        }
    }
}
