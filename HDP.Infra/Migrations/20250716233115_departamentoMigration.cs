using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HDP.Infra.Migrations
{
    public partial class departamentoMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departamento",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, comment: "Nome da Categoria"),
                    Status = table.Column<int>(type: "int", nullable: false, comment: "0 Ativo, 1 Inativo"),
                    Usuario_Inc = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "Usuário de Inclusão"),
                    Data_Hora_Inc = table.Column<DateTime>(type: "DATE", nullable: false, comment: "Data Hora Inclusão do Registro"),
                    Usuario_Alt = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, comment: "Usuário de Alteração"),
                    Data_Hora_Alt = table.Column<DateTime>(type: "DATE", nullable: false, comment: "Data Hora Alteração do Registro")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departamento",
                schema: "dbo");
        }
    }
}
