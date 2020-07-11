using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Official.Persistence.EFCore.Migrations
{
    public partial class STE_V007 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "AttachFile",
                table: "DegreeAttaches",
                nullable: true,
                oldClrType: typeof(byte));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "AttachFile",
                table: "DegreeAttaches",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldNullable: true);
        }
    }
}
