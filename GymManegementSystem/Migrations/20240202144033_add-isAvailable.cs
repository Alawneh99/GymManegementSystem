using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymManegementSystem.Migrations
{
    /// <inheritdoc />
    public partial class addisAvailable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAvaible",
                table: "Subscriptions",
                type: "tinyint(1)",
                nullable: true,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAvaible",
                table: "Person",
                type: "tinyint(1)",
                nullable: true,
                defaultValue: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAvaible",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "IsAvaible",
                table: "Person");
        }
    }
}
