using Microsoft.EntityFrameworkCore.Migrations;

namespace Official.Persistence.EFCore.Migrations
{
    public partial class STE_V004 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BirthCertificate_Persons_PersonId",
                table: "BirthCertificate");

            migrationBuilder.DropForeignKey(
                name: "FK_Contact_Persons_PersonId",
                table: "Contact");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonDetail_Persons_PersonId",
                table: "PersonDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonDetail",
                table: "PersonDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contact",
                table: "Contact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BirthCertificate",
                table: "BirthCertificate");

            migrationBuilder.RenameTable(
                name: "PersonDetail",
                newName: "PersonDetails");

            migrationBuilder.RenameTable(
                name: "Contact",
                newName: "Contacts");

            migrationBuilder.RenameTable(
                name: "BirthCertificate",
                newName: "BirthCertificates");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonDetails",
                table: "PersonDetails",
                column: "PersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts",
                column: "PersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BirthCertificates",
                table: "BirthCertificates",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_BirthCertificates_Persons_PersonId",
                table: "BirthCertificates",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Persons_PersonId",
                table: "Contacts",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonDetails_Persons_PersonId",
                table: "PersonDetails",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BirthCertificates_Persons_PersonId",
                table: "BirthCertificates");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Persons_PersonId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonDetails_Persons_PersonId",
                table: "PersonDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonDetails",
                table: "PersonDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BirthCertificates",
                table: "BirthCertificates");

            migrationBuilder.RenameTable(
                name: "PersonDetails",
                newName: "PersonDetail");

            migrationBuilder.RenameTable(
                name: "Contacts",
                newName: "Contact");

            migrationBuilder.RenameTable(
                name: "BirthCertificates",
                newName: "BirthCertificate");

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

            migrationBuilder.AddForeignKey(
                name: "FK_BirthCertificate_Persons_PersonId",
                table: "BirthCertificate",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_Persons_PersonId",
                table: "Contact",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonDetail_Persons_PersonId",
                table: "PersonDetail",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
