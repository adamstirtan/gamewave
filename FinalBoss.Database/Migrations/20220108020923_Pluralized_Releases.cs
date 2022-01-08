using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinalBoss.Database.Migrations
{
    public partial class Pluralized_Releases : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Release_Games_GameId",
                table: "Release");

            migrationBuilder.DropForeignKey(
                name: "FK_Release_Platforms_PlatformId",
                table: "Release");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Release",
                table: "Release");

            migrationBuilder.RenameTable(
                name: "Release",
                newName: "Releases");

            migrationBuilder.RenameIndex(
                name: "IX_Release_PlatformId",
                table: "Releases",
                newName: "IX_Releases_PlatformId");

            migrationBuilder.RenameIndex(
                name: "IX_Release_GameId",
                table: "Releases",
                newName: "IX_Releases_GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Releases",
                table: "Releases",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Releases_Games_GameId",
                table: "Releases",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Releases_Platforms_PlatformId",
                table: "Releases",
                column: "PlatformId",
                principalTable: "Platforms",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Releases_Games_GameId",
                table: "Releases");

            migrationBuilder.DropForeignKey(
                name: "FK_Releases_Platforms_PlatformId",
                table: "Releases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Releases",
                table: "Releases");

            migrationBuilder.RenameTable(
                name: "Releases",
                newName: "Release");

            migrationBuilder.RenameIndex(
                name: "IX_Releases_PlatformId",
                table: "Release",
                newName: "IX_Release_PlatformId");

            migrationBuilder.RenameIndex(
                name: "IX_Releases_GameId",
                table: "Release",
                newName: "IX_Release_GameId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Release",
                table: "Release",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Release_Games_GameId",
                table: "Release",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Release_Platforms_PlatformId",
                table: "Release",
                column: "PlatformId",
                principalTable: "Platforms",
                principalColumn: "Id");
        }
    }
}
