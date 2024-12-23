using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShopApp.Migrations
{
    /// <inheritdoc />
    public partial class Slider : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "800fb146-88b0-4784-8588-3a3dd8055c67");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a6f28ef-c3c9-427f-9a02-f1a3d62a3899");

            migrationBuilder.RenameColumn(
                name: "Iamge",
                table: "SliderImages",
                newName: "Image");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "114c507a-c1a4-408a-8bcb-b94727b0c112", null, "User", "USER" },
                    { "bbfd32a7-935b-4d60-9718-127cff268cb5", null, "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "114c507a-c1a4-408a-8bcb-b94727b0c112");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bbfd32a7-935b-4d60-9718-127cff268cb5");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "SliderImages",
                newName: "Iamge");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "800fb146-88b0-4784-8588-3a3dd8055c67", null, "User", "USER" },
                    { "9a6f28ef-c3c9-427f-9a02-f1a3d62a3899", null, "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
