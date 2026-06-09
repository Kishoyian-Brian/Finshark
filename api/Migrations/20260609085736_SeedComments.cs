using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class SeedComments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Title", "Content", "CreatedAt", "StockId" },
                values: new object[,]
                {
                    { 1, "Strong earnings", "Apple reported record Q2 earnings driven by services growth.", new DateTime(2026, 5, 1, 10, 0, 0, DateTimeKind.Utc), 1 },
                    { 2, "iPhone demand", "Analysts expect steady iPhone demand ahead of the next product cycle.", new DateTime(2026, 5, 10, 14, 30, 0, DateTimeKind.Utc), 1 },
                    { 3, "Cloud growth", "Azure revenue continues to grow as enterprise adoption accelerates.", new DateTime(2026, 5, 3, 9, 15, 0, DateTimeKind.Utc), 2 },
                    { 4, "Production update", "Tesla's new factory is ramping production faster than expected.", new DateTime(2026, 5, 7, 16, 45, 0, DateTimeKind.Utc), 3 },
                    { 5, "Dividend increase", "Coca-Cola raised its dividend for the 61st consecutive year.", new DateTime(2026, 5, 12, 11, 0, 0, DateTimeKind.Utc), 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
