using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EAgendaMedica.Infra.Migrations
{
    public partial class addmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_Cirurgia",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraInicio = table.Column<long>(type: "bigint", nullable: false),
                    DuracaoEmMinutos = table.Column<int>(type: "int", nullable: false)
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
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
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
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HoraInicio = table.Column<long>(type: "bigint", nullable: false),
                    DuracaoEmMinutos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Consulta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TB_Consulta_TB_Medico_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "TB_Medico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                columns: new[] { "Id", "Ativo", "CRM", "Nome" },
                values: new object[] { new Guid("a512564f-0a79-4abc-b04a-a2da4463ee94"), true, "12345-SC", "Médico 1" });

            migrationBuilder.InsertData(
                table: "TB_Medico",
                columns: new[] { "Id", "Ativo", "CRM", "Nome" },
                values: new object[] { new Guid("ff1cd1a4-ec4e-47af-893e-84d05b6e694d"), true, "67890-SC", "Médico 2" });

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
