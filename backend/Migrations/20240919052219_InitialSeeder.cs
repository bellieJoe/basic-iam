using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialSeeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "id", "description", "value" },
                values: new object[,]
                {
                    { 1, "Super ADmin", "Super Admin" },
                    { 2, "Admin", "Admin" },
                    { 3, "Ordinary User", "Ordinary" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "id", "created_at", "email", "last_updated_at", "password_hash", "role_id", "username" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 19, 5, 22, 18, 565, DateTimeKind.Utc).AddTicks(9976), "superadmin@email.com", new DateTime(2024, 9, 19, 5, 22, 18, 565, DateTimeKind.Utc).AddTicks(9984), "$2a$11$ZgQq5IiGYsd7.cM5lcTksu85tKgLYaWiZpPUoySHMesXg4y41xxDG", 1, "superadmin" },
                    { 2, new DateTime(2024, 9, 19, 5, 22, 18, 692, DateTimeKind.Utc).AddTicks(4834), "admin@email.com", new DateTime(2024, 9, 19, 5, 22, 18, 692, DateTimeKind.Utc).AddTicks(4844), "$2a$11$eZ5AbfneFnSlo2X85h77muUzzbEe3YvDZ6rv3HcH0z3d6VmZzw5wK", 1, "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "id",
                keyValue: 2);
        }
    }
}
