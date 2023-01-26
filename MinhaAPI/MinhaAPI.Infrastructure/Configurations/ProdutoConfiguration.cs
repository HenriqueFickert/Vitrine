﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaAPI.Domain.Entities;
using MinhaAPI.Infrastructure.Configurations.Base;

namespace MinhaAPI.Infrastructure.Configurations
{
    public class ProdutoConfiguration : ConfigurationBase<Produto>
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
        }
    }
}