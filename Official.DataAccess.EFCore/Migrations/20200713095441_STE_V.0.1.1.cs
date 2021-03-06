﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Official.Persistence.EFCore.Migrations
{
    public partial class STE_V011 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EnPropertyName",
                table: "AuditEntryProperty",
                newName: "FaPropertyName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FaPropertyName",
                table: "AuditEntryProperty",
                newName: "EnPropertyName");
        }
    }
}
