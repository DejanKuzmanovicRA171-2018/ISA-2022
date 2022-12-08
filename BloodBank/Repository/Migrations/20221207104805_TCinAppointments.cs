using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class TCinAppointments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TransfusionCenterId",
                table: "Appointments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_TransfusionCenterId",
                table: "Appointments",
                column: "TransfusionCenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_TransfusionCenters_TransfusionCenterId",
                table: "Appointments",
                column: "TransfusionCenterId",
                principalTable: "TransfusionCenters",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_TransfusionCenters_TransfusionCenterId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_TransfusionCenterId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "TransfusionCenterId",
                table: "Appointments");
        }
    }
}
