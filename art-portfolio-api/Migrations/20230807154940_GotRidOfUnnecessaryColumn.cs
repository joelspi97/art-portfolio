using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace art_portfolio_api.Migrations
{
    /// <inheritdoc />
    public partial class GotRidOfUnnecessaryColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mediums_ArtPieces_ArtPieceId",
                table: "Mediums");

            migrationBuilder.DropIndex(
                name: "IX_Mediums_ArtPieceId",
                table: "Mediums");

            migrationBuilder.DropColumn(
                name: "ArtPieceId",
                table: "Mediums");

            migrationBuilder.CreateTable(
                name: "ArtPieceMedium",
                columns: table => new
                {
                    ArtPieceId = table.Column<int>(type: "int", nullable: false),
                    MediumsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtPieceMedium", x => new { x.ArtPieceId, x.MediumsId });
                    table.ForeignKey(
                        name: "FK_ArtPieceMedium_ArtPieces_ArtPieceId",
                        column: x => x.ArtPieceId,
                        principalTable: "ArtPieces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtPieceMedium_Mediums_MediumsId",
                        column: x => x.MediumsId,
                        principalTable: "Mediums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtPieceMedium_MediumsId",
                table: "ArtPieceMedium",
                column: "MediumsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtPieceMedium");

            migrationBuilder.AddColumn<int>(
                name: "ArtPieceId",
                table: "Mediums",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Mediums",
                keyColumn: "Id",
                keyValue: 1,
                column: "ArtPieceId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Mediums",
                keyColumn: "Id",
                keyValue: 2,
                column: "ArtPieceId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Mediums",
                keyColumn: "Id",
                keyValue: 3,
                column: "ArtPieceId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Mediums",
                keyColumn: "Id",
                keyValue: 4,
                column: "ArtPieceId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Mediums",
                keyColumn: "Id",
                keyValue: 5,
                column: "ArtPieceId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Mediums",
                keyColumn: "Id",
                keyValue: 6,
                column: "ArtPieceId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Mediums",
                keyColumn: "Id",
                keyValue: 7,
                column: "ArtPieceId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Mediums_ArtPieceId",
                table: "Mediums",
                column: "ArtPieceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mediums_ArtPieces_ArtPieceId",
                table: "Mediums",
                column: "ArtPieceId",
                principalTable: "ArtPieces",
                principalColumn: "Id");
        }
    }
}
