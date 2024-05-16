using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TCC.API.Migrations
{
    /// <inheritdoc />
    public partial class SettingsNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Settings_SettingsId",
                table: "Users");

            migrationBuilder.AlterColumn<ulong>(
                name: "SettingsId",
                table: "Users",
                type: "bigint unsigned",
                nullable: true,
                oldClrType: typeof(ulong),
                oldType: "bigint unsigned");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Settings_SettingsId",
                table: "Users",
                column: "SettingsId",
                principalTable: "Settings",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Settings_SettingsId",
                table: "Users");

            migrationBuilder.AlterColumn<ulong>(
                name: "SettingsId",
                table: "Users",
                type: "bigint unsigned",
                nullable: false,
                defaultValue: 0ul,
                oldClrType: typeof(ulong),
                oldType: "bigint unsigned",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1ul,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 16, 9, 33, 50, 622, DateTimeKind.Local).AddTicks(4293), new DateTime(2024, 5, 16, 9, 33, 50, 629, DateTimeKind.Local).AddTicks(9733) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10ul,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 16, 9, 33, 50, 630, DateTimeKind.Local).AddTicks(715), new DateTime(2024, 5, 16, 9, 33, 50, 630, DateTimeKind.Local).AddTicks(724) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20ul,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 16, 9, 33, 50, 630, DateTimeKind.Local).AddTicks(727), new DateTime(2024, 5, 16, 9, 33, 50, 630, DateTimeKind.Local).AddTicks(728) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 100ul,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 16, 9, 33, 50, 630, DateTimeKind.Local).AddTicks(731), new DateTime(2024, 5, 16, 9, 33, 50, 630, DateTimeKind.Local).AddTicks(732) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1000ul,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 16, 9, 33, 50, 630, DateTimeKind.Local).AddTicks(735), new DateTime(2024, 5, 16, 9, 33, 50, 630, DateTimeKind.Local).AddTicks(736) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1001ul,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 16, 9, 33, 50, 630, DateTimeKind.Local).AddTicks(738), new DateTime(2024, 5, 16, 9, 33, 50, 630, DateTimeKind.Local).AddTicks(740) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1002ul,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 16, 9, 33, 50, 630, DateTimeKind.Local).AddTicks(742), new DateTime(2024, 5, 16, 9, 33, 50, 630, DateTimeKind.Local).AddTicks(743) });

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Settings_SettingsId",
                table: "Users",
                column: "SettingsId",
                principalTable: "Settings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
