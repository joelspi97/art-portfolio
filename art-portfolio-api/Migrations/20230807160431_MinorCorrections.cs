using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace art_portfolio_api.Migrations
{
    /// <inheritdoc />
    public partial class MinorCorrections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "ArtPieces",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Mediums",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Grafito");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "ArtPieces");

            migrationBuilder.UpdateData(
                table: "Mediums",
                keyColumn: "Id",
                keyValue: 7,
                column: "Name",
                value: "Gráfito");
        }
    }
}
