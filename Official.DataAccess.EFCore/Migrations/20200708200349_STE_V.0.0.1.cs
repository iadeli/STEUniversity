using Microsoft.EntityFrameworkCore.Migrations;

namespace Official.Persistence.EFCore.Migrations
{
    public partial class STE_V001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PersonId",
                table: "HistoryEducationals",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_HistoryEducationals_PersonId",
                table: "HistoryEducationals",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoryEducationals_Persons_PersonId",
                table: "HistoryEducationals",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoryEducationals_Persons_PersonId",
                table: "HistoryEducationals");

            migrationBuilder.DropIndex(
                name: "IX_HistoryEducationals_PersonId",
                table: "HistoryEducationals");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "HistoryEducationals");
        }
    }
}
