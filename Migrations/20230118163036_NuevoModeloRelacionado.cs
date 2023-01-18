using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backEnd.Migrations
{
    /// <inheritdoc />
    public partial class NuevoModeloRelacionado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    MovieId = table.Column<Guid>(type: "uuid", nullable: false),
                    Total = table.Column<int>(type: "integer", nullable: false),
                    Left = table.Column<int>(type: "integer", nullable: false),
                    Rented = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.MovieId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Stocks_MovieId",
                table: "Movie",
                column: "MovieId",
                principalTable: "Stocks",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Stocks_MovieId",
                table: "Movie");

            migrationBuilder.DropTable(
                name: "Stocks");
        }
    }
}
