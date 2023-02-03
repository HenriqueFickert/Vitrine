using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VitrineAPI.Infrastructure.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    Status = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, defaultValue: "Ativo"),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlteradoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fabricantes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    CNPJ = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    Status = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, defaultValue: "Ativo"),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlteradoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fabricantes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubCategorias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    Status = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, defaultValue: "Ativo"),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlteradoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoriaSubCategoria",
                columns: table => new
                {
                    CategoriasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubCategoriasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaSubCategoria", x => new { x.CategoriasId, x.SubCategoriasId });
                    table.ForeignKey(
                        name: "FK_CategoriaSubCategoria_Categorias_CategoriasId",
                        column: x => x.CategoriasId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoriaSubCategoria_SubCategorias_SubCategoriasId",
                        column: x => x.SubCategoriasId,
                        principalTable: "SubCategorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubCategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FabricanteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    Valor = table.Column<int>(type: "int", maxLength: 10000, nullable: false),
                    Quantidade = table.Column<int>(type: "int", maxLength: 10000, nullable: false),
                    CondicaoProduto = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, defaultValue: "Novo"),
                    Status = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, defaultValue: "1"),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlteradoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NomeArquivoBanco = table.Column<Guid>(type: "uniqueidentifier", maxLength: 50, nullable: false, defaultValueSql: "NEWID()"),
                    TamanhoEmBytes = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    ContentType = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    ExtensaoArquivo = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true),
                    NomeArquivoOriginal = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    CaminhoRelativo = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    CaminhoAbsoluto = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    CaminhoFisico = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    HoraEnvio = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_Fabricantes_FabricanteId",
                        column: x => x.FabricanteId,
                        principalTable: "Fabricantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produtos_SubCategorias_SubCategoriaId",
                        column: x => x.SubCategoriaId,
                        principalTable: "SubCategorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoriaSubCategoria_SubCategoriasId",
                table: "CategoriaSubCategoria",
                column: "SubCategoriasId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_FabricanteId",
                table: "Produtos",
                column: "FabricanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_SubCategoriaId",
                table: "Produtos",
                column: "SubCategoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriaSubCategoria");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Fabricantes");

            migrationBuilder.DropTable(
                name: "SubCategorias");
        }
    }
}
