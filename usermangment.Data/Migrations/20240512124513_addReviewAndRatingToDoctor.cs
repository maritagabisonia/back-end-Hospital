using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace usermangment.Data.Migrations
{
    /// <inheritdoc />
    public partial class addReviewAndRatingToDoctor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.AddColumn<string>(
                name: "Rating",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReviewCount",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

          
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09c0e464-18e3-4647-b504-64473799f1dc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d0ea2c2-3933-4192-a402-b27cd7cca379");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a9eaf409-f5e3-4c7e-9379-820bf44fded8");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ReviewCount",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "95a1108c-b7ea-496f-a09c-dcce180865af", "3", "Doctor", "Doctor" },
                    { "ac669b3d-fabb-4ed7-9f34-8feafb623008", "2", "User", "User" },
                    { "ce9189c2-e5ef-482f-b28a-f46bab4df29a", "1", "Admin", "Admin" }
                });
        }
    }
}
