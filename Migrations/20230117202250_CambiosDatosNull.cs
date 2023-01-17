using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backEnd.Migrations
{
    /// <inheritdoc />
    public partial class CambiosDatosNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Booking",
                table: "UserMovies",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataRent",
                table: "UserMovies",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Delivery",
                table: "UserMovies",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Booking",
                table: "UserMovies");

            migrationBuilder.DropColumn(
                name: "DataRent",
                table: "UserMovies");

            migrationBuilder.DropColumn(
                name: "Delivery",
                table: "UserMovies");
        }
    }
}
