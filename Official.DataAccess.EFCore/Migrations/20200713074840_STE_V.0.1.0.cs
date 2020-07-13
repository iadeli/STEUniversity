using Microsoft.EntityFrameworkCore.Migrations;

namespace Official.Persistence.EFCore.Migrations
{
    public partial class STE_V010 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Menus_Menus_MenuId",
            //    table: "Menus");

            //migrationBuilder.AlterColumn<long>(
            //    name: "MenuId",
            //    table: "Menus",
            //    nullable: false,
            //    oldClrType: typeof(long),
            //    oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "GradeId",
                table: "HistoryEducationals",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "MajorSubjectId",
                table: "HistoryEducationals",
                nullable: false,
                defaultValue: 0L);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Menus_Menus_MenuId",
            //    table: "Menus",
            //    column: "MenuId",
            //    principalTable: "Menus",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Menus_Menus_MenuId",
            //    table: "Menus");

            migrationBuilder.DropColumn(
                name: "GradeId",
                table: "HistoryEducationals");

            migrationBuilder.DropColumn(
                name: "MajorSubjectId",
                table: "HistoryEducationals");

            //migrationBuilder.AlterColumn<long>(
            //    name: "MenuId",
            //    table: "Menus",
            //    nullable: true,
            //    oldClrType: typeof(long));

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Menus_Menus_MenuId",
            //    table: "Menus",
            //    column: "MenuId",
            //    principalTable: "Menus",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Restrict);
        }
    }
}
