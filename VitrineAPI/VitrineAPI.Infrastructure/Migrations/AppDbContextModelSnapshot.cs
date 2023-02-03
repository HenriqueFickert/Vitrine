﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VitrineAPI.Infrastructure.Data;

#nullable disable

namespace VitrineAPI.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CategoriaSubCategoria", b =>
                {
                    b.Property<Guid>("CategoriasId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SubCategoriasId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CategoriasId", "SubCategoriasId");

                    b.HasIndex("SubCategoriasId");

                    b.ToTable("CategoriaSubCategoria");
                });

            modelBuilder.Entity("VitrineAPI.Domain.Entities.Categoria", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("AlteradoEm")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("Descricao");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("Nome");

                    b.Property<string>("Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasDefaultValue("Ativo")
                        .HasColumnName("Status");

                    b.HasKey("Id");

                    b.ToTable("Categorias", (string)null);
                });

            modelBuilder.Entity("VitrineAPI.Domain.Entities.Fabricante", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("AlteradoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("CNPJ");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("Descricao");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("Nome");

                    b.Property<string>("Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasDefaultValue("Ativo")
                        .HasColumnName("Status");

                    b.HasKey("Id");

                    b.ToTable("Fabricantes", (string)null);
                });

            modelBuilder.Entity("VitrineAPI.Domain.Entities.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("AlteradoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("CaminhoAbsoluto")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("CaminhoAbsoluto");

                    b.Property<string>("CaminhoFisico")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("CaminhoFisico");

                    b.Property<string>("CaminhoRelativo")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("CaminhoRelativo");

                    b.Property<string>("CondicaoProduto")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasDefaultValue("1")
                        .HasColumnName("CondicaoProduto");

                    b.Property<string>("ContentType")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("ContentType");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("Descricao");

                    b.Property<string>("ExtensaoArquivo")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("ExtensaoArquivo");

                    b.Property<Guid>("FabricanteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("HoraEnvio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("Nome");

                    b.Property<Guid>("NomeArquivoBanco")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("NomeArquivoBanco")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("NomeArquivoOriginal")
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("NomeArquivoOriginal");

                    b.Property<int>("Quantidade")
                        .HasMaxLength(10000)
                        .HasColumnType("int")
                        .HasColumnName("Quantidade");

                    b.Property<string>("Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasDefaultValue("1")
                        .HasColumnName("Status");

                    b.Property<Guid>("SubCategoriaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TamanhoEmBytes")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("TamanhoEmBytes");

                    b.Property<int>("Valor")
                        .HasMaxLength(10000)
                        .HasColumnType("int")
                        .HasColumnName("Valor");

                    b.HasKey("Id");

                    b.HasIndex("FabricanteId");

                    b.HasIndex("SubCategoriaId");

                    b.ToTable("Produtos", (string)null);
                });

            modelBuilder.Entity("VitrineAPI.Domain.Entities.SubCategoria", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("AlteradoEm")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CriadoEm")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("Descricao");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("Nome");

                    b.Property<string>("Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasDefaultValue("Ativo")
                        .HasColumnName("Status");

                    b.HasKey("Id");

                    b.ToTable("SubCategorias", (string)null);
                });

            modelBuilder.Entity("CategoriaSubCategoria", b =>
                {
                    b.HasOne("VitrineAPI.Domain.Entities.Categoria", null)
                        .WithMany()
                        .HasForeignKey("CategoriasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VitrineAPI.Domain.Entities.SubCategoria", null)
                        .WithMany()
                        .HasForeignKey("SubCategoriasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VitrineAPI.Domain.Entities.Produto", b =>
                {
                    b.HasOne("VitrineAPI.Domain.Entities.Fabricante", "Fabricante")
                        .WithMany("Produtos")
                        .HasForeignKey("FabricanteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VitrineAPI.Domain.Entities.SubCategoria", "SubCategoria")
                        .WithMany("Produtos")
                        .HasForeignKey("SubCategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fabricante");

                    b.Navigation("SubCategoria");
                });

            modelBuilder.Entity("VitrineAPI.Domain.Entities.Fabricante", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("VitrineAPI.Domain.Entities.SubCategoria", b =>
                {
                    b.Navigation("Produtos");
                });
#pragma warning restore 612, 618
        }
    }
}
