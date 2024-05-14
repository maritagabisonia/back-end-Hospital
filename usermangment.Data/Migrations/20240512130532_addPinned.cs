using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace usermangment.Data.Migrations
{
    /// <inheritdoc />
    public partial class addPinned : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.AddColumn<bool>(
                name: "Pinned",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a7d780c-6662-4378-b766-4d32fec28522");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e541eab-bc3a-4496-a078-d7bc7621cf18");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a044d6fe-2ce1-444d-9ed7-7ab5b66a0851");

            migrationBuilder.DropColumn(
                name: "Pinned",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "09c0e464-18e3-4647-b504-64473799f1dc", "2", "User", "User" },
                    { "1d0ea2c2-3933-4192-a402-b27cd7cca379", "3", "Doctor", "Doctor" },
                    { "a9eaf409-f5e3-4c7e-9379-820bf44fded8", "1", "Admin", "Admin" }
                });
        }
    }
}
