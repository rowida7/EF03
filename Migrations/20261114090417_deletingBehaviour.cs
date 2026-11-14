using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_03.Migrations
{
    /// <inheritdoc />
    public partial class deletingBehaviour : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_SuperCategoryId",
                table: "Categories");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_SuperCategoryId",
                table: "Categories",
                column: "SuperCategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_SuperCategoryId",
                table: "Categories");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_SuperCategoryId",
                table: "Categories",
                column: "SuperCategoryId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
