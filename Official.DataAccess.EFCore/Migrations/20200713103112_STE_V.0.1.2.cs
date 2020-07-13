using Microsoft.EntityFrameworkCore.Migrations;

namespace Official.Persistence.EFCore.Migrations
{
    public partial class STE_V012 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuditEntryProperty_AuditEntries_AuditEntryID",
                table: "AuditEntryProperty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuditEntryProperty",
                table: "AuditEntryProperty");

            migrationBuilder.DropColumn(
                name: "FaPropertyName",
                table: "AuditEntryProperty");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AuditEntryProperty");

            migrationBuilder.RenameTable(
                name: "AuditEntryProperty",
                newName: "AuditEntryProperties");

            migrationBuilder.RenameIndex(
                name: "IX_AuditEntryProperty_AuditEntryID",
                table: "AuditEntryProperties",
                newName: "IX_AuditEntryProperties_AuditEntryID");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "PersonDetails",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuditEntryProperties",
                table: "AuditEntryProperties",
                column: "AuditEntryPropertyID");

            migrationBuilder.AddForeignKey(
                name: "FK_AuditEntryProperties_AuditEntries_AuditEntryID",
                table: "AuditEntryProperties",
                column: "AuditEntryID",
                principalTable: "AuditEntries",
                principalColumn: "AuditEntryID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuditEntryProperties_AuditEntries_AuditEntryID",
                table: "AuditEntryProperties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AuditEntryProperties",
                table: "AuditEntryProperties");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PersonDetails");

            migrationBuilder.RenameTable(
                name: "AuditEntryProperties",
                newName: "AuditEntryProperty");

            migrationBuilder.RenameIndex(
                name: "IX_AuditEntryProperties_AuditEntryID",
                table: "AuditEntryProperty",
                newName: "IX_AuditEntryProperty_AuditEntryID");

            migrationBuilder.AddColumn<string>(
                name: "FaPropertyName",
                table: "AuditEntryProperty",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AuditEntryProperty",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AuditEntryProperty",
                table: "AuditEntryProperty",
                column: "AuditEntryPropertyID");

            migrationBuilder.AddForeignKey(
                name: "FK_AuditEntryProperty_AuditEntries_AuditEntryID",
                table: "AuditEntryProperty",
                column: "AuditEntryID",
                principalTable: "AuditEntries",
                principalColumn: "AuditEntryID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
