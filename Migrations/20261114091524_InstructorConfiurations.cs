using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_03.Migrations
{
    /// <inheritdoc />
    public partial class InstructorConfiurations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "JoiningDate",
                table: "Instructors",
                type: "date",
                nullable: false,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "JoiningDate",
                table: "Instructors",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldDefaultValueSql: "GetDate()");
        }
    }
}
