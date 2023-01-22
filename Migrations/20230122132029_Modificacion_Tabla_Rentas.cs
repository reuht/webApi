using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backEnd.Migrations
{
    /// <inheritdoc />
    public partial class ModificacionTablaRentas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserMovies",
                table: "UserMovies");

            migrationBuilder.AddColumn<Guid>(
                name: "UserMovieId",
                table: "UserMovies",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<decimal>(
                name: "Fine_value",
                table: "UserMovies",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Rental_value",
                table: "UserMovies",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserMovies",
                table: "UserMovies",
                column: "UserMovieId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMovies_UserId",
                table: "UserMovies",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserMovies",
                table: "UserMovies");

            migrationBuilder.DropIndex(
                name: "IX_UserMovies_UserId",
                table: "UserMovies");

            migrationBuilder.DropColumn(
                name: "UserMovieId",
                table: "UserMovies");

            migrationBuilder.DropColumn(
                name: "Fine_value",
                table: "UserMovies");

            migrationBuilder.DropColumn(
                name: "Rental_value",
                table: "UserMovies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserMovies",
                table: "UserMovies",
                columns: new[] { "UserId", "MovieId" });
        }
    }
}
