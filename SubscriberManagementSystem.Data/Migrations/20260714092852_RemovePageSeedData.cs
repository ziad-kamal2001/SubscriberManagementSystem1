using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SubscriberManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovePageSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserTypes",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "IsDeleted", "Name", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2026, 7, 14, 12, 28, 50, 974, DateTimeKind.Local).AddTicks(9160), null, false, "مدير النظام", null, null },
                    { 2, null, new DateTime(2026, 7, 14, 12, 28, 50, 977, DateTimeKind.Local).AddTicks(2463), null, false, "مستخدم", null, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "ConcurrencyStamp", "CreatedBy", "CreatedOn", "DeletedBy", "Email", "EmailConfirmed", "GenderId", "IsActive", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedBy", "UpdatedOn", "UserName", "UserTypeId" },
                values: new object[] { "D3E20CBB-2AD1-4D55-9A1E-4CEEC5B4CDE3", 0, "default_avatar.png", "907faf2b-dcda-4725-bcd0-ffcd17b9a1d5", null, new DateTime(2026, 7, 14, 12, 28, 50, 977, DateTimeKind.Local).AddTicks(3406), null, "admin@fast.com", false, 2, true, false, false, null, "Fast Admin", null, "ADMIN@FAST.COM", "AQAAAAIAAYagAAAAEALPXo0djcdEdnFUCCnSoiw/YG1jql8WNeGoa6QmIaJ7PzjIHc8Pff2UGKH3PnPa/A==", "", false, "aed2478e-3e27-4bbd-93b5-0ceda6342130", false, null, null, "admin@fast.com", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "D3E20CBB-2AD1-4D55-9A1E-4CEEC5B4CDE3");

            migrationBuilder.DeleteData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserTypes",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
