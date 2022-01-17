using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NerdStore.Identity.Database.Configurations
{
    public class UserClaimConfig : IEntityTypeConfiguration<IdentityUserClaim<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserClaim<int>> userClaim)
        {
            userClaim.ToTable("user_claims");

            userClaim.HasKey(uc => uc.Id);
        }
    }
}
