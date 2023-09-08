using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryMIS.Services.BookAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedBookTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CreateAt", "ISBN", "Source", "State", "Title" },
                values: new object[,]
                {
                    { 1, "J. R. R. Tolkien", new DateTime(2023, 9, 16, 16, 12, 2, 537, DateTimeKind.Local).AddTicks(237), "9780007525546", "Amazon", "Available", "The Lord of the Rings" },
                    { 2, "J. R. R. Tolkien", new DateTime(2023, 9, 16, 16, 12, 2, 537, DateTimeKind.Local).AddTicks(273), "9780007525546", "Amazon", "Available", "The Hobbit" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
