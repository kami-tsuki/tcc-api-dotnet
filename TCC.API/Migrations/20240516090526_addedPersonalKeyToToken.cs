using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TCC.API.Migrations
{
    /// <inheritdoc />
    public partial class addedPersonalKeyToToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PersonalKey",
                table: "Users",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1ul,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 16, 11, 5, 24, 844, DateTimeKind.Local).AddTicks(1190), new DateTime(2024, 5, 16, 11, 5, 24, 853, DateTimeKind.Local).AddTicks(2497) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10ul,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 16, 11, 5, 24, 853, DateTimeKind.Local).AddTicks(3355), new DateTime(2024, 5, 16, 11, 5, 24, 853, DateTimeKind.Local).AddTicks(3362) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20ul,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 16, 11, 5, 24, 853, DateTimeKind.Local).AddTicks(3365), new DateTime(2024, 5, 16, 11, 5, 24, 853, DateTimeKind.Local).AddTicks(3366) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 100ul,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 16, 11, 5, 24, 853, DateTimeKind.Local).AddTicks(3369), new DateTime(2024, 5, 16, 11, 5, 24, 853, DateTimeKind.Local).AddTicks(3370) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1000ul,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 16, 11, 5, 24, 853, DateTimeKind.Local).AddTicks(3372), new DateTime(2024, 5, 16, 11, 5, 24, 853, DateTimeKind.Local).AddTicks(3373) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1001ul,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 16, 11, 5, 24, 853, DateTimeKind.Local).AddTicks(3375), new DateTime(2024, 5, 16, 11, 5, 24, 853, DateTimeKind.Local).AddTicks(3376) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1002ul,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 16, 11, 5, 24, 853, DateTimeKind.Local).AddTicks(3378), new DateTime(2024, 5, 16, 11, 5, 24, 853, DateTimeKind.Local).AddTicks(3379) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonalKey",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1ul,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 16, 9, 41, 24, 547, DateTimeKind.Local).AddTicks(6650), new DateTime(2024, 5, 16, 9, 41, 24, 555, DateTimeKind.Local).AddTicks(6888) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10ul,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 16, 9, 41, 24, 555, DateTimeKind.Local).AddTicks(7985), new DateTime(2024, 5, 16, 9, 41, 24, 555, DateTimeKind.Local).AddTicks(7993) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20ul,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 16, 9, 41, 24, 555, DateTimeKind.Local).AddTicks(7995), new DateTime(2024, 5, 16, 9, 41, 24, 555, DateTimeKind.Local).AddTicks(7996) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 100ul,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 16, 9, 41, 24, 555, DateTimeKind.Local).AddTicks(7998), new DateTime(2024, 5, 16, 9, 41, 24, 555, DateTimeKind.Local).AddTicks(7999) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1000ul,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 16, 9, 41, 24, 555, DateTimeKind.Local).AddTicks(8001), new DateTime(2024, 5, 16, 9, 41, 24, 555, DateTimeKind.Local).AddTicks(8002) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1001ul,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 16, 9, 41, 24, 555, DateTimeKind.Local).AddTicks(8004), new DateTime(2024, 5, 16, 9, 41, 24, 555, DateTimeKind.Local).AddTicks(8005) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1002ul,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 16, 9, 41, 24, 555, DateTimeKind.Local).AddTicks(8006), new DateTime(2024, 5, 16, 9, 41, 24, 555, DateTimeKind.Local).AddTicks(8008) });
        }
    }
}
