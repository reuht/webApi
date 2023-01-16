using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backEnd.Migrations
{
    /// <inheritdoc />
    public partial class modelosCambios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "IX_UserMovies_UserId",
                table: "UserMovie",
                newName: "IX_UserMovie_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserMovies_MovieId",
                table: "UserMovie",
                newName: "IX_UserMovie_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieGenders_MovieId",
                table: "MovieGender",
                newName: "IX_MovieGender_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieGenders_GenderId",
                table: "MovieGender",
                newName: "IX_MovieGender_GenderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserMovie",
                table: "UserMovie",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieGender",
                table: "MovieGender",
                column: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieGender",
                table: "MovieGender");

            migrationBuilder.RenameTable(
                name: "UserMovie",
                newName: "UserMovies");

            migrationBuilder.RenameTable(
                name: "MovieGender",
                newName: "MovieGenders");

            migrationBuilder.RenameIndex(
                name: "IX_UserMovie_UserId",
                table: "UserMovies",
                newName: "IX_UserMovies_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserMovie_MovieId",
                table: "UserMovies",
                newName: "IX_UserMovies_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieGender_MovieId",
                table: "MovieGenders",
                newName: "IX_MovieGenders_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_MovieGender_GenderId",
                table: "MovieGenders",
                newName: "IX_MovieGenders_GenderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserMovies",
                table: "UserMovies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieGenders",
                table: "MovieGenders",
                column: "Id");

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
    }
}
