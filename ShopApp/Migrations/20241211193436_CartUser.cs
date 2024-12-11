using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShopApp.Migrations
{
    /// <inheritdoc />
    public partial class CartUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b9bbf9f-edad-44ec-9256-869935acc37d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6a8671e-d19d-4134-824e-3521dc305a80");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Carts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0c386ae2-bccc-408c-967b-7fe62333d9c1", null, "Administrator", "ADMINISTRATOR" },
                    { "a93105f7-2aee-45ec-97d9-a4354514a80b", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId1",
                table: "Carts",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_AspNetUsers_UserId1",
                table: "Carts",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_AspNetUsers_UserId1",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_Carts_UserId1",
                table: "Carts");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0c386ae2-bccc-408c-967b-7fe62333d9c1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a93105f7-2aee-45ec-97d9-a4354514a80b");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Carts");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2b9bbf9f-edad-44ec-9256-869935acc37d", null, "User", "USER" },
                    { "e6a8671e-d19d-4134-824e-3521dc305a80", null, "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
