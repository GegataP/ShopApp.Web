using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShopApp.Migrations
{
    /// <inheritdoc />
    public partial class SliderImgTwo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "05190b63-737c-4ad9-8e94-2f2a50ca2fe0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a99c982f-1f64-405a-9a4b-6d0705fb27ba");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SliderImages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Iamge",
                table: "SliderImages",
                type: "nvarchar(550)",
                maxLength: 550,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "800fb146-88b0-4784-8588-3a3dd8055c67", null, "User", "USER" },
                    { "9a6f28ef-c3c9-427f-9a02-f1a3d62a3899", null, "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "800fb146-88b0-4784-8588-3a3dd8055c67");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9a6f28ef-c3c9-427f-9a02-f1a3d62a3899");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SliderImages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Iamge",
                table: "SliderImages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(550)",
                oldMaxLength: 550,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "05190b63-737c-4ad9-8e94-2f2a50ca2fe0", null, "User", "USER" },
                    { "a99c982f-1f64-405a-9a4b-6d0705fb27ba", null, "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
