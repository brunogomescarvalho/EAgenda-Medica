using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EAgendaMedica.Infra.Migrations
{
    public partial class migrationconsulta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TB_Medico",
                keyColumn: "Id",
                keyValue: new Guid("9c792efe-118d-448b-82f4-700cef800309"));

            migrationBuilder.DeleteData(
                table: "TB_Medico",
                keyColumn: "Id",
                keyValue: new Guid("ba23668e-e59e-4ca0-8e7a-3ab654f48882"));

            migrationBuilder.CreateTable(
                name: "TB_Consulta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraInicio = table.Column<long>(type: "bigint", nullable: false),
                    HoraTermino = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Consulta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_Consulta_TB_Medico_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "TB_Medico",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "TB_Medico",
                columns: new[] { "Id", "CRM", "Nome" },
                values: new object[] { new Guid("1ccb16b9-b816-48ea-a94a-1f19e26a51dc"), "12345-SC", "Médico 1" });

            migrationBuilder.InsertData(
                table: "TB_Medico",
                columns: new[] { "Id", "CRM", "Nome" },
                values: new object[] { new Guid("2365707a-de2a-409a-905e-9ffbc77116cc"), "67890-SC", "Médico 2" });

            migrationBuilder.CreateIndex(
                name: "IX_TB_Consulta_MedicoId",
                table: "TB_Consulta",
                column: "MedicoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_Consulta");

            migrationBuilder.DeleteData(
                table: "TB_Medico",
                keyColumn: "Id",
                keyValue: new Guid("1ccb16b9-b816-48ea-a94a-1f19e26a51dc"));

            migrationBuilder.DeleteData(
                table: "TB_Medico",
                keyColumn: "Id",
                keyValue: new Guid("2365707a-de2a-409a-905e-9ffbc77116cc"));

            migrationBuilder.InsertData(
                table: "TB_Medico",
                columns: new[] { "Id", "CRM", "Nome" },
                values: new object[] { new Guid("9c792efe-118d-448b-82f4-700cef800309"), "12345-SC", "Médico 1" });

            migrationBuilder.InsertData(
                table: "TB_Medico",
                columns: new[] { "Id", "CRM", "Nome" },
                values: new object[] { new Guid("ba23668e-e59e-4ca0-8e7a-3ab654f48882"), "67890-SC", "Médico 2" });
        }
    }
}
