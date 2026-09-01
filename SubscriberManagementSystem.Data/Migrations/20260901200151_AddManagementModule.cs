
using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SubscriberManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddManagementModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accommodations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accommodations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Constants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Constants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Constants_Constants_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Constants",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HousingStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HousingStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PageCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TheHealthConditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheHealthConditions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypesSubscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesSubscriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Beneficiaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    SName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    TName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    LName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BeneficiaryTypeId = table.Column<int>(type: "int", nullable: true),
                    IsReceivingMessages = table.Column<bool>(type: "bit", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beneficiaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Beneficiaries_Beneficiaries_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Beneficiaries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Beneficiaries_Constants_BeneficiaryTypeId",
                        column: x => x.BeneficiaryTypeId,
                        principalTable: "Constants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Beneficiaries_Constants_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Constants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InMenu = table.Column<bool>(type: "bit", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsAjax = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModuleId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pages_Modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Modules",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pages_PageCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "PageCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pages_Pages_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Pages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    UserTypeId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Constants_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Constants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_UserTypes_UserTypeId",
                        column: x => x.UserTypeId,
                        principalTable: "UserTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BeneficiaryInformations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BeneficiaryId = table.Column<int>(type: "int", nullable: false),
                    NumberofIndividuals = table.Column<int>(type: "int", nullable: false),
                    OriginalCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Camp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalAid = table.Column<int>(type: "int", nullable: false),
                    HousingStatusId = table.Column<int>(type: "int", nullable: false),
                    WorkStatusId = table.Column<int>(type: "int", nullable: false),
                    TheHealthConditionId = table.Column<int>(type: "int", nullable: false),
                    AccommodationId = table.Column<int>(type: "int", nullable: false),
                    IsDefaultAddress = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BeneficiaryInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BeneficiaryInformations_Accommodations_AccommodationId",
                        column: x => x.AccommodationId,
                        principalTable: "Accommodations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeneficiaryInformations_Beneficiaries_BeneficiaryId",
                        column: x => x.BeneficiaryId,
                        principalTable: "Beneficiaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeneficiaryInformations_HousingStatus_HousingStatusId",
                        column: x => x.HousingStatusId,
                        principalTable: "HousingStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeneficiaryInformations_TheHealthConditions_TheHealthConditionId",
                        column: x => x.TheHealthConditionId,
                        principalTable: "TheHealthConditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BeneficiaryInformations_WorkStatus_WorkStatusId",
                        column: x => x.WorkStatusId,
                        principalTable: "WorkStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BeneficiaryId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wives_Beneficiaries_BeneficiaryId",
                        column: x => x.BeneficiaryId,
                        principalTable: "Beneficiaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPermissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserTypeId = table.Column<int>(type: "int", nullable: false),
                    PageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPermissions_Pages_PageId",
                        column: x => x.PageId,
                        principalTable: "Pages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPermissions_UserTypes_UserTypeId",
                        column: x => x.UserTypeId,
                        principalTable: "UserTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Childrens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false),
                    WiveId = table.Column<int>(type: "int", maxLength: 250, nullable: true),
                    TheHealthConditionId = table.Column<int>(type: "int", nullable: false),
                    BeneficiaryId = table.Column<int>(type: "int", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Childrens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Childrens_Beneficiaries_BeneficiaryId",
                        column: x => x.BeneficiaryId,
                        principalTable: "Beneficiaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Childrens_Beneficiaries_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Beneficiaries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Childrens_Constants_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Constants",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Childrens_TheHealthConditions_TheHealthConditionId",
                        column: x => x.TheHealthConditionId,
                        principalTable: "TheHealthConditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Childrens_Wives_WiveId",
                        column: x => x.WiveId,
                        principalTable: "Wives",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Constants",
                columns: new[] { "Id", "Comment", "Icon", "Name", "ParentId" },
                values: new object[,]
                {
                    { 1, null, null, "الجنس", null },
                    { 4, null, null, "حالة السكن", null },
                    { 8, null, null, "حالة العمل", null },
                    { 11, null, null, "الحالة الصحية", null },
                    { 14, null, null, " الاقامة مكان", null },
                    { 17, null, null, "نوع المستفيد", null }
                });

            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "Name", "Status" },
                values: new object[,]
                {
                    { 1, "الادارة", true },
                    { 2, "إدارة العملاء", true },
                    { 3, "إدارة الخدمات", true },
                    { 4, "المالية", true }
                });

            migrationBuilder.InsertData(
                table: "PageCategories",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, false, "Header" },
                    { 2, false, "Page" },
                    { 3, false, "Tool" }
                });

            migrationBuilder.InsertData(
                table: "UserTypes",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "IsDeleted", "Name", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "مدير النظام", null, null },
                    { 2, null, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "مستخدم", null, null }
                });

            migrationBuilder.InsertData(
                table: "Constants",
                columns: new[] { "Id", "Comment", "Icon", "Name", "ParentId" },
                values: new object[,]
                {
                    { 2, null, null, "ذكر", 1 },
                    { 3, null, null, "أنثى", 1 },
                    { 5, null, null, "تدمير كلي", 4 },
                    { 6, null, null, "تدمير جزئي", 4 },
                    { 7, null, null, "سليم", 4 },
                    { 9, null, null, "لا يعمل", 8 },
                    { 10, null, null, "يعمل", 8 },
                    { 12, null, null, "سليم", 11 },
                    { 13, null, null, "مصاب", 11 },
                    { 15, null, null, "داخلي", 14 },
                    { 16, null, null, "خارجي", 14 },
                    { 18, null, null, "زبون", 17 },
                    { 19, null, null, "مورد", 17 },
                    { 20, null, null, "مزود خدمة", 17 }
                });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "Id", "CategoryId", "Icon", "InMenu", "IsActive", "IsAjax", "IsDeleted", "Link", "ModuleId", "Name", "NameEn", "ParentId" },
                values: new object[] { 1, 1, null, false, false, false, false, null, null, "الاب", "Parent Page", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "ConcurrencyStamp", "CreatedBy", "CreatedOn", "DeletedBy", "Email", "EmailConfirmed", "GenderId", "IsActive", "IsDeleted", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedBy", "UpdatedOn", "UserName", "UserTypeId" },
                values: new object[] { "D3E20CBB-2AD1-4D55-9A1E-4CEEC5B4CDE3", 0, "default_avatar.png", "00000000-0000-0000-0000-000000000001", null, new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@fast.com", false, 2, true, false, false, null, "Fast Admin", null, "ADMIN@FAST.COM", "AQAAAAIAAYagAAAAEALPXo0djcdEdnFUCCnSoiw/YG1jql8WNeGoa6QmIaJ7PzjIHc8Pff2UGKH3PnPa/A==", "", false, "00000000-0000-0000-0000-000000000002", false, null, null, "admin@fast.com", 1 });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "Id", "CategoryId", "Icon", "InMenu", "IsActive", "IsAjax", "IsDeleted", "Link", "ModuleId", "Name", "NameEn", "ParentId" },
                values: new object[,]
                {
                    { 2, 2, "bi bi-house-fill", true, true, false, false, "Home/Index", null, "الرئيسية", "Home", 1 },
                    { 3, 1, "bi bi-list-ul", true, true, false, false, null, 1, "الإدارة", "Management", 1 },
                    { 12, 1, "bi bi-people", true, true, false, false, null, 2, "إدارة العملاء", "Beneficiaries Management", 1 },
                    { 16, 1, "bi bi-stickies-fill", true, true, false, false, null, 3, "إدارة الخدمات", "Services Management", 1 }
                });

            migrationBuilder.InsertData(
                table: "UserPermissions",
                columns: new[] { "Id", "PageId", "UserTypeId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "Id", "CategoryId", "Icon", "InMenu", "IsActive", "IsAjax", "IsDeleted", "Link", "ModuleId", "Name", "NameEn", "ParentId" },
                values: new object[,]
                {
                    { 4, 1, "bi bi-people", true, true, false, false, null, 1, "إدارة المستخدمين", "Users Management", 3 },
                    { 9, 2, "bi bi-view-list", true, true, false, false, "Management/Modules", 1, "وحدات النظام", "Governorates and Cities", 3 },
                    { 10, 2, "bi bi-window-stack", true, true, false, false, "Page/Index", 1, "الصفحات", "Pages", 3 },
                    { 11, 2, "fa fa-anchor", true, true, false, false, "Constant/Index", 1, "الثوابت", "Constants", 3 },
                    { 13, 2, "bi bi-people-fill", true, true, false, false, "Beneficiary/Index", 2, "المستفيدين", "Beneficiaries", 12 },
                    { 14, 2, "bi bi-people-fill", true, true, false, false, "Beneficiary/BeneficiaryTypes", 2, "أنواع المستفيدين", "Beneficiaries Types", 12 },
                    { 15, 2, "bi bi-bookmarks", true, true, false, false, "AttachmentType/Index", 2, "أنواع المرفقات", "Attachments Types", 12 },
                    { 17, 2, "bi bi-sticky-fill", true, true, false, false, "Service/Index", 3, "الخدمات", "Services", 16 },
                    { 18, 2, "bi bi-stickies-fill", true, true, false, false, "Service/ServiceGroups", 3, "مجموعات الخدمات", "Services Groups", 16 },
                    { 19, 2, "bi bi-person-check", true, true, false, false, "Representative/Index", 3, "المندوبين", "Representatives", 16 },
                    { 20, 2, "bi bi-person-check", true, true, false, false, "RepresentativeCategory/Index", 3, "فئات المندوب", "Representative Categories", 16 },
                    { 21, 2, "bi bi-person-check", true, true, false, false, "ResponsibleAgency/Index", 3, " الجهات ", "Responsible Agencies", 16 },
                    { 22, 2, "bi bi-person-check", true, true, false, false, "ResponsibleAgency/AgencyTypes", 3, " أنواع الجهات  ", "Responsible Agencies Types", 16 },
                    { 23, 2, "bi bi-person-check", true, true, false, false, "RequestCase/Index", 3, " حالات الطلب ", "Request Cases", 16 },
                    { 58, 3, null, false, true, true, false, "Beneficiary/DeleteContact", 1, "حذف جهات اتصال المستفيد", "Delete beneficiary Addresses", 2 }
                });

            migrationBuilder.InsertData(
                table: "UserPermissions",
                columns: new[] { "Id", "PageId", "UserTypeId" },
                values: new object[,]
                {
                    { 2, 2, 1 },
                    { 3, 3, 1 },
                    { 11, 12, 1 },
                    { 15, 16, 1 }
                });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "Id", "CategoryId", "Icon", "InMenu", "IsActive", "IsAjax", "IsDeleted", "Link", "ModuleId", "Name", "NameEn", "ParentId" },
                values: new object[,]
                {
                    { 5, 2, "bi bi-person-fill", true, true, false, false, "User/Index", 1, "المستخدمين", "Users", 4 },
                    { 6, 2, "bi bi-people", true, true, false, false, "UserType/Index", 1, "أنواع المستخدمين", "User Types", 4 },
                    { 7, 2, "bi bi-check-lg", true, true, false, false, "UserPermission/Index", 1, "صلاحيات المستخدم", "User Permissions", 4 },
                    { 38, 3, null, false, true, true, false, "Management/SwitchStatus", 1, "تبديل حالات وحدات النظام", "Switching states of system Modules", 9 },
                    { 39, 3, null, false, true, true, false, "Page/GetAll", 1, "عرض بيانات جدول الصفحات", "Display Pages DataTable", 10 },
                    { 40, 3, null, false, true, true, false, "Page/CreateEditModal", 1, "عرض واجهة إضافة  تعديل صفحة", "Display Create Edit Page interface", 10 },
                    { 41, 3, null, false, true, true, false, "Page/CreateEdit", 1, "إضافة تعديل صفحة", "Create Edit Page", 10 },
                    { 42, 3, null, false, true, true, false, "Page/Delete", 1, "حذف صفحة", "Delete Page", 10 },
                    { 43, 3, null, false, true, true, false, "Constant/GetAll", 1, "عرض بيانات جدول الثوابت", "Display Constant DataTable", 11 },
                    { 44, 3, null, false, true, true, false, "Constant/CreateEditModal", 1, "عرض واجهة إضافة تعديل ثوابت", "Display Create Edit Constant Page", 11 },
                    { 45, 3, null, false, true, true, false, "Constant/CreateEdit", 1, "إضافة تعديل ثوابت", "Create Edit Constant", 11 },
                    { 46, 3, null, false, true, true, false, "Constant/Delete", 1, "حذف ثابت", "Delete Constant", 11 },
                    { 47, 3, null, false, true, true, false, "Beneficiary/GetAll", 2, "عرض بيانات جدول المستفيدين", "Display Beneficiaries DataTable", 13 },
                    { 48, 3, null, false, true, true, false, "Beneficiary/CreateEdit", 2, "عرض واجهة إضافة تعديل المستفيدين", "Display Create Edit Beneficiaries Page", 13 },
                    { 49, 3, null, false, true, true, false, "Beneficiary/SubmitCreateEdit", 2, "ضافة تعديل المستفيدين", "Create Edit Beneficiaries", 13 },
                    { 50, 3, null, false, true, true, false, "Beneficiary/Delete", 2, "حذف مستفيد", "Delete Beneficiary", 13 },
                    { 51, 3, null, false, true, true, false, "Beneficiary/GetAddresses", 2, "عرض بيانات جدول عناوين المستفيد", "Display beneficiary Addresses DataTable", 13 },
                    { 52, 3, null, false, true, true, false, "Beneficiary/CreateEditAddressModal", 2, "عرض واجهة إضافة تعديل عناوين المستفيد", "Display Create Edit beneficiary Addresses Page", 13 },
                    { 53, 3, null, false, true, true, false, "Beneficiary/CreateEditAddress", 2, "إضافة تعديل عناوين المستفيد", "Create Edit beneficiary Addresses", 13 },
                    { 54, 3, null, false, true, true, false, "Beneficiary/DeleteAddress", 2, "حذف عناوين المستفيد", "Delete beneficiary Addresses", 13 },
                    { 55, 3, null, false, true, true, false, "Beneficiary/GetContacts", 2, "عرض بيانات جدول جهات اتصال المستفيد", "Display beneficiary Addresses DataTable", 13 },
                    { 56, 3, null, false, true, true, false, "Beneficiary/CreateEditContactModal", 2, "عرض واجهة إضافة تعديل جهات اتصال المستفيد", "Display Create Edit beneficiary Addresses Page", 13 },
                    { 57, 3, null, false, true, true, false, "Beneficiary/CreateEditContact", 2, "إضافة تعديل جهات اتصال المستفيد", "Create Edit beneficiary Addresses", 13 },
                    { 59, 3, null, false, true, true, false, "Beneficiary/GetAttachments", 2, "عرض المرفقات", "Display Attachments", 13 },
                    { 60, 3, null, false, true, true, false, "Beneficiary/UploadAttachment", 2, "تحميل مرفق", "Upload Attachment", 13 },
                    { 61, 3, null, false, true, true, false, "Beneficiary/SaveAttachment", 2, "حفظ المرفقات", "Save Attachment", 13 },
                    { 62, 3, null, false, true, true, false, "Beneficiary/DeleteAttachment", 2, "حذف المرفقات", "Delete Attachment", 13 },
                    { 63, 3, null, false, true, true, false, "Beneficiary/GetBeneficiaryTypes", 2, "عرض بيانات جدول أنواع المستفيد ", "Display Beneficiary Types DataTable", 14 },
                    { 64, 3, null, false, true, true, false, "Beneficiary/CreateEditBeneficiaryTypeModal", 2, "عرض واجهة إضافة تعديل أنواع المستفيد", "Display Create Edit Beneficiary Types page", 14 },
                    { 65, 3, null, false, true, true, false, "Beneficiary/CreateEditBeneficiaryType", 2, "إضافة تعديل أنواع المستفيد", "Create Edit Beneficiary Types", 14 },
                    { 66, 3, null, false, true, true, false, "Beneficiary/DeleteBeneficiaryType", 2, "حذف أنواع المستفيد", "Delete Beneficiary Types", 14 }
                });

            migrationBuilder.InsertData(
                table: "UserPermissions",
                columns: new[] { "Id", "PageId", "UserTypeId" },
                values: new object[,]
                {
                    { 4, 4, 1 },
                    { 8, 9, 1 },
                    { 9, 10, 1 },
                    { 10, 11, 1 },
                    { 12, 13, 1 },
                    { 13, 14, 1 },
                    { 14, 15, 1 },
                    { 16, 17, 1 },
                    { 17, 18, 1 },
                    { 18, 19, 1 },
                    { 19, 20, 1 },
                    { 20, 21, 1 },
                    { 21, 22, 1 },
                    { 22, 23, 1 },
                    { 57, 58, 1 }
                });

            migrationBuilder.InsertData(
                table: "Pages",
                columns: new[] { "Id", "CategoryId", "Icon", "InMenu", "IsActive", "IsAjax", "IsDeleted", "Link", "ModuleId", "Name", "NameEn", "ParentId" },
                values: new object[,]
                {
                    { 24, 3, null, false, true, true, false, "User/GetAll", 1, "عرض بيانات جدول المستخدمين", "Display User DataTable", 5 },
                    { 25, 3, null, false, true, true, false, "User/CreateEditModal", 1, "اظهار واجهة اضافة  تعديل مستخدم", "Display Create Edit User Page", 5 },
                    { 26, 3, null, false, true, true, false, "User/CreateEdit", 1, "اضافة تعديل مستخدم", "Create Edit User", 5 },
                    { 27, 3, null, false, true, true, false, "User/Delete", 1, "حذف مستخدم", "Delete User", 5 },
                    { 28, 3, null, false, true, true, false, "User/MyProfileModal", 1, "عرض واجهة ملفي الشخصي", "Display My Profile Page", 5 },
                    { 29, 3, null, false, true, true, false, "User/MyProfile", 1, "تعديل ملفي الشخصي", "Update My Profile", 5 },
                    { 30, 3, null, false, true, true, false, "User/ChangePasswordModal", 1, "عرض واجهة تغير كلمة المرور", "Display Change Password Page", 5 },
                    { 31, 3, null, false, true, true, false, "User/ChangePassword", 1, "تغير كلمة المرور", "ChangePassword", 5 },
                    { 32, 3, null, false, true, true, false, "UserType/GetAll", 1, "عرض بيانات جدول انواع المستخدين", "Display User Type DateTable", 6 },
                    { 33, 3, null, false, true, true, false, "UserType/CreateEditModal", 1, "عرض واجهة اضافة  تعديل نوع المستخدم", "Display Create Edit User Type page", 6 },
                    { 34, 3, null, false, true, true, false, "UserType/CreateEdit", 1, "اضافة تعديل نوع مستخدم", "Create Edit User Type ", 6 },
                    { 35, 3, null, false, true, true, false, "UserType/Delete", 1, "حذف نوع مستخدم", "Delete User Type ", 6 },
                    { 36, 3, null, false, true, true, false, "UserPermission/GetUserTypePermissions", 1, "عرض صلاحيات نوع المستخدم", "display User Type Permissions", 7 },
                    { 37, 3, null, false, true, true, false, "UserPermission/SavePermissions", 1, "حفظ صلاحيات نوع المستخدم", "Save User Type Permissions", 7 }
                });

            migrationBuilder.InsertData(
                table: "UserPermissions",
                columns: new[] { "Id", "PageId", "UserTypeId" },
                values: new object[,]
                {
                    { 5, 5, 1 },
                    { 6, 6, 1 },
                    { 7, 7, 1 },
                    { 37, 38, 1 },
                    { 38, 39, 1 },
                    { 39, 40, 1 },
                    { 40, 41, 1 },
                    { 41, 42, 1 },
                    { 42, 43, 1 },
                    { 43, 44, 1 },
                    { 44, 45, 1 },
                    { 45, 46, 1 },
                    { 46, 47, 1 },
                    { 47, 48, 1 },
                    { 48, 49, 1 },
                    { 49, 50, 1 },
                    { 50, 51, 1 },
                    { 51, 52, 1 },
                    { 52, 53, 1 },
                    { 53, 54, 1 },
                    { 54, 55, 1 },
                    { 55, 56, 1 },
                    { 56, 57, 1 },
                    { 58, 59, 1 },
                    { 59, 60, 1 },
                    { 60, 61, 1 },
                    { 61, 62, 1 },
                    { 62, 63, 1 },
                    { 63, 64, 1 },
                    { 64, 65, 1 },
                    { 65, 66, 1 },
                    { 23, 24, 1 },
                    { 24, 25, 1 },
                    { 25, 26, 1 },
                    { 26, 27, 1 },
                    { 27, 28, 1 },
                    { 28, 29, 1 },
                    { 29, 30, 1 },
                    { 30, 31, 1 },
                    { 31, 32, 1 },
                    { 32, 33, 1 },
                    { 33, 34, 1 },
                    { 34, 35, 1 },
                    { 35, 36, 1 },
                    { 36, 37, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_GenderId",
                table: "AspNetUsers",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserTypeId",
                table: "AspNetUsers",
                column: "UserTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UniqueEmail",
                table: "AspNetUsers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UniquePhoneNo",
                table: "AspNetUsers",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_BeneficiaryTypeId",
                table: "Beneficiaries",
                column: "BeneficiaryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_GenderId",
                table: "Beneficiaries",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiaries_ParentId",
                table: "Beneficiaries",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_BeneficiaryInformations_AccommodationId",
                table: "BeneficiaryInformations",
                column: "AccommodationId");

            migrationBuilder.CreateIndex(
                name: "IX_BeneficiaryInformations_BeneficiaryId",
                table: "BeneficiaryInformations",
                column: "BeneficiaryId");

            migrationBuilder.CreateIndex(
                name: "IX_BeneficiaryInformations_HousingStatusId",
                table: "BeneficiaryInformations",
                column: "HousingStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_BeneficiaryInformations_TheHealthConditionId",
                table: "BeneficiaryInformations",
                column: "TheHealthConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_BeneficiaryInformations_WorkStatusId",
                table: "BeneficiaryInformations",
                column: "WorkStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Childrens_BeneficiaryId",
                table: "Childrens",
                column: "BeneficiaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Childrens_GenderId",
                table: "Childrens",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Childrens_ParentId",
                table: "Childrens",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Childrens_TheHealthConditionId",
                table: "Childrens",
                column: "TheHealthConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_Childrens_WiveId",
                table: "Childrens",
                column: "WiveId");

            migrationBuilder.CreateIndex(
                name: "IX_Constants_ParentId",
                table: "Constants",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_CategoryId",
                table: "Pages",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_ModuleId",
                table: "Pages",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_ParentId",
                table: "Pages",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPermissions_PageId",
                table: "UserPermissions",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPermissions_UserTypeId",
                table: "UserPermissions",
                column: "UserTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTypes_UniqueName",
                table: "UserTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Wives_BeneficiaryId",
                table: "Wives",
                column: "BeneficiaryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BeneficiaryInformations");

            migrationBuilder.DropTable(
                name: "Childrens");

            migrationBuilder.DropTable(
                name: "TypesSubscriptions");

            migrationBuilder.DropTable(
                name: "UserPermissions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Accommodations");

            migrationBuilder.DropTable(
                name: "HousingStatus");

            migrationBuilder.DropTable(
                name: "WorkStatus");

            migrationBuilder.DropTable(
                name: "TheHealthConditions");

            migrationBuilder.DropTable(
                name: "Wives");

            migrationBuilder.DropTable(
                name: "Pages");

            migrationBuilder.DropTable(
                name: "UserTypes");

            migrationBuilder.DropTable(
                name: "Beneficiaries");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "PageCategories");

            migrationBuilder.DropTable(
                name: "Constants");
        }
    }
}
