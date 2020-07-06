using Microsoft.EntityFrameworkCore.Migrations;

namespace Official.Persistence.EFCore.Migrations
{
    public partial class STEV14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Places_Places_PlaceId",
                table: "Places");

            migrationBuilder.DropIndex(
                name: "IX_Places_PlaceId",
                table: "Places");

            migrationBuilder.AlterColumn<long>(
                name: "PlaceId",
                table: "Places",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "PlaceId",
                table: "Places",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.CreateIndex(
                name: "IX_Places_PlaceId",
                table: "Places",
                column: "PlaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_Places_PlaceId",
                table: "Places",
                column: "PlaceId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
