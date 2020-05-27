using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebEscola.Migrations
{
    public partial class ComplexDataModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartamentoID",
                table: "Curso",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Instrutor",
                columns: table => new
                {
                    InstrutorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true),
                    Contratacao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instrutor", x => x.InstrutorID);
                });

            migrationBuilder.CreateTable(
                name: "CursoInstrutor",
                columns: table => new
                {
                    CursoInstrutorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstrutorID = table.Column<int>(nullable: true),
                    CursoID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursoInstrutor", x => x.CursoInstrutorID);
                    table.ForeignKey(
                        name: "FK_CursoInstrutor_Curso_CursoID",
                        column: x => x.CursoID,
                        principalTable: "Curso",
                        principalColumn: "CursoID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CursoInstrutor_Instrutor_InstrutorID",
                        column: x => x.InstrutorID,
                        principalTable: "Instrutor",
                        principalColumn: "InstrutorID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    DepartamentoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstrutorID = table.Column<int>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Orcamento = table.Column<decimal>(nullable: false),
                    Inicio = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.DepartamentoID);
                    table.ForeignKey(
                        name: "FK_Departamento_Instrutor_InstrutorID",
                        column: x => x.InstrutorID,
                        principalTable: "Instrutor",
                        principalColumn: "InstrutorID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Escritorio",
                columns: table => new
                {
                    EscritorioID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstrutorID = table.Column<int>(nullable: false),
                    Localizacao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escritorio", x => x.EscritorioID);
                    table.ForeignKey(
                        name: "FK_Escritorio_Instrutor_InstrutorID",
                        column: x => x.InstrutorID,
                        principalTable: "Instrutor",
                        principalColumn: "InstrutorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Curso_DepartamentoID",
                table: "Curso",
                column: "DepartamentoID");

            migrationBuilder.CreateIndex(
                name: "IX_CursoInstrutor_CursoID",
                table: "CursoInstrutor",
                column: "CursoID");

            migrationBuilder.CreateIndex(
                name: "IX_CursoInstrutor_InstrutorID",
                table: "CursoInstrutor",
                column: "InstrutorID");

            migrationBuilder.CreateIndex(
                name: "IX_Departamento_InstrutorID",
                table: "Departamento",
                column: "InstrutorID");

            migrationBuilder.CreateIndex(
                name: "IX_Escritorio_InstrutorID",
                table: "Escritorio",
                column: "InstrutorID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Curso_Departamento_DepartamentoID",
                table: "Curso",
                column: "DepartamentoID",
                principalTable: "Departamento",
                principalColumn: "DepartamentoID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Curso_Departamento_DepartamentoID",
                table: "Curso");

            migrationBuilder.DropTable(
                name: "CursoInstrutor");

            migrationBuilder.DropTable(
                name: "Departamento");

            migrationBuilder.DropTable(
                name: "Escritorio");

            migrationBuilder.DropTable(
                name: "Instrutor");

            migrationBuilder.DropIndex(
                name: "IX_Curso_DepartamentoID",
                table: "Curso");

            migrationBuilder.DropColumn(
                name: "DepartamentoID",
                table: "Curso");
        }
    }
}
