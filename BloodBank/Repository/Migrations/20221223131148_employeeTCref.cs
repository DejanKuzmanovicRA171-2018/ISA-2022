using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class employeeTCref : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastBloodDonation",
                table: "RegUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "TransfusionCenterId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_TransfusionCenterId",
                table: "Employees",
                column: "TransfusionCenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_TransfusionCenters_TransfusionCenterId",
                table: "Employees",
                column: "TransfusionCenterId",
                principalTable: "TransfusionCenters",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_TransfusionCenters_TransfusionCenterId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_TransfusionCenterId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "LastBloodDonation",
                table: "RegUsers");

            migrationBuilder.DropColumn(
                name: "TransfusionCenterId",
                table: "Employees");
        }
    }
}
