using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TCC.API.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Users_UserId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Document_Users_UserId",
                table: "Document");

            migrationBuilder.DropForeignKey(
                name: "FK_Driver_Document_DocumentId",
                table: "Driver");

            migrationBuilder.DropForeignKey(
                name: "FK_Driver_Users_UserId",
                table: "Driver");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelEntry_Address_DestinationId",
                table: "TravelEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelEntry_Address_OriginId",
                table: "TravelEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelEntry_Document_DocumentId",
                table: "TravelEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelEntry_Driver_DriverId",
                table: "TravelEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelEntry_Users_UserId",
                table: "TravelEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelEntry_Vehicle_VehicleId",
                table: "TravelEntry");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Document_DocumentId",
                table: "Vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Users_UserId",
                table: "Vehicle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TravelEntry",
                table: "TravelEntry");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Driver",
                table: "Driver");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Document",
                table: "Document");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Address",
                table: "Address");

            migrationBuilder.RenameTable(
                name: "Vehicle",
                newName: "Vehicles");

            migrationBuilder.RenameTable(
                name: "TravelEntry",
                newName: "TravelEntries");

            migrationBuilder.RenameTable(
                name: "Driver",
                newName: "Drivers");

            migrationBuilder.RenameTable(
                name: "Document",
                newName: "Documents");

            migrationBuilder.RenameTable(
                name: "Address",
                newName: "Addresses");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicle_UserId",
                table: "Vehicles",
                newName: "IX_Vehicles_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicle_DocumentId",
                table: "Vehicles",
                newName: "IX_Vehicles_DocumentId");

            migrationBuilder.RenameIndex(
                name: "IX_TravelEntry_VehicleId",
                table: "TravelEntries",
                newName: "IX_TravelEntries_VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_TravelEntry_UserId",
                table: "TravelEntries",
                newName: "IX_TravelEntries_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TravelEntry_OriginId",
                table: "TravelEntries",
                newName: "IX_TravelEntries_OriginId");

            migrationBuilder.RenameIndex(
                name: "IX_TravelEntry_DriverId",
                table: "TravelEntries",
                newName: "IX_TravelEntries_DriverId");

            migrationBuilder.RenameIndex(
                name: "IX_TravelEntry_DocumentId",
                table: "TravelEntries",
                newName: "IX_TravelEntries_DocumentId");

            migrationBuilder.RenameIndex(
                name: "IX_TravelEntry_DestinationId",
                table: "TravelEntries",
                newName: "IX_TravelEntries_DestinationId");

            migrationBuilder.RenameIndex(
                name: "IX_Driver_UserId",
                table: "Drivers",
                newName: "IX_Drivers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Driver_DocumentId",
                table: "Drivers",
                newName: "IX_Drivers_DocumentId");

            migrationBuilder.RenameIndex(
                name: "IX_Document_UserId",
                table: "Documents",
                newName: "IX_Documents_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Address_UserId",
                table: "Addresses",
                newName: "IX_Addresses_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TravelEntries",
                table: "TravelEntries",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Drivers",
                table: "Drivers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Documents",
                table: "Documents",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses",
                column: "Id");

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
                name: "FK_Addresses_Users_UserId",
                table: "Addresses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Users_UserId",
                table: "Documents",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_Documents_DocumentId",
                table: "Drivers",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_Users_UserId",
                table: "Drivers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TravelEntries_Addresses_DestinationId",
                table: "TravelEntries",
                column: "DestinationId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TravelEntries_Addresses_OriginId",
                table: "TravelEntries",
                column: "OriginId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TravelEntries_Documents_DocumentId",
                table: "TravelEntries",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TravelEntries_Drivers_DriverId",
                table: "TravelEntries",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TravelEntries_Users_UserId",
                table: "TravelEntries",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TravelEntries_Vehicles_VehicleId",
                table: "TravelEntries",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Documents_DocumentId",
                table: "Vehicles",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Users_UserId",
                table: "Vehicles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Users_UserId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Users_UserId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_Documents_DocumentId",
                table: "Drivers");

            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_Users_UserId",
                table: "Drivers");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelEntries_Addresses_DestinationId",
                table: "TravelEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelEntries_Addresses_OriginId",
                table: "TravelEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelEntries_Documents_DocumentId",
                table: "TravelEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelEntries_Drivers_DriverId",
                table: "TravelEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelEntries_Users_UserId",
                table: "TravelEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_TravelEntries_Vehicles_VehicleId",
                table: "TravelEntries");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Documents_DocumentId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Users_UserId",
                table: "Vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicles",
                table: "Vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TravelEntries",
                table: "TravelEntries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Drivers",
                table: "Drivers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Documents",
                table: "Documents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Addresses",
                table: "Addresses");

            migrationBuilder.RenameTable(
                name: "Vehicles",
                newName: "Vehicle");

            migrationBuilder.RenameTable(
                name: "TravelEntries",
                newName: "TravelEntry");

            migrationBuilder.RenameTable(
                name: "Drivers",
                newName: "Driver");

            migrationBuilder.RenameTable(
                name: "Documents",
                newName: "Document");

            migrationBuilder.RenameTable(
                name: "Addresses",
                newName: "Address");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_UserId",
                table: "Vehicle",
                newName: "IX_Vehicle_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicles_DocumentId",
                table: "Vehicle",
                newName: "IX_Vehicle_DocumentId");

            migrationBuilder.RenameIndex(
                name: "IX_TravelEntries_VehicleId",
                table: "TravelEntry",
                newName: "IX_TravelEntry_VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_TravelEntries_UserId",
                table: "TravelEntry",
                newName: "IX_TravelEntry_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_TravelEntries_OriginId",
                table: "TravelEntry",
                newName: "IX_TravelEntry_OriginId");

            migrationBuilder.RenameIndex(
                name: "IX_TravelEntries_DriverId",
                table: "TravelEntry",
                newName: "IX_TravelEntry_DriverId");

            migrationBuilder.RenameIndex(
                name: "IX_TravelEntries_DocumentId",
                table: "TravelEntry",
                newName: "IX_TravelEntry_DocumentId");

            migrationBuilder.RenameIndex(
                name: "IX_TravelEntries_DestinationId",
                table: "TravelEntry",
                newName: "IX_TravelEntry_DestinationId");

            migrationBuilder.RenameIndex(
                name: "IX_Drivers_UserId",
                table: "Driver",
                newName: "IX_Driver_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Drivers_DocumentId",
                table: "Driver",
                newName: "IX_Driver_DocumentId");

            migrationBuilder.RenameIndex(
                name: "IX_Documents_UserId",
                table: "Document",
                newName: "IX_Document_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Addresses_UserId",
                table: "Address",
                newName: "IX_Address_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TravelEntry",
                table: "TravelEntry",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Driver",
                table: "Driver",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Document",
                table: "Document",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Address",
                table: "Address",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1ul,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 16, 9, 24, 52, 434, DateTimeKind.Local).AddTicks(3957), new DateTime(2024, 5, 16, 9, 24, 52, 442, DateTimeKind.Local).AddTicks(5990) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 10ul,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 16, 9, 24, 52, 442, DateTimeKind.Local).AddTicks(6739), new DateTime(2024, 5, 16, 9, 24, 52, 442, DateTimeKind.Local).AddTicks(6746) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 20ul,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 16, 9, 24, 52, 442, DateTimeKind.Local).AddTicks(6748), new DateTime(2024, 5, 16, 9, 24, 52, 442, DateTimeKind.Local).AddTicks(6750) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 100ul,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 16, 9, 24, 52, 442, DateTimeKind.Local).AddTicks(6751), new DateTime(2024, 5, 16, 9, 24, 52, 442, DateTimeKind.Local).AddTicks(6752) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1000ul,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 16, 9, 24, 52, 442, DateTimeKind.Local).AddTicks(6754), new DateTime(2024, 5, 16, 9, 24, 52, 442, DateTimeKind.Local).AddTicks(6755) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1001ul,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 16, 9, 24, 52, 442, DateTimeKind.Local).AddTicks(6757), new DateTime(2024, 5, 16, 9, 24, 52, 442, DateTimeKind.Local).AddTicks(6758) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1002ul,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 5, 16, 9, 24, 52, 442, DateTimeKind.Local).AddTicks(6760), new DateTime(2024, 5, 16, 9, 24, 52, 442, DateTimeKind.Local).AddTicks(6761) });

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Users_UserId",
                table: "Address",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Document_Users_UserId",
                table: "Document",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Driver_Document_DocumentId",
                table: "Driver",
                column: "DocumentId",
                principalTable: "Document",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Driver_Users_UserId",
                table: "Driver",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TravelEntry_Address_DestinationId",
                table: "TravelEntry",
                column: "DestinationId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TravelEntry_Address_OriginId",
                table: "TravelEntry",
                column: "OriginId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TravelEntry_Document_DocumentId",
                table: "TravelEntry",
                column: "DocumentId",
                principalTable: "Document",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TravelEntry_Driver_DriverId",
                table: "TravelEntry",
                column: "DriverId",
                principalTable: "Driver",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TravelEntry_Users_UserId",
                table: "TravelEntry",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TravelEntry_Vehicle_VehicleId",
                table: "TravelEntry",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Document_DocumentId",
                table: "Vehicle",
                column: "DocumentId",
                principalTable: "Document",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Users_UserId",
                table: "Vehicle",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
