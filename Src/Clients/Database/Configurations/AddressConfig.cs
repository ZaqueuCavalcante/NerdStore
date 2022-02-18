using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NerdStore.Clients.Domain;

namespace NerdStore.Clients.Database.Configurations
{
    public class AddressConfig : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> address)
        {
            address.ToTable("addresses");

            address.HasKey(a => a.Id);

            address.Property(a => a.ClientId).IsRequired();

            address.Property(a => a.CEP).IsRequired();
            address.Property(a => a.Street).IsRequired();
        }
    }
}
