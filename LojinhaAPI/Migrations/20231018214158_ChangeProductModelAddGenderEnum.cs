using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LojinhaAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangeProductModelAddGenderEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "productGender",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "productGender",
                table: "Products");
        }
    }
}
