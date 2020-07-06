using Microsoft.EntityFrameworkCore.Migrations;

namespace Official.Persistence.EFCore.Migrations
{
    public partial class STEV19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Religion",
                table: "Persons",
                newName: "SubReligionId");

            migrationBuilder.RenameColumn(
                name: "MaritalStatus",
                table: "Persons",
                newName: "ReligionId");

            migrationBuilder.RenameColumn(
                name: "Faith",
                table: "Persons",
                newName: "MarriedId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubReligionId",
                table: "Persons",
                newName: "Religion");

            migrationBuilder.RenameColumn(
                name: "ReligionId",
                table: "Persons",
                newName: "MaritalStatus");

            migrationBuilder.RenameColumn(
                name: "MarriedId",
                table: "Persons",
                newName: "Faith");
        }
    }
}
