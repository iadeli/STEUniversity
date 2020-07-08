using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Official.Persistence.EFCore.Migrations
{
    public partial class STE_V002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "BirthCertificateNumber",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "BirthCityId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "BirthCountryId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "BirthProvinceId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "EFirstName",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "ELastName",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "EnlistCode",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "EnlistId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "EthnicityId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "FatherName",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "IndigenousSituationId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "IssueCityId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "MarriedId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Mobile",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "NationalityId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "NecessaryContactNumber",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "PostBox",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "PrefixId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "ReligionId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "SubReligionId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "WorkAddress",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "WorkplacePhoneNumber",
                table: "Persons");

            migrationBuilder.CreateTable(
                name: "BirthCertificate",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    EFirstName = table.Column<string>(nullable: true),
                    ELastName = table.Column<string>(nullable: true),
                    FatherName = table.Column<string>(nullable: true),
                    No = table.Column<string>(nullable: true),
                    IssueCityId = table.Column<int>(nullable: true),
                    BirthCountryId = table.Column<int>(nullable: true),
                    BirthProvinceId = table.Column<int>(nullable: true),
                    BirthCityId = table.Column<int>(nullable: true),
                    BirthDate = table.Column<string>(nullable: true),
                    GenderId = table.Column<int>(nullable: false),
                    PrefixId = table.Column<int>(nullable: false),
                    MarriedId = table.Column<int>(nullable: true),
                    PersonId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BirthCertificate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BirthCertificate_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    PostBox = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    WorkplacePhoneNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    WorkAddress = table.Column<string>(nullable: true),
                    NecessaryContactNumber = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    PersonId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contact_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonDetail",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EnlistId = table.Column<int>(nullable: true),
                    EnlistCode = table.Column<string>(nullable: true),
                    ReligionId = table.Column<int>(nullable: true),
                    SubReligionId = table.Column<int>(nullable: true),
                    NationalityId = table.Column<int>(nullable: true),
                    EthnicityId = table.Column<int>(nullable: true),
                    IndigenousSituationId = table.Column<int>(nullable: true),
                    PersonId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonDetail_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BirthCertificate_PersonId",
                table: "BirthCertificate",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contact_PersonId",
                table: "Contact",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonDetail_PersonId",
                table: "PersonDetail",
                column: "PersonId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BirthCertificate");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "PersonDetail");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BirthCertificateNumber",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BirthCityId",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BirthCountryId",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BirthDate",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BirthProvinceId",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EFirstName",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ELastName",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnlistCode",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EnlistId",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EthnicityId",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FatherName",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "Persons",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IndigenousSituationId",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IssueCityId",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MarriedId",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mobile",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NationalityId",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NecessaryContactNumber",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostBox",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PrefixId",
                table: "Persons",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReligionId",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubReligionId",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkAddress",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkplacePhoneNumber",
                table: "Persons",
                nullable: true);
        }
    }
}
