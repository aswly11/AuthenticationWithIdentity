using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuthenticationWithIdentity.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePageActionModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PageActions_Pages_PageId",
                table: "PageActions");

            migrationBuilder.AlterColumn<int>(
                name: "PageId",
                table: "PageActions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PageActions_Pages_PageId",
                table: "PageActions",
                column: "PageId",
                principalTable: "Pages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PageActions_Pages_PageId",
                table: "PageActions");

            migrationBuilder.AlterColumn<int>(
                name: "PageId",
                table: "PageActions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PageActions_Pages_PageId",
                table: "PageActions",
                column: "PageId",
                principalTable: "Pages",
                principalColumn: "Id");
        }
    }
}
