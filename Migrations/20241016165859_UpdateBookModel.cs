using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ghirean_Daria_Lab2.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBookModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Book",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Book",
                newName: "Title");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Book",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Book",
                newName: "Name");
        }
    }
}
