using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiataProjectTracker.Migrations
{
    /// <inheritdoc />
    public partial class fixedit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PartsNeeded",
                table: "BuildTasks",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PartsNeeded",
                table: "BuildTasks");
        }
    }
}
