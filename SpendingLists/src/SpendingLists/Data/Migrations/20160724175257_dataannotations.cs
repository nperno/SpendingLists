using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SpendingLists.Data.Migrations
{
    public partial class dataannotations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Owner",
                table: "SpendingLists",
                nullable: false);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SpendingLists",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ListItems",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Owner",
                table: "SpendingLists",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SpendingLists",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ListItems",
                nullable: true);
        }
    }
}
