using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HDP.Infra.Migrations
{
    public partial class refatorandoContexto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "Categoria",
                newName: "Categoria",
                newSchema: "dbo");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                schema: "dbo",
                table: "Categoria",
                type: "int",
                nullable: false,
                comment: "0 Ativo, 1 Inativo",
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                schema: "dbo",
                table: "Categoria",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                comment: "Nome da Categoria",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Data_Hora_Alt",
                schema: "dbo",
                table: "Categoria",
                type: "DATE",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Data Hora Alteração do Registro");

            migrationBuilder.AddColumn<DateTime>(
                name: "Data_Hora_Inc",
                schema: "dbo",
                table: "Categoria",
                type: "DATE",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Data Hora Inclusão do Registro");

            migrationBuilder.AddColumn<string>(
                name: "Usuario_Alt",
                schema: "dbo",
                table: "Categoria",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Usuário de Alteração");

            migrationBuilder.AddColumn<string>(
                name: "Usuario_Inc",
                schema: "dbo",
                table: "Categoria",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Usuário de Inclusão");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data_Hora_Alt",
                schema: "dbo",
                table: "Categoria");

            migrationBuilder.DropColumn(
                name: "Data_Hora_Inc",
                schema: "dbo",
                table: "Categoria");

            migrationBuilder.DropColumn(
                name: "Usuario_Alt",
                schema: "dbo",
                table: "Categoria");

            migrationBuilder.DropColumn(
                name: "Usuario_Inc",
                schema: "dbo",
                table: "Categoria");

            migrationBuilder.RenameTable(
                name: "Categoria",
                schema: "dbo",
                newName: "Categoria");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Categoria",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "0 Ativo, 1 Inativo");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Categoria",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100,
                oldComment: "Nome da Categoria");
        }
    }
}
