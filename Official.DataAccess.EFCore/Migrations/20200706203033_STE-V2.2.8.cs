using Microsoft.EntityFrameworkCore.Migrations;

namespace Official.Persistence.EFCore.Migrations
{
    public partial class STEV228 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PersonId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "AspNetUsers");
        }
    }
}
