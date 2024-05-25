using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectTimeTracking.Migrations
{
    /// <inheritdoc />
    public partial class AddedMinutesWorked : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MinutesWorked",
                table: "TimeEntries",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MinutesWorked",
                table: "TimeEntries");
        }
    }
}
