using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class SeedRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "dad088ce-ddcd-4117-bb11-0f174ebab3e9", "a4991fb0-215e-4a48-be47-15e12daa036b", "Admin", "ADMIN" },
                    { "8604419d-b486-4004-8064-0b2702695a59", "64feb54c-7d09-4303-91ae-9b2cf5df6921", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8604419d-b486-4004-8064-0b2702695a59");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dad088ce-ddcd-4117-bb11-0f174ebab3e9");
        }
    }
}
