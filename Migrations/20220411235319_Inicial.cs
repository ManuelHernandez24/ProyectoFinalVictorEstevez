using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoFinal.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AreaTecnica",
                columns: table => new
                {
                    AreaTecnicaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreAreaTecnica = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaTecnica", x => x.AreaTecnicaId);
                });

            migrationBuilder.CreateTable(
                name: "Estudiante",
                columns: table => new
                {
                    EstudianteId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Apellidos = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Sexo = table.Column<string>(type: "TEXT", nullable: false),
                    Nacionalidad = table.Column<string>(type: "TEXT", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Direccion = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Telefono = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    AreaTecnicaId = table.Column<int>(type: "INTEGER", nullable: false),
                    NumeroIdentificacionMadre = table.Column<string>(type: "TEXT", maxLength: 11, nullable: false),
                    NombresMadre = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ApellidosMadre = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    TelefonoMadre = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    NumeroIdentificacionPadre = table.Column<string>(type: "TEXT", maxLength: 11, nullable: false),
                    NombresPadre = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    ApellidosPadre = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    TelefonoPadre = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiante", x => x.EstudianteId);
                });

            migrationBuilder.CreateTable(
                name: "Maestro",
                columns: table => new
                {
                    MaestroId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NumeroIdentificacion = table.Column<string>(type: "TEXT", maxLength: 11, nullable: true),
                    Nombres = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Apellidos = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Sexo = table.Column<string>(type: "TEXT", nullable: false),
                    Nacionalidad = table.Column<string>(type: "TEXT", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Direccion = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Telefono = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    CantidadMaterias = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maestro", x => x.MaestroId);
                });

            migrationBuilder.CreateTable(
                name: "Materia",
                columns: table => new
                {
                    MateriaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreMateria = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    VecesAsignada = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materia", x => x.MateriaId);
                });

            migrationBuilder.CreateTable(
                name: "Seccion",
                columns: table => new
                {
                    SeccionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MaestroId = table.Column<int>(type: "INTEGER", nullable: false),
                    Grado = table.Column<string>(type: "TEXT", nullable: false),
                    Grupo = table.Column<string>(type: "TEXT", nullable: false),
                    AreaTecnicaId = table.Column<int>(type: "INTEGER", nullable: false),
                    CantidadEstudiantes = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seccion", x => x.SeccionId);
                });

            migrationBuilder.CreateTable(
                name: "MaestroDetalle",
                columns: table => new
                {
                    MaestroDetalleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MaestroId = table.Column<int>(type: "INTEGER", nullable: false),
                    MateriaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaestroDetalle", x => x.MaestroDetalleId);
                    table.ForeignKey(
                        name: "FK_MaestroDetalle_Maestro_MaestroId",
                        column: x => x.MaestroId,
                        principalTable: "Maestro",
                        principalColumn: "MaestroId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeccionDetalle",
                columns: table => new
                {
                    SeccionId = table.Column<int>(type: "INTEGER", nullable: false),
                    EstudianteId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeccionDetalle", x => x.SeccionId);
                    table.ForeignKey(
                        name: "FK_SeccionDetalle_Seccion_SeccionId",
                        column: x => x.SeccionId,
                        principalTable: "Seccion",
                        principalColumn: "SeccionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AreaTecnica",
                columns: new[] { "AreaTecnicaId", "NombreAreaTecnica" },
                values: new object[] { 1, "Académico" });

            migrationBuilder.InsertData(
                table: "AreaTecnica",
                columns: new[] { "AreaTecnicaId", "NombreAreaTecnica" },
                values: new object[] { 2, "Informática" });

            migrationBuilder.InsertData(
                table: "AreaTecnica",
                columns: new[] { "AreaTecnicaId", "NombreAreaTecnica" },
                values: new object[] { 3, "Contabilidad" });

            migrationBuilder.InsertData(
                table: "Materia",
                columns: new[] { "MateriaId", "NombreMateria", "VecesAsignada" },
                values: new object[] { 1, "Lengua Española", 0 });

            migrationBuilder.InsertData(
                table: "Materia",
                columns: new[] { "MateriaId", "NombreMateria", "VecesAsignada" },
                values: new object[] { 2, "Matemática", 0 });

            migrationBuilder.InsertData(
                table: "Materia",
                columns: new[] { "MateriaId", "NombreMateria", "VecesAsignada" },
                values: new object[] { 3, "Ciencias Naturales", 0 });

            migrationBuilder.InsertData(
                table: "Materia",
                columns: new[] { "MateriaId", "NombreMateria", "VecesAsignada" },
                values: new object[] { 4, "Ciencias Sociales", 0 });

            migrationBuilder.CreateIndex(
                name: "IX_MaestroDetalle_MaestroId",
                table: "MaestroDetalle",
                column: "MaestroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AreaTecnica");

            migrationBuilder.DropTable(
                name: "Estudiante");

            migrationBuilder.DropTable(
                name: "MaestroDetalle");

            migrationBuilder.DropTable(
                name: "Materia");

            migrationBuilder.DropTable(
                name: "SeccionDetalle");

            migrationBuilder.DropTable(
                name: "Maestro");

            migrationBuilder.DropTable(
                name: "Seccion");
        }
    }
}
