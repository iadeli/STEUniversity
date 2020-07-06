using Microsoft.EntityFrameworkCore.Migrations;

namespace Official.Persistence.EFCore.Migrations
{
    public partial class STEV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProvinceOfBirth",
                table: "Persons",
                newName: "ProvinceOfBirthId");

            migrationBuilder.RenameColumn(
                name: "Nationality",
                table: "Persons",
                newName: "NationalityId");

            migrationBuilder.RenameColumn(
                name: "LatinSurname",
                table: "Persons",
                newName: "LatinLastName");

            migrationBuilder.RenameColumn(
                name: "Ethnicity",
                table: "Persons",
                newName: "EthnicityId");

            migrationBuilder.RenameColumn(
                name: "DutySystemCode",
                table: "Persons",
                newName: "EnlistCode");

            migrationBuilder.RenameColumn(
                name: "CityOfBirth",
                table: "Persons",
                newName: "CityOfBirthId");

            migrationBuilder.RenameColumn(
                name: "BirthCountry",
                table: "Persons",
                newName: "BirthCountryId");

            migrationBuilder.AlterColumn<int>(
                name: "PrefixId",
                table: "Persons",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProvinceOfBirthId",
                table: "Persons",
                newName: "ProvinceOfBirth");

            migrationBuilder.RenameColumn(
                name: "NationalityId",
                table: "Persons",
                newName: "Nationality");

            migrationBuilder.RenameColumn(
                name: "LatinLastName",
                table: "Persons",
                newName: "LatinSurname");

            migrationBuilder.RenameColumn(
                name: "EthnicityId",
                table: "Persons",
                newName: "Ethnicity");

            migrationBuilder.RenameColumn(
                name: "EnlistCode",
                table: "Persons",
                newName: "DutySystemCode");

            migrationBuilder.RenameColumn(
                name: "CityOfBirthId",
                table: "Persons",
                newName: "CityOfBirth");

            migrationBuilder.RenameColumn(
                name: "BirthCountryId",
                table: "Persons",
                newName: "BirthCountry");

            migrationBuilder.AlterColumn<string>(
                name: "PrefixId",
                table: "Persons",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
