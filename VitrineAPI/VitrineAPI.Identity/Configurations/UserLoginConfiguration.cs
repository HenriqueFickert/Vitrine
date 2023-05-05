using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VitrineAPI.Identity.Configurations
{
    public class UserLoginConfiguration : IEntityTypeConfiguration<IdentityUserLogin<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserLogin<string>> builder)
        {
            builder.ToTable(name: "UserLogins");
        }
    }
}