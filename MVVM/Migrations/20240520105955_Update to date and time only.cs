using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectTimeTracking.Migrations
{
    /// <inheritdoc />
    public partial class Updatetodateandtimeonly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DateWorked",
                table: "TimeEntries",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateWorked",
                table: "TimeEntries");
        }
    }
}
