using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VitrineAPI.Domain.Entities;
using VitrineAPI.Infrastructure.Configurations.Base;

namespace VitrineAPI.Infrastructure.Configurations
{
    public class ProdutoConfiguration : ConfigurationUploadFormBase<Produto>
    {
        public override void Configure(EntityTypeBuilder<Produto> builder)
        {
            tableName = "Produtos";

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

            builder.Property(p => p.Valor)
                   .IsRequired()
                   .HasMaxLength(10000)
                   .HasColumnName("Valor")
                   .HasColumnType("int");

            builder.Property(p => p.Quantidade)
                   .IsRequired()
                   .HasMaxLength(10000)
                   .HasColumnName("Quantidade")
                   .HasColumnType("int");

            builder.Property(p => p.CondicaoProduto)
                     .IsRequired()
                     .HasMaxLength(50)
                     .HasColumnName("CondicaoProduto")
                     .HasColumnType("varchar(50)")
                     .HasDefaultValue("Novo");
        }
    }
}