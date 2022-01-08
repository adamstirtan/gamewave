using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalBoss.Database.Migrations
{
    public partial class Extended_Company : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Company",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Company",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Company",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Company",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Company");
        }
    }
}
