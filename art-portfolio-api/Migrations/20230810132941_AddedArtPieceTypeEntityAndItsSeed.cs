using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace art_portfolio_api.Migrations
{
    /// <inheritdoc />
    public partial class AddedArtPieceTypeEntityAndItsSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MyProperty",
                table: "ArtPieces",
                newName: "TypeId");

            migrationBuilder.CreateTable(
                name: "ArtPieceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtPieceTypes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ArtPieceTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Dibujo" },
                    { 2, "Boceto" },
                    { 3, "Mural" },
                    { 4, "Pintura" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtPieces_TypeId",
                table: "ArtPieces",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtPieces_ArtPieceTypes_TypeId",
                table: "ArtPieces",
                column: "TypeId",
                principalTable: "ArtPieceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtPieces_ArtPieceTypes_TypeId",
                table: "ArtPieces");

            migrationBuilder.DropTable(
                name: "ArtPieceTypes");

            migrationBuilder.DropIndex(
                name: "IX_ArtPieces_TypeId",
                table: "ArtPieces");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "ArtPieces",
                newName: "MyProperty");
        }
    }
}
