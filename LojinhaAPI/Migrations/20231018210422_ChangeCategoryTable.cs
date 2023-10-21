using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LojinhaAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCategoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ControlId",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ControlId",
                table: "Categories");
        }
    }
}
