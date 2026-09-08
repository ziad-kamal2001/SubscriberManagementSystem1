using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SubscriberManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCityModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentCity",
                table: "BeneficiaryInformations");

            migrationBuilder.DropColumn(
                name: "OriginalCity",
                table: "BeneficiaryInformations");

            migrationBuilder.AddColumn<int>(
                name: "CurrentCityId",
                table: "BeneficiaryInformations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrentGovernorateCityId",
                table: "BeneficiaryInformations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NearestLandmark",
                table: "BeneficiaryInformations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Neighborhood",
                table: "BeneficiaryInformations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResidenceStatusId",
                table: "BeneficiaryInformations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AlternatePhoneNumber",
                table: "Beneficiaries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BreadwinnerStatusId",
                table: "Beneficiaries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaritalStatusId",
                table: "Beneficiaries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OriginalGovernorateCityId",
                table: "Beneficiaries",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WifeStatusId",
                table: "Beneficiaries",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Constants",
                columns: new[] { "Id", "Comment", "Icon", "Name", "ParentId" },
                values: new object[,]
                {
                    { 21, null, null, "الحالة الاجتماعية", null },
                    { 25, null, null, "معيل الأسرة", null },
                    { 29, null, null, "حالة الزوجة", null },
                    { 33, null, null, "حالة المسكن", null },
                    { 22, null, null, "أعزب", 21 },
                    { 23, null, null, "متزوج", 21 },
                    { 24, null, null, "مطلق", 21 },
                    { 26, null, null, "الأب", 25 },
                    { 27, null, null, "الأم", 25 },
                    { 28, null, null, "غير ذلك", 25 },
                    { 30, null, null, "لا يوجد", 29 },
                    { 31, null, null, "على قيد الحياة", 29 },
                    { 32, null, null, "متوفاة", 29 },
                    { 34, null, null, "ملك", 33 },
                    { 35, null, null, "إيجار", 33 },
                    { 36, null, null, "بدون سكن", 33 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BeneficiaryInformations_CurrentCityId",
                table: "BeneficiaryInformations",
                column: "CurrentCityId");

            migrationBuilder.CreateIndex(
                name: "IX_BeneficiaryInformations_CurrentGovernorateCityId",
                table: "BeneficiaryInformations",
                column: "CurrentGovernorateCityId");

            migrationBuilder.CreateIndex(
                name: "IX_BeneficiaryInformations_ResidenceStatusId",
                table: "BeneficiaryInformations",
                column: "ResidenceStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_BreadwinnerStatusId",
                table: "Beneficiaries",
                column: "BreadwinnerStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_MaritalStatusId",
                table: "Beneficiaries",
                column: "MaritalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_OriginalGovernorateCityId",
                table: "Beneficiaries",
                column: "OriginalGovernorateCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_WifeStatusId",
                table: "Beneficiaries",
                column: "WifeStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Beneficiaries_Cities_OriginalGovernorateCityId",
                table: "Beneficiaries",
                column: "OriginalGovernorateCityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Beneficiaries_Constants_BreadwinnerStatusId",
                table: "Beneficiaries",
                column: "BreadwinnerStatusId",
                principalTable: "Constants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Beneficiaries_Constants_MaritalStatusId",
                table: "Beneficiaries",
                column: "MaritalStatusId",
                principalTable: "Constants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Beneficiaries_Constants_WifeStatusId",
                table: "Beneficiaries",
                column: "WifeStatusId",
                principalTable: "Constants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BeneficiaryInformations_Cities_CurrentCityId",
                table: "BeneficiaryInformations",
                column: "CurrentCityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BeneficiaryInformations_Cities_CurrentGovernorateCityId",
                table: "BeneficiaryInformations",
                column: "CurrentGovernorateCityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BeneficiaryInformations_Constants_ResidenceStatusId",
                table: "BeneficiaryInformations",
                column: "ResidenceStatusId",
                principalTable: "Constants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beneficiaries_Cities_OriginalGovernorateCityId",
                table: "Beneficiaries");

            migrationBuilder.DropForeignKey(
                name: "FK_Beneficiaries_Constants_BreadwinnerStatusId",
                table: "Beneficiaries");

            migrationBuilder.DropForeignKey(
                name: "FK_Beneficiaries_Constants_MaritalStatusId",
                table: "Beneficiaries");

            migrationBuilder.DropForeignKey(
                name: "FK_Beneficiaries_Constants_WifeStatusId",
                table: "Beneficiaries");

            migrationBuilder.DropForeignKey(
                name: "FK_BeneficiaryInformations_Cities_CurrentCityId",
                table: "BeneficiaryInformations");

            migrationBuilder.DropForeignKey(
                name: "FK_BeneficiaryInformations_Cities_CurrentGovernorateCityId",
                table: "BeneficiaryInformations");

            migrationBuilder.DropForeignKey(
                name: "FK_BeneficiaryInformations_Constants_ResidenceStatusId",
                table: "BeneficiaryInformations");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_BeneficiaryInformations_CurrentCityId",
                table: "BeneficiaryInformations");

            migrationBuilder.DropIndex(
                name: "IX_BeneficiaryInformations_CurrentGovernorateCityId",
                table: "BeneficiaryInformations");

            migrationBuilder.DropIndex(
                name: "IX_BeneficiaryInformations_ResidenceStatusId",
                table: "BeneficiaryInformations");

            migrationBuilder.DropIndex(
                name: "IX_Beneficiaries_BreadwinnerStatusId",
                table: "Beneficiaries");

            migrationBuilder.DropIndex(
                name: "IX_Beneficiaries_MaritalStatusId",
                table: "Beneficiaries");

            migrationBuilder.DropIndex(
                name: "IX_Beneficiaries_OriginalGovernorateCityId",
                table: "Beneficiaries");

            migrationBuilder.DropIndex(
                name: "IX_Beneficiaries_WifeStatusId",
                table: "Beneficiaries");

            migrationBuilder.DeleteData(
                table: "Constants",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Constants",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Constants",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Constants",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Constants",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Constants",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Constants",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Constants",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Constants",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Constants",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Constants",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Constants",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Constants",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Constants",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Constants",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Constants",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DropColumn(
                name: "CurrentCityId",
                table: "BeneficiaryInformations");

            migrationBuilder.DropColumn(
                name: "CurrentGovernorateCityId",
                table: "BeneficiaryInformations");

            migrationBuilder.DropColumn(
                name: "NearestLandmark",
                table: "BeneficiaryInformations");

            migrationBuilder.DropColumn(
                name: "Neighborhood",
                table: "BeneficiaryInformations");

            migrationBuilder.DropColumn(
                name: "ResidenceStatusId",
                table: "BeneficiaryInformations");

            migrationBuilder.DropColumn(
                name: "AlternatePhoneNumber",
                table: "Beneficiaries");

            migrationBuilder.DropColumn(
                name: "BreadwinnerStatusId",
                table: "Beneficiaries");

            migrationBuilder.DropColumn(
                name: "MaritalStatusId",
                table: "Beneficiaries");

            migrationBuilder.DropColumn(
                name: "OriginalGovernorateCityId",
                table: "Beneficiaries");

            migrationBuilder.DropColumn(
                name: "WifeStatusId",
                table: "Beneficiaries");

            migrationBuilder.AddColumn<string>(
                name: "CurrentCity",
                table: "BeneficiaryInformations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OriginalCity",
                table: "BeneficiaryInformations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
