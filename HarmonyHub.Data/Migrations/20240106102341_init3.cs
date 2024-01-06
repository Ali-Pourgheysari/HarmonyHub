using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HarmonyHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CoverStorageId",
                table: "Songs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Songs_CoverStorageId",
                table: "Songs",
                column: "CoverStorageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_StorageFiles_CoverStorageId",
                table: "Songs",
                column: "CoverStorageId",
                principalTable: "StorageFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_StorageFiles_CoverStorageId",
                table: "Songs");

            migrationBuilder.DropIndex(
                name: "IX_Songs_CoverStorageId",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "CoverStorageId",
                table: "Songs");
        }
    }
}
