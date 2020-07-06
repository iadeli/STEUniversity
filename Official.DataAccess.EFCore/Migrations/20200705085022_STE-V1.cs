using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Official.Persistence.EFCore.Migrations
{
    public partial class STEV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    BirthCertificateNumber = table.Column<string>(nullable: true),
                    BirthCountry = table.Column<int>(nullable: false),
                    DateOfBirth = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DutySystemCode = table.Column<string>(nullable: true),
                    CityOfBirth = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Ethnicity = table.Column<int>(nullable: false),
                    FatherName = table.Column<string>(nullable: true),
                    Faith = table.Column<int>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    IndigenousSituation = table.Column<int>(nullable: false),
                    LatinName = table.Column<string>(nullable: true),
                    LatinSurname = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    MaritalStatus = table.Column<int>(nullable: false),
                    MilitaryServiceStatus = table.Column<int>(nullable: false),
                    Mobile = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NationalCode = table.Column<string>(nullable: true),
                    Nationality = table.Column<int>(nullable: false),
                    NecessaryContactNumber = table.Column<string>(nullable: true),
                    PlaceOfIssue = table.Column<string>(nullable: true),
                    PostBox = table.Column<int>(nullable: false),
                    PostalCode = table.Column<string>(nullable: true),
                    PrefixName = table.Column<string>(nullable: true),
                    ProvinceOfBirth = table.Column<int>(nullable: false),
                    Religion = table.Column<int>(nullable: false),
                    WorkAddress = table.Column<string>(nullable: true),
                    WorkplacePhoneNumber = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
