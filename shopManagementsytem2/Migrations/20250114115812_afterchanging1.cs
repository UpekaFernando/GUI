using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shopManagementsytem2.Migrations
{
    /// <inheritdoc />
    public partial class afterchanging1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Shopkeepers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Shopkeepers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
