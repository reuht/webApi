using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace backEnd.Migrations
{
    /// <inheritdoc />
    public partial class CambiosModelosMor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieGender_Gender_GenderId",
                table: "MovieGender");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieGender_Movie_MovieId",
                table: "MovieGender");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMovie_Movie_MovieId",
                table: "UserMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMovie_User_UserId",
                table: "UserMovie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserMovie",
                table: "UserMovie");

            migrationBuilder.DropIndex(
                name: "IX_UserMovie_UserId",
                table: "UserMovie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieGender",
                table: "MovieGender");

            migrationBuilder.DropIndex(
                name: "IX_MovieGender_GenderId",
                table: "MovieGender");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserMovie");

            migrationBuilder.DropColumn(
                name: "Booking",
                table: "UserMovie");

            migrationBuilder.DropColumn(
                name: "DataRent",
                table: "UserMovie");

            migrationBuilder.DropColumn(
                name: "Delivery",
                table: "UserMovie");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "MovieGender");

            migrationBuilder.RenameTable(
                name: "UserMovie",
                newName: "UserMovies");

            migrationBuilder.RenameTable(
                name: "MovieGender",
                newName: "MovieGenders");

            migrationBuilder.RenameIndex(
                name: "IX_UserMovie_MovieId",
                table: "UserMovies",
                newName: "IX_UserMovies_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieGender_MovieId",
                table: "MovieGenders",
                newName: "IX_MovieGenders_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserMovies",
                table: "UserMovies",
                columns: new[] { "UserId", "MovieId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieGenders",
                table: "MovieGenders",
                columns: new[] { "GenderId", "MovieId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MovieGenders_Gender_GenderId",
                table: "MovieGenders",
                column: "GenderId",
                principalTable: "Gender",
                principalColumn: "GenderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieGenders_Movie_MovieId",
                table: "MovieGenders",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMovies_Movie_MovieId",
                table: "UserMovies",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMovies_User_UserId",
                table: "UserMovies",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieGenders_Gender_GenderId",
                table: "MovieGenders");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieGenders_Movie_MovieId",
                table: "MovieGenders");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMovies_Movie_MovieId",
                table: "UserMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMovies_User_UserId",
                table: "UserMovies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserMovies",
                table: "UserMovies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieGenders",
                table: "MovieGenders");

            migrationBuilder.RenameTable(
                name: "UserMovies",
                newName: "UserMovie");

            migrationBuilder.RenameTable(
                name: "MovieGenders",
                newName: "MovieGender");

            migrationBuilder.RenameIndex(
                name: "IX_UserMovies_MovieId",
                table: "UserMovie",
                newName: "IX_UserMovie_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieGenders_MovieId",
                table: "MovieGender",
                newName: "IX_MovieGender_MovieId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserMovie",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<DateTime>(
                name: "Booking",
                table: "UserMovie",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataRent",
                table: "UserMovie",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Delivery",
                table: "UserMovie",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "MovieGender",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserMovie",
                table: "UserMovie",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieGender",
                table: "MovieGender",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserMovie_UserId",
                table: "UserMovie",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieGender_GenderId",
                table: "MovieGender",
                column: "GenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieGender_Gender_GenderId",
                table: "MovieGender",
                column: "GenderId",
                principalTable: "Gender",
                principalColumn: "GenderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieGender_Movie_MovieId",
                table: "MovieGender",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMovie_Movie_MovieId",
                table: "UserMovie",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMovie_User_UserId",
                table: "UserMovie",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
