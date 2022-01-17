using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NerdStore.Identity.Database.Configurations
{
    public class RoleClaimConfig : IEntityTypeConfiguration<IdentityRoleClaim<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityRoleClaim<int>> roleClaim)
        {
            roleClaim.ToTable("role_claims");

            roleClaim.HasKey(rc => rc.Id);
        }
    }
}
