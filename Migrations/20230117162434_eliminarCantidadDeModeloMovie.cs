using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backEnd.Migrations
{
    /// <inheritdoc />
    public partial class eliminarCantidadDeModeloMovie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "units",
                table: "Movie");

            migrationBuilder.RenameColumn(
                name: "image",
                table: "Movie",
                newName: "Image");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Movie",
                newName: "image");

            migrationBuilder.AddColumn<int>(
                name: "units",
                table: "Movie",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
