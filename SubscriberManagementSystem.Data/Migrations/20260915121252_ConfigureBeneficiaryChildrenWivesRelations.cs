using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SubscriberManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureBeneficiaryChildrenWivesRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, false, "شمال غزة" },
                    { 2, false, "محافظة غزة" },
                    { 3, false, "المحافظة الوسطى" },
                    { 4, false, "محافظة خانيونس" },
                    { 5, false, "محافظة رفح" },
                    { 6, false, "غ ش" }
                });

            migrationBuilder.UpdateData(
                table: "Constants",
                keyColumn: "Id",
                keyValue: 21,
                column: "Name",
                value: "الحالة الإجتماعية");

            migrationBuilder.UpdateData(
                table: "Constants",
                keyColumn: "Id",
                keyValue: 22,
                column: "Name",
                value: "متزوج");

            migrationBuilder.UpdateData(
                table: "Constants",
                keyColumn: "Id",
                keyValue: 23,
                column: "Name",
                value: "أرمل");

            migrationBuilder.UpdateData(
                table: "Constants",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Name", "ParentId" },
                values: new object[] { "منفصل", 21 });

            migrationBuilder.UpdateData(
                table: "Constants",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Name", "ParentId" },
                values: new object[] { "متعدد الزوجات", 21 });

            migrationBuilder.UpdateData(
                table: "Constants",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Name", "ParentId" },
                values: new object[] { "معيل الأسرة", null });

            migrationBuilder.UpdateData(
                table: "Constants",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Name", "ParentId" },
                values: new object[] { "الأب", 27 });

            migrationBuilder.UpdateData(
                table: "Constants",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Name", "ParentId" },
                values: new object[] { "الأم", 27 });

            migrationBuilder.UpdateData(
                table: "Constants",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Name", "ParentId" },
                values: new object[] { "غير ذلك", 27 });

            migrationBuilder.UpdateData(
                table: "Constants",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "Name", "ParentId" },
                values: new object[] { "حالة الزوجة", null });

            migrationBuilder.UpdateData(
                table: "Constants",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "Name", "ParentId" },
                values: new object[] { "لا يوجد", 31 });

            migrationBuilder.UpdateData(
                table: "Constants",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "Name", "ParentId" },
                values: new object[] { "على قيد الحياة", 31 });

            migrationBuilder.UpdateData(
                table: "Constants",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "Name", "ParentId" },
                values: new object[] { "متوفاة", 31 });

            migrationBuilder.UpdateData(
                table: "Constants",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "Name", "ParentId" },
                values: new object[] { "حالة المسكن", null });

            migrationBuilder.UpdateData(
                table: "Constants",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "Name", "ParentId" },
                values: new object[] { "ملك", 35 });

            migrationBuilder.InsertData(
                table: "Constants",
                columns: new[] { "Id", "Comment", "Icon", "Name", "ParentId" },
                values: new object[,]
                {
                    { 37, null, null, "إيجار", 35 },
                    { 38, null, null, "بدون سكن", 35 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Constants",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Constants",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.UpdateData(
                table: "Constants",
                keyColumn: "Id",
                keyValue: 21,
                column: "Name",
                value: "الحالة الاجتماعية");

            migrationBuilder.UpdateData(
                table: "Constants",
                keyColumn: "Id",
                keyValue: 22,
                column: "Name",
                value: "أعزب");

            migrationBuilder.UpdateData(
                table: "Constants",
                keyColumn: "Id",
                keyValue: 23,
                column: "Name",
                value: "متزوج");

            migrationBuilder.UpdateData(
                table: "Constants",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "Name", "ParentId" },
                values: new object[] { "معيل الأسرة", null });

            migrationBuilder.UpdateData(
                table: "Constants",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "Name", "ParentId" },
                values: new object[] { "الأب", 25 });

            migrationBuilder.UpdateData(
                table: "Constants",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "Name", "ParentId" },
                values: new object[] { "الأم", 25 });

            migrationBuilder.UpdateData(
                table: "Constants",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "Name", "ParentId" },
                values: new object[] { "غير ذلك", 25 });

            migrationBuilder.UpdateData(
                table: "Constants",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "Name", "ParentId" },
                values: new object[] { "حالة الزوجة", null });

            migrationBuilder.UpdateData(
                table: "Constants",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "Name", "ParentId" },
                values: new object[] { "لا يوجد", 29 });

            migrationBuilder.UpdateData(
                table: "Constants",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "Name", "ParentId" },
                values: new object[] { "على قيد الحياة", 29 });

            migrationBuilder.UpdateData(
                table: "Constants",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "Name", "ParentId" },
                values: new object[] { "متوفاة", 29 });

            migrationBuilder.UpdateData(
                table: "Constants",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "Name", "ParentId" },
                values: new object[] { "حالة المسكن", null });

            migrationBuilder.UpdateData(
                table: "Constants",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "Name", "ParentId" },
                values: new object[] { "ملك", 33 });

            migrationBuilder.UpdateData(
                table: "Constants",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "Name", "ParentId" },
                values: new object[] { "إيجار", 33 });

            migrationBuilder.UpdateData(
                table: "Constants",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "Name", "ParentId" },
                values: new object[] { "بدون سكن", 33 });
        }
    }
}
