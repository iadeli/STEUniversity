using Microsoft.EntityFrameworkCore.Migrations;

namespace Official.Persistence.EFCore.Migrations
{
    public partial class STEV213 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LatinLastName",
                table: "Persons");

            migrationBuilder.RenameColumn(
                name: "ProvinceOfBirthId",
                table: "Persons",
                newName: "IssueCityId");

            migrationBuilder.RenameColumn(
                name: "PlaceOfIssue",
                table: "Persons",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Persons",
                newName: "ELastName");

            migrationBuilder.RenameColumn(
                name: "LatinName",
                table: "Persons",
                newName: "EFirstName");

            migrationBuilder.AddColumn<int>(
                name: "BirthProvinceId",
                table: "Persons",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthProvinceId",
                table: "Persons");

            migrationBuilder.RenameColumn(
                name: "IssueCityId",
                table: "Persons",
                newName: "ProvinceOfBirthId");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Persons",
                newName: "PlaceOfIssue");

            migrationBuilder.RenameColumn(
                name: "ELastName",
                table: "Persons",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "EFirstName",
                table: "Persons",
                newName: "LatinName");

            migrationBuilder.AddColumn<string>(
                name: "LatinLastName",
                table: "Persons",
                nullable: true);
        }
    }
}
