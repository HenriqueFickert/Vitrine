using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VitrineAPI.Infrastructure.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlteradoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fabricante",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CNPJ = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlteradoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NomeArquivoBanco = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TamanhoEmBytes = table.Column<long>(type: "bigint", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExtensaoArquivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeArquivoOriginal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CaminhoRelativo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CaminhoAbsoluto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CaminhoFisico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoraEnvio = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fabricante", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubCategoria",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlteradoEm = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategoria", x => x.Id);
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
                        name: "FK_CategoriaSubCategoria_Categoria_CategoriasId",
                        column: x => x.CategoriasId,
                        principalTable: "Categoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoriaSubCategoria_SubCategoria_SubCategoriasId",
                        column: x => x.SubCategoriasId,
                        principalTable: "SubCategoria",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    Descricao = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    Valor = table.Column<int>(type: "int", maxLength: 10000, nullable: false),
                    Quantidade = table.Column<int>(type: "int", maxLength: 10000, nullable: false),
                    CondicaoProduto = table.Column<int>(type: "int", nullable: false),
                    SubCategoriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FabricanteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, defaultValue: "1"),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlteradoEm = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NomeArquivoBanco = table.Column<Guid>(type: "uniqueidentifier", maxLength: 50, nullable: false, defaultValueSql: "NEWID()"),
                    TamanhoEmBytes = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    ContentType = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    ExtensaoArquivo = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    NomeArquivoOriginal = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    CaminhoRelativo = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    CaminhoAbsoluto = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    CaminhoFisico = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: false),
                    HoraEnvio = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_Fabricante_FabricanteId",
                        column: x => x.FabricanteId,
                        principalTable: "Fabricante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produtos_SubCategoria_SubCategoriaId",
                        column: x => x.SubCategoriaId,
                        principalTable: "SubCategoria",
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
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Fabricante");

            migrationBuilder.DropTable(
                name: "SubCategoria");
        }
    }
}