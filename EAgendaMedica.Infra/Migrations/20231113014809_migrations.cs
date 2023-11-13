using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EAgendaMedica.Infra.Migrations
{
    public partial class migrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_Cirurgia",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraInicio = table.Column<long>(type: "bigint", nullable: false),
                    HoraTermino = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Cirurgia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TB_Medico",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CRM = table.Column<string>(type: "varchar(30)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Medico", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "TB_Medico_TB_Cirurgia",
                columns: table => new
                {
                    CirurgiasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MedicosId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Medico_TB_Cirurgia", x => new { x.CirurgiasId, x.MedicosId });
                    table.ForeignKey(
                        name: "FK_TB_Medico_TB_Cirurgia_TB_Cirurgia_CirurgiasId",
                        column: x => x.CirurgiasId,
                        principalTable: "TB_Cirurgia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_Medico_TB_Cirurgia_TB_Medico_MedicosId",
                        column: x => x.MedicosId,
                        principalTable: "TB_Medico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TB_Medico",
                columns: new[] { "Id", "CRM", "Nome" },
                values: new object[] { new Guid("8b07e2af-a2df-4b04-8fed-2a71f4cb7006"), "67890-SC", "Médico 2" });

            migrationBuilder.InsertData(
                table: "TB_Medico",
                columns: new[] { "Id", "CRM", "Nome" },
                values: new object[] { new Guid("b2eba290-c993-4016-9142-95008e5c0c65"), "12345-SC", "Médico 1" });

            migrationBuilder.CreateIndex(
                name: "IX_TB_Consulta_MedicoId",
                table: "TB_Consulta",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_Medico_CRM",
                table: "TB_Medico",
                column: "CRM",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TB_Medico_TB_Cirurgia_MedicosId",
                table: "TB_Medico_TB_Cirurgia",
                column: "MedicosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_Consulta");

            migrationBuilder.DropTable(
                name: "TB_Medico_TB_Cirurgia");

            migrationBuilder.DropTable(
                name: "TB_Cirurgia");

            migrationBuilder.DropTable(
                name: "TB_Medico");
        }
    }
}
