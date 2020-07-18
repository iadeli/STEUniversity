using Microsoft.EntityFrameworkCore.Migrations;

namespace Official.Persistence.EFCore.Migrations
{
    public partial class STE_V015 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "HireStages",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HireTypeId",
                table: "HireStages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "PersonId",
                table: "HireStages",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "TermId",
                table: "HireStages",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_HireStages_PersonId",
                table: "HireStages",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_HireStages_TermId",
                table: "HireStages",
                column: "TermId");

            migrationBuilder.AddForeignKey(
                name: "FK_HireStages_Persons_PersonId",
                table: "HireStages",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HireStages_Terms_TermId",
                table: "HireStages",
                column: "TermId",
                principalTable: "Terms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HireStages_Persons_PersonId",
                table: "HireStages");

            migrationBuilder.DropForeignKey(
                name: "FK_HireStages_Terms_TermId",
                table: "HireStages");

            migrationBuilder.DropIndex(
                name: "IX_HireStages_PersonId",
                table: "HireStages");

            migrationBuilder.DropIndex(
                name: "IX_HireStages_TermId",
                table: "HireStages");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "HireStages");

            migrationBuilder.DropColumn(
                name: "HireTypeId",
                table: "HireStages");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "HireStages");

            migrationBuilder.DropColumn(
                name: "TermId",
                table: "HireStages");
        }
    }
}
