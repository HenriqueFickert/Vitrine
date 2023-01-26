using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MinhaAPI.Identity.Entities;

namespace MinhaAPI.Identity.Data
{
    public class IdentityDataContext : IdentityDbContext<Usuario>
    {
        public IdentityDataContext(DbContextOptions<IdentityDataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(IdentityDataContext).Assembly);
            builder.HasDefaultSchema("Identity");
        }
    }
}