using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalBoss.Database.Migrations
{
    public partial class Pluralized_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Company_DeveloperId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Company_PublisherId",
                table: "Games");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Company",
                table: "Company");

            migrationBuilder.RenameTable(
                name: "Company",
                newName: "Companies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Companies_DeveloperId",
                table: "Games",
                column: "DeveloperId",
                principalTable: "Companies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Companies_PublisherId",
                table: "Games",
                column: "PublisherId",
                principalTable: "Companies",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Companies_DeveloperId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Companies_PublisherId",
                table: "Games");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "Company");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Company",
                table: "Company",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Company_DeveloperId",
                table: "Games",
                column: "DeveloperId",
                principalTable: "Company",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Company_PublisherId",
                table: "Games",
                column: "PublisherId",
                principalTable: "Company",
                principalColumn: "Id");
        }
    }
}
