using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenWeather_Desafio.Migrations
{
    public partial class incial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Temp = table.Column<double>(type: "double", precision: 10, scale: 2, nullable: false),
                    TempMax = table.Column<double>(type: "double", precision: 10, scale: 2, nullable: false),
                    TempMin = table.Column<double>(type: "double", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "Nome", "Temp", "TempMax", "TempMin" },
                values: new object[] { new DateTime(2021, 12, 22, 12, 31, 45, 11, DateTimeKind.Local).AddTicks(9655), "Teste", 0.0, 0.0, 0.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
