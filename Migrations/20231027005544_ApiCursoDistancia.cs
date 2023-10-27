using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api_SistemaCursosDistancia.Migrations
{
    /// <inheritdoc />
    public partial class ApiCursoDistancia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CadastroCDs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CadastroCDs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CursoCDs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    dataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Instrutor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CadastroCDId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursoCDs", x => x.id);
                    table.ForeignKey(
                        name: "FK_CursoCDs_CadastroCDs_CadastroCDId",
                        column: x => x.CadastroCDId,
                        principalTable: "CadastroCDs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ModuloCDs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CursoId = table.Column<int>(type: "int", nullable: false),
                    CursoCDid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModuloCDs", x => x.id);
                    table.ForeignKey(
                        name: "FK_ModuloCDs_CursoCDs_CursoCDid",
                        column: x => x.CursoCDid,
                        principalTable: "CursoCDs",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "AulaCDs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    conteudo = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    arquivo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModuloId = table.Column<int>(type: "int", nullable: false),
                    ModuloCDid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AulaCDs", x => x.id);
                    table.ForeignKey(
                        name: "FK_AulaCDs_ModuloCDs_ModuloCDid",
                        column: x => x.ModuloCDid,
                        principalTable: "ModuloCDs",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AulaCDs_ModuloCDid",
                table: "AulaCDs",
                column: "ModuloCDid");

            migrationBuilder.CreateIndex(
                name: "IX_CursoCDs_CadastroCDId",
                table: "CursoCDs",
                column: "CadastroCDId");

            migrationBuilder.CreateIndex(
                name: "IX_ModuloCDs_CursoCDid",
                table: "ModuloCDs",
                column: "CursoCDid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AulaCDs");

            migrationBuilder.DropTable(
                name: "ModuloCDs");

            migrationBuilder.DropTable(
                name: "CursoCDs");

            migrationBuilder.DropTable(
                name: "CadastroCDs");
        }
    }
}
