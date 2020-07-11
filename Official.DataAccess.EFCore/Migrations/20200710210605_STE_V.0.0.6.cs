using Microsoft.EntityFrameworkCore.Migrations;

namespace Official.Persistence.EFCore.Migrations
{
    public partial class STE_V006 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "BirthCertificates");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "BirthCertificates");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Persons",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Persons");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "BirthCertificates",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "BirthCertificates",
                nullable: true);
        }
    }
}
