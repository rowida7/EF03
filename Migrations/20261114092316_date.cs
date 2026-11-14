using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_03.Migrations
{
    /// <inheritdoc />
    public partial class date : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Instructors",
                newName: "FullName");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "PuplishDate",
                table: "Courses",
                type: "date",
                nullable: false,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Instructors",
                newName: "FillName");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "PuplishDate",
                table: "Courses",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldDefaultValueSql: "GetDate()");
        }
    }
}
