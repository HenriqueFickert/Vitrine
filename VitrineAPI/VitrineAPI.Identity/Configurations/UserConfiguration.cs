﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VitrineAPI.Identity.Entities;

namespace VitrineAPI.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable(name: "User");

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            builder.Property(u => u.CPF)
                .HasMaxLength(128)
                .HasColumnType("varchar(128)");

            builder.Property(u => u.UserName)
                .HasMaxLength(128)
                .HasColumnType("varchar(128)");

            builder.Property(u => u.NormalizedUserName)
                .HasMaxLength(128)
                .HasColumnType("varchar(128)");

            builder.Property(u => u.Email)
                .HasMaxLength(128)
                .HasColumnType("varchar(128)");

            builder.Property(u => u.NormalizedEmail)
                .HasMaxLength(128)
                .HasColumnType("varchar(128)");

            builder.Property(u => u.PasswordHash)
                .HasMaxLength(1000)
                .HasColumnType("varchar(1000)");

            builder.Property(p => p.Status)
               .IsRequired()
               .HasMaxLength(50)
               .HasColumnName("Status")
               .HasColumnType("varchar(50)")
               .HasDefaultValue("Ativo");
        }
    }
}