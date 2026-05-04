using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Community.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitDbUpdatedWithIconUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IconUrl",
                table: "CommunityOptions",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IconUrl",
                table: "CommunityOptions");
        }
    }
}
