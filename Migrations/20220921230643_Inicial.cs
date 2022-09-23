using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeluqueriaStar.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HorarioEstelista",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disponibilidad = table.Column<bool>(type: "bit", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Horario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstelistaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorarioEstelista", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstadoSalud = table.Column<bool>(type: "bit", nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Administrador_EstelistaId = table.Column<int>(type: "int", nullable: true),
                    ClienteId = table.Column<int>(type: "int", nullable: true),
                    Administrador_ServiciosOfrecerId = table.Column<int>(type: "int", nullable: true),
                    Administrador_HorarioEstelistaId = table.Column<int>(type: "int", nullable: true),
                    Dirrecion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Edad = table.Column<int>(type: "int", nullable: true),
                    Genero = table.Column<int>(type: "int", nullable: true),
                    Membresia = table.Column<bool>(type: "bit", nullable: true),
                    CantidadCitas = table.Column<int>(type: "int", nullable: true),
                    EstelistaId = table.Column<int>(type: "int", nullable: true),
                    HorarioEstelistaId = table.Column<int>(type: "int", nullable: true),
                    ServiciosOfrecerId = table.Column<int>(type: "int", nullable: true),
                    TarjetaProfesional = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persona_HorarioEstelista_Administrador_HorarioEstelistaId",
                        column: x => x.Administrador_HorarioEstelistaId,
                        principalTable: "HorarioEstelista",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Persona_HorarioEstelista_HorarioEstelistaId",
                        column: x => x.HorarioEstelistaId,
                        principalTable: "HorarioEstelista",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Persona_Persona_Administrador_EstelistaId",
                        column: x => x.Administrador_EstelistaId,
                        principalTable: "Persona",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Persona_Persona_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Persona",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Persona_Persona_EstelistaId",
                        column: x => x.EstelistaId,
                        principalTable: "Persona",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ServiciosOfrecer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorServicio = table.Column<int>(type: "int", nullable: false),
                    ValorAplicarDescuento = table.Column<int>(type: "int", nullable: false),
                    ValorTotalServicio = table.Column<int>(type: "int", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstelistaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiciosOfrecer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiciosOfrecer_Persona_EstelistaId",
                        column: x => x.EstelistaId,
                        principalTable: "Persona",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HorarioEstelista_EstelistaId",
                table: "HorarioEstelista",
                column: "EstelistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_Administrador_EstelistaId",
                table: "Persona",
                column: "Administrador_EstelistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_Administrador_HorarioEstelistaId",
                table: "Persona",
                column: "Administrador_HorarioEstelistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_Administrador_ServiciosOfrecerId",
                table: "Persona",
                column: "Administrador_ServiciosOfrecerId");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_ClienteId",
                table: "Persona",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_EstelistaId",
                table: "Persona",
                column: "EstelistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_HorarioEstelistaId",
                table: "Persona",
                column: "HorarioEstelistaId");

            migrationBuilder.CreateIndex(
                name: "IX_Persona_ServiciosOfrecerId",
                table: "Persona",
                column: "ServiciosOfrecerId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiciosOfrecer_EstelistaId",
                table: "ServiciosOfrecer",
                column: "EstelistaId");

            migrationBuilder.AddForeignKey(
                name: "FK_HorarioEstelista_Persona_EstelistaId",
                table: "HorarioEstelista",
                column: "EstelistaId",
                principalTable: "Persona",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Persona_ServiciosOfrecer_Administrador_ServiciosOfrecerId",
                table: "Persona",
                column: "Administrador_ServiciosOfrecerId",
                principalTable: "ServiciosOfrecer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Persona_ServiciosOfrecer_ServiciosOfrecerId",
                table: "Persona",
                column: "ServiciosOfrecerId",
                principalTable: "ServiciosOfrecer",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HorarioEstelista_Persona_EstelistaId",
                table: "HorarioEstelista");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiciosOfrecer_Persona_EstelistaId",
                table: "ServiciosOfrecer");

            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "HorarioEstelista");

            migrationBuilder.DropTable(
                name: "ServiciosOfrecer");
        }
    }
}
