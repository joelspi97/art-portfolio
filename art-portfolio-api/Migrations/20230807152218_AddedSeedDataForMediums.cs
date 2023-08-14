using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace art_portfolio_api.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeedDataForMediums : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Mediums",
                columns: new[] { "Id", "ArtPieceId", "Name" },
                values: new object[,]
                {
                    { 1, null, "Óleo" },
                    { 2, null, "Témpera" },
                    { 3, null, "Acuarela" },
                    { 4, null, "Acrílico" },
                    { 5, null, "Pastel Graso" },
                    { 6, null, "Pastel Tiza" },
                    { 7, null, "Gráfito" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Mediums",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Mediums",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Mediums",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Mediums",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Mediums",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Mediums",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Mediums",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
