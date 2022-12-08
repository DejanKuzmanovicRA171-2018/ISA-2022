using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class FieldsRegUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "RegUsers",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "RegUsers",
                newName: "JMBG");

            migrationBuilder.AddColumn<string>(
                name: "Career",
                table: "RegUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "RegUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CompanyName",
                table: "RegUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "RegUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "RegUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "RegUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "RegUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Weight",
                table: "RegUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RegUserId",
                table: "Appointments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_RegUserId",
                table: "Appointments",
                column: "RegUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_RegUsers_RegUserId",
                table: "Appointments",
                column: "RegUserId",
                principalTable: "RegUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_RegUsers_RegUserId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_RegUserId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "Career",
                table: "RegUsers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "RegUsers");

            migrationBuilder.DropColumn(
                name: "CompanyName",
                table: "RegUsers");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "RegUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "RegUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "RegUsers");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "RegUsers");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "RegUsers");

            migrationBuilder.DropColumn(
                name: "RegUserId",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "RegUsers",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "JMBG",
                table: "RegUsers",
                newName: "Name");
        }
    }
}
