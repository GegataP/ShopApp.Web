using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShopApp.Migrations
{
    /// <inheritdoc />
    public partial class UserAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0c386ae2-bccc-408c-967b-7fe62333d9c1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a93105f7-2aee-45ec-97d9-a4354514a80b");

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AddressLine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PinCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_AspNetUsers_UserId1",
                        column: x => x.UserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "e31b55ef-fab0-4876-a9c6-196b17e58c34", null, "Administrator", "ADMINISTRATOR" },
                    { "ed3d7621-3d05-4af6-9194-47ccf39becb4", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserId1",
                table: "Addresses",
                column: "UserId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e31b55ef-fab0-4876-a9c6-196b17e58c34");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ed3d7621-3d05-4af6-9194-47ccf39becb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0c386ae2-bccc-408c-967b-7fe62333d9c1", null, "Administrator", "ADMINISTRATOR" },
                    { "a93105f7-2aee-45ec-97d9-a4354514a80b", null, "User", "USER" }
                });
        }
    }
}
