using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VitrineAPI.Domain.Entities;
using VitrineAPI.Infrastructure.Configurations.Base;

namespace VitrineAPI.Infrastructure.Configurations
{
    public class TipoImagemConfiguration : ConfigurationBase<TipoImagem>
    {
        public override void Configure(EntityTypeBuilder<TipoImagem> builder)
        {
            tableName = "TipoImagens";

            base.Configure(builder);

            builder.Property(p => p.Nome)
                    .IsRequired()
                    .HasColumnName("Nome")
                    .HasMaxLength(300)
                    .HasColumnType("varchar(300)");
        }
    }
}