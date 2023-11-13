using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EAgendaMedica.Infra.Migrations
{
    public partial class migrationmedico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_Medico",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CRM = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_Medico", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TB_Medico",
                columns: new[] { "Id", "CRM", "Nome" },
                values: new object[] { new Guid("74d7d3e7-7227-41d2-bb69-f0f22b0d089f"), "12345-SC", "Médico 1" });

            migrationBuilder.InsertData(
                table: "TB_Medico",
                columns: new[] { "Id", "CRM", "Nome" },
                values: new object[] { new Guid("9e4c827c-9279-4ea7-8fb7-3b911068273a"), "67890-SC", "Médico 2" });

            migrationBuilder.CreateIndex(
                name: "IX_TB_Medico_CRM",
                table: "TB_Medico",
                column: "CRM",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_Medico");
        }
    }
}
