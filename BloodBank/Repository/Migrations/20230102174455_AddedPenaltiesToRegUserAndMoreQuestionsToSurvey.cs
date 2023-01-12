using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class AddedPenaltiesToRegUserAndMoreQuestionsToSurvey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Q10",
                table: "Surveys",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Q11",
                table: "Surveys",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Q12",
                table: "Surveys",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Q13",
                table: "Surveys",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Q14",
                table: "Surveys",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Q15",
                table: "Surveys",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Q16",
                table: "Surveys",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Q17",
                table: "Surveys",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Q18",
                table: "Surveys",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Q19",
                table: "Surveys",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Q20",
                table: "Surveys",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Q21",
                table: "Surveys",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Q22",
                table: "Surveys",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Q23",
                table: "Surveys",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Q3",
                table: "Surveys",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Q4",
                table: "Surveys",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Q5",
                table: "Surveys",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Q6",
                table: "Surveys",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Q7",
                table: "Surveys",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Q8",
                table: "Surveys",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Q9",
                table: "Surveys",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Penalties",
                table: "RegUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Q10",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "Q11",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "Q12",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "Q13",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "Q14",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "Q15",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "Q16",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "Q17",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "Q18",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "Q19",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "Q20",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "Q21",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "Q22",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "Q23",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "Q3",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "Q4",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "Q5",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "Q6",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "Q7",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "Q8",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "Q9",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "Penalties",
                table: "RegUsers");
        }
    }
}
