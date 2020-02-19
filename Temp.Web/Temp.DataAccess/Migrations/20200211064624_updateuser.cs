using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Temp.DataAccess.Migrations
{
    public partial class updateuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiredDate",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ExpiredDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Users");
        }
    }
}
