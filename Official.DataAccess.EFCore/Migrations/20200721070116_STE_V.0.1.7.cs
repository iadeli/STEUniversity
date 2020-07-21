using Microsoft.EntityFrameworkCore.Migrations;

namespace Official.Persistence.EFCore.Migrations
{
    public partial class STE_V017 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "PersonDetails");

            migrationBuilder.DropColumn(
                name: "HireTypeId",
                table: "HireStages");

            migrationBuilder.AddColumn<int>(
                name: "PositionId",
                table: "Persons",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsFacultymember",
                table: "HireStages",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PositionId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "IsFacultymember",
                table: "HireStages");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "PersonDetails",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "HireTypeId",
                table: "HireStages",
                nullable: false,
                defaultValue: 0);
        }
    }
}
