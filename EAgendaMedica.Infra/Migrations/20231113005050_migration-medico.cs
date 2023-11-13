using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EAgendaMedica.Infra.Migrations
{
    public partial class migrationmedico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TB_Medico",
                keyColumn: "Id",
                keyValue: new Guid("4d664675-cb8a-495f-a092-29fec45a5f01"));

            migrationBuilder.DeleteData(
                table: "TB_Medico",
                keyColumn: "Id",
                keyValue: new Guid("a27f12a9-a9f8-4098-965b-65e5e01ebd65"));

            migrationBuilder.InsertData(
                table: "TB_Medico",
                columns: new[] { "Id", "CRM", "Nome" },
                values: new object[] { new Guid("9c792efe-118d-448b-82f4-700cef800309"), "12345-SC", "Médico 1" });

            migrationBuilder.InsertData(
                table: "TB_Medico",
                columns: new[] { "Id", "CRM", "Nome" },
                values: new object[] { new Guid("ba23668e-e59e-4ca0-8e7a-3ab654f48882"), "67890-SC", "Médico 2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TB_Medico",
                keyColumn: "Id",
                keyValue: new Guid("9c792efe-118d-448b-82f4-700cef800309"));

            migrationBuilder.DeleteData(
                table: "TB_Medico",
                keyColumn: "Id",
                keyValue: new Guid("ba23668e-e59e-4ca0-8e7a-3ab654f48882"));

            migrationBuilder.InsertData(
                table: "TB_Medico",
                columns: new[] { "Id", "CRM", "Nome" },
                values: new object[] { new Guid("4d664675-cb8a-495f-a092-29fec45a5f01"), "67890-SC", "Médico 2" });

            migrationBuilder.InsertData(
                table: "TB_Medico",
                columns: new[] { "Id", "CRM", "Nome" },
                values: new object[] { new Guid("a27f12a9-a9f8-4098-965b-65e5e01ebd65"), "12345-SC", "Médico 1" });
        }
    }
}
