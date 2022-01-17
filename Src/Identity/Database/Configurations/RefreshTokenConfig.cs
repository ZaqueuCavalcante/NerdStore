using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NerdStore.Identity.Domain;

namespace NerdStore.Identity.Database.Configurations
{
    public class RefreshTokenConfig : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> refreshToken)
        {
            refreshToken.ToTable("refresh_tokens");

            refreshToken.HasKey(rt => rt.Id);
        }
    }
}
