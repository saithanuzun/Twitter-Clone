using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Twitter.Backend.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddDisplayNameToUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "UserProfiles",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MediaUrl",
                table: "Tweets",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "MediaUrl",
                table: "Tweets");
        }
    }
}
