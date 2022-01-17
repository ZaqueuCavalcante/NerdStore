using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NerdStore.Identity.Domain;

namespace NerdStore.Identity.Database.Configurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> user)
        {
            user.ToTable("users");

            user.HasKey(u => u.Id);

            // Each User can have many UserClaims.
            user.HasMany<IdentityUserClaim<int>>()
                .WithOne()
                .HasForeignKey(uc => uc.UserId)
                .IsRequired();

            // Each User can have many UserLogins.
            user.HasMany<IdentityUserLogin<int>>()
                .WithOne()
                .HasForeignKey(ul => ul.UserId)
                .IsRequired();

            // Each User can have many UserTokens.
            user.HasMany<IdentityUserToken<int>>()
                .WithOne()
                .HasForeignKey(ut => ut.UserId)
                .IsRequired();

            // Each User can have many entries in the UserRole join table.
            user.HasMany<IdentityUserRole<int>>()
                .WithOne()
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();

            // A concurrency token for use with the optimistic concurrency checking.
            user.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

            // Indexes for normalized username and email, to allow efficient lookups.
            user.HasIndex(u => u.NormalizedUserName).HasDatabaseName("normalized_user_name_unique_index").IsUnique();
            user.HasIndex(u => u.NormalizedEmail).HasDatabaseName("normalized_email_index");

            // Custom configurations.
            user.HasMany<RefreshToken>(u => u.RefreshTokens)
                .WithOne()
                .HasForeignKey(rt => rt.UserId)
                .IsRequired();
        }
    }
}
