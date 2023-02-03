using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VitrineAPI.Domain.Entities;
using VitrineAPI.Infrastructure.Configurations.Base;

namespace VitrineAPI.Infrastructure.Configurations
{
    public class FabricanteConfiguration : ConfigurationBase<Fabricante>
    {
        public override void Configure(EntityTypeBuilder<Fabricante> builder)
        {
            tableName = "Fabricantes";

            base.Configure(builder);

            builder.Property(p => p.Nome)
                    .IsRequired()
                    .HasColumnName("Nome")
                    .HasMaxLength(300)
                    .HasColumnType("varchar(300)");

            builder.Property(p => p.Descricao)
                    .IsRequired()
                    .HasColumnName("Descricao")
                    .HasMaxLength(300)
                    .HasColumnType("varchar(300)");

            //TODO: Adicionar CNPJ em String
        }
    }
}