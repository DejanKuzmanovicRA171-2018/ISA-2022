using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class SpentBlood : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpentBlood",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransfusionCenterId = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rh = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    DateOfExpenditure = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpentBlood", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpentBlood_TransfusionCenters_TransfusionCenterId",
                        column: x => x.TransfusionCenterId,
                        principalTable: "TransfusionCenters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpentBlood_TransfusionCenterId",
                table: "SpentBlood",
                column: "TransfusionCenterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpentBlood");
        }
    }
}
