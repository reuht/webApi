using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backEnd.Migrations
{
    /// <inheritdoc />
    public partial class CambioEnRelacionMovieStock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Stocks_MovieId",
                table: "Movie");

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Movie_MovieId",
                table: "Stocks",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Movie_MovieId",
                table: "Stocks");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Stocks_MovieId",
                table: "Movie",
                column: "MovieId",
                principalTable: "Stocks",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
