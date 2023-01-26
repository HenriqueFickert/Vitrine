using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaAPI.Domain.Entities.Base;

namespace MinhaAPI.Infrastructure.Configurations.Base
{
    public class ConfigurationBase<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : EntityBase
    {
        protected string tableName;

        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.ToTable(tableName);

            builder.HasKey(x => x.Id);

            builder.Property(p => p.Status)
                   .IsRequired()
                   .HasMaxLength(50)
                   .HasColumnName("Status")
                   .HasColumnType("varchar(50)")
                   .HasDefaultValue("Ativo");
        }
    }
}