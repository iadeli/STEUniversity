using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Official.Persistence.EFCore.Migrations
{
    public partial class STE_V003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonDetail",
                table: "PersonDetail");

            migrationBuilder.DropIndex(
                name: "IX_PersonDetail_PersonId",
                table: "PersonDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contact",
                table: "Contact");

            migrationBuilder.DropIndex(
                name: "IX_Contact_PersonId",
                table: "Contact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BirthCertificate",
                table: "BirthCertificate");

            migrationBuilder.DropIndex(
                name: "IX_BirthCertificate_PersonId",
                table: "BirthCertificate");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PersonDetail");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "BirthCertificate");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonDetail",
                table: "PersonDetail",
                column: "PersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contact",
                table: "Contact",
                column: "PersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BirthCertificate",
                table: "BirthCertificate",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonDetail",
                table: "PersonDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contact",
                table: "Contact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BirthCertificate",
                table: "BirthCertificate");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "PersonDetail",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "Contact",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "BirthCertificate",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonDetail",
                table: "PersonDetail",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contact",
                table: "Contact",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BirthCertificate",
                table: "BirthCertificate",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PersonDetail_PersonId",
                table: "PersonDetail",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contact_PersonId",
                table: "Contact",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BirthCertificate_PersonId",
                table: "BirthCertificate",
                column: "PersonId",
                unique: true);
        }
    }
}
