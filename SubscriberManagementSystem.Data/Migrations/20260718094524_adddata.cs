using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SubscriberManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class adddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "D3E20CBB-2AD1-4D55-9A1E-4CEEC5B4CDE3",
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash", "SecurityStamp" },
                values: new object[] { "338fb747-c69b-4c90-900d-ac8b89ecae44", new DateTime(2026, 7, 18, 12, 45, 23, 170, DateTimeKind.Local).AddTicks(5508), "AQAAAAIAAYagAAAAEEtOSCelJtEaZKjuU/MfW71vsSV1G4+CqAWBuM/ZbDPrgYGrUSI8DeW4uKMD5Gf8DA==", "7d8b29aa-9ca6-4bb2-ba79-3b44f63b1e9d" });

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 18, 12, 45, 23, 168, DateTimeKind.Local).AddTicks(2299));

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 18, 12, 45, 23, 170, DateTimeKind.Local).AddTicks(4731));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "D3E20CBB-2AD1-4D55-9A1E-4CEEC5B4CDE3",
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash", "SecurityStamp" },
                values: new object[] { "907faf2b-dcda-4725-bcd0-ffcd17b9a1d5", new DateTime(2026, 7, 14, 12, 28, 50, 977, DateTimeKind.Local).AddTicks(3406), "AQAAAAIAAYagAAAAEALPXo0djcdEdnFUCCnSoiw/YG1jql8WNeGoa6QmIaJ7PzjIHc8Pff2UGKH3PnPa/A==", "aed2478e-3e27-4bbd-93b5-0ceda6342130" });

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 12, 28, 50, 974, DateTimeKind.Local).AddTicks(9160));

            migrationBuilder.UpdateData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2026, 7, 14, 12, 28, 50, 977, DateTimeKind.Local).AddTicks(2463));
        }
    }
}
