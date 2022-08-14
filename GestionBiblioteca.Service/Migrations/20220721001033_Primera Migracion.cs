using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GestionBiblioteca.Service.Migrations
{
    public partial class PrimeraMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autor",
                columns: table => new
                {
                    IdAutor = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    Apellido = table.Column<string>(type: "text", nullable: false),
                    Nacionalidad = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autor", x => x.IdAutor);
                });

            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    IdCategoria = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NombreCategoria = table.Column<string>(type: "text", nullable: false),
                    DescripcionCategoria = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Idioma",
                columns: table => new
                {
                    IdIdioma = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NombreIdioma = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idioma", x => x.IdIdioma);
                });

            migrationBuilder.CreateTable(
                name: "Libro",
                columns: table => new
                {
                    IdLibro = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titulo = table.Column<string>(type: "text", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: true),
                    Año = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IdIdioma_fk = table.Column<long>(type: "bigint", nullable: false),
                    Valoracion = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libro", x => x.IdLibro);
                    table.ForeignKey(
                        name: "FK_Libro_Idioma_IdIdioma_fk",
                        column: x => x.IdIdioma_fk,
                        principalTable: "Idioma",
                        principalColumn: "IdIdioma",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LibroAutor",
                columns: table => new
                {
                    IdLibroAutor = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdLibro_fk = table.Column<long>(type: "bigint", nullable: false),
                    IdAutor_fk = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibroAutor", x => x.IdLibroAutor);
                    table.ForeignKey(
                        name: "FK_LibroAutor_Autor_IdAutor_fk",
                        column: x => x.IdAutor_fk,
                        principalTable: "Autor",
                        principalColumn: "IdAutor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LibroAutor_Libro_IdLibro_fk",
                        column: x => x.IdLibro_fk,
                        principalTable: "Libro",
                        principalColumn: "IdLibro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LibroCategoria",
                columns: table => new
                {
                    IdLibroCategoria = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdLibro_fk = table.Column<long>(type: "bigint", nullable: false),
                    IdCategoria_fk = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibroCategoria", x => x.IdLibroCategoria);
                    table.ForeignKey(
                        name: "FK_LibroCategoria_Categoria_IdCategoria_fk",
                        column: x => x.IdCategoria_fk,
                        principalTable: "Categoria",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LibroCategoria_Libro_IdLibro_fk",
                        column: x => x.IdLibro_fk,
                        principalTable: "Libro",
                        principalColumn: "IdLibro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Libro_IdIdioma_fk",
                table: "Libro",
                column: "IdIdioma_fk");

            migrationBuilder.CreateIndex(
                name: "IX_LibroAutor_IdAutor_fk",
                table: "LibroAutor",
                column: "IdAutor_fk");

            migrationBuilder.CreateIndex(
                name: "IX_LibroAutor_IdLibro_fk",
                table: "LibroAutor",
                column: "IdLibro_fk");

            migrationBuilder.CreateIndex(
                name: "IX_LibroCategoria_IdCategoria_fk",
                table: "LibroCategoria",
                column: "IdCategoria_fk");

            migrationBuilder.CreateIndex(
                name: "IX_LibroCategoria_IdLibro_fk",
                table: "LibroCategoria",
                column: "IdLibro_fk");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LibroAutor");

            migrationBuilder.DropTable(
                name: "LibroCategoria");

            migrationBuilder.DropTable(
                name: "Autor");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Libro");

            migrationBuilder.DropTable(
                name: "Idioma");
        }
    }
}
