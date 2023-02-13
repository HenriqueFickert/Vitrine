using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VitrineAPI.Infrastructure.Migrations
{
    public partial class Atualizacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CaminhoAbsoluto",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "CaminhoFisico",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "CaminhoRelativo",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "ExtensaoArquivo",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "HoraEnvio",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "NomeArquivoBanco",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "NomeArquivoOriginal",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "TamanhoEmBytes",
                table: "Produtos");

            migrationBuilder.AlterColumn<string>(
                name: "TamanhoEmBytes",
                table: "Uploads",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "HoraEnvio",
                table: "Uploads",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Produtos",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "Ativo",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldDefaultValue: "1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TamanhoEmBytes",
                table: "Uploads",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "HoraEnvio",
                table: "Uploads",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Produtos",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "1",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldDefaultValue: "Ativo");

            migrationBuilder.AddColumn<string>(
                name: "CaminhoAbsoluto",
                table: "Produtos",
                type: "varchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CaminhoFisico",
                table: "Produtos",
                type: "varchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CaminhoRelativo",
                table: "Produtos",
                type: "varchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "Produtos",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtensaoArquivo",
                table: "Produtos",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "HoraEnvio",
                table: "Produtos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "NomeArquivoBanco",
                table: "Produtos",
                type: "uniqueidentifier",
                maxLength: 50,
                nullable: false,
                defaultValueSql: "NEWID()");

            migrationBuilder.AddColumn<string>(
                name: "NomeArquivoOriginal",
                table: "Produtos",
                type: "varchar(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TamanhoEmBytes",
                table: "Produtos",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
