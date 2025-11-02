using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cms_webapi.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "User"),
                    LastLoginDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsEmailConfirmed = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedBy = table.Column<long>(type: "bigint", maxLength: 100, nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", maxLength: 100, nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Users_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BaseHeaderEntity",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsPendingApproval = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ApprovalStatus = table.Column<bool>(type: "bit", nullable: true),
                    ApprovedByUserId = table.Column<int>(type: "int", nullable: true),
                    ApprovalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsERPIntegrated = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ERPIntegrationNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastSyncDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CountTriedBy = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseHeaderEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseHeaderEntity_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BaseHeaderEntity_Users_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BaseHeaderEntity_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RII_COUNTRY",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    ERPCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RII_COUNTRY", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RII_COUNTRY_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_COUNTRY_Users_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_COUNTRY_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RII_CUSTOMER_TYPE",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RII_CUSTOMER_TYPE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RII_CUSTOMER_TYPE_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_CUSTOMER_TYPE_Users_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_CUSTOMER_TYPE_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RII_TITLE",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RII_TITLE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RII_TITLE_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_TITLE_Users_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_TITLE_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RII_CITY",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ERPCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CountryId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RII_CITY", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RII_CITY_RII_COUNTRY_CountryId",
                        column: x => x.CountryId,
                        principalTable: "RII_COUNTRY",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RII_CITY_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_CITY_Users_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_CITY_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RII_DISTRICT",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ERPCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    CityId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RII_DISTRICT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RII_DISTRICT_RII_CITY_CityId",
                        column: x => x.CityId,
                        principalTable: "RII_CITY",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_DISTRICT_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_DISTRICT_Users_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_DISTRICT_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RII_CUSTOMER",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    CustomerCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CustomerTypeId = table.Column<long>(type: "bigint", nullable: true),
                    TaxOffice = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TaxNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SalesRepCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GroupCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreditLimit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BranchCode = table.Column<short>(type: "smallint", nullable: false),
                    BusinessUnitCode = table.Column<short>(type: "smallint", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Website = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Phone1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CountryId = table.Column<long>(type: "bigint", nullable: true),
                    CityId = table.Column<long>(type: "bigint", nullable: true),
                    DistrictId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RII_CUSTOMER", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RII_CUSTOMER_BaseHeaderEntity_Id",
                        column: x => x.Id,
                        principalTable: "BaseHeaderEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RII_CUSTOMER_RII_CITY_CityId",
                        column: x => x.CityId,
                        principalTable: "RII_CITY",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_CUSTOMER_RII_COUNTRY_CountryId",
                        column: x => x.CountryId,
                        principalTable: "RII_COUNTRY",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_CUSTOMER_RII_CUSTOMER_TYPE_CustomerTypeId",
                        column: x => x.CustomerTypeId,
                        principalTable: "RII_CUSTOMER_TYPE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_RII_CUSTOMER_RII_DISTRICT_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "RII_DISTRICT",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RII_CONTACT",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    TitleId = table.Column<long>(type: "bigint", nullable: false),
                    CountryId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RII_CONTACT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RII_CONTACT_RII_COUNTRY_CountryId",
                        column: x => x.CountryId,
                        principalTable: "RII_COUNTRY",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_CONTACT_RII_CUSTOMER_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "RII_CUSTOMER",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_CONTACT_RII_TITLE_TitleId",
                        column: x => x.TitleId,
                        principalTable: "RII_TITLE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RII_CONTACT_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_CONTACT_Users_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_CONTACT_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "Email", "FirstName", "IsActive", "IsEmailConfirmed", "LastLoginDate", "LastName", "PasswordHash", "PhoneNumber", "Role", "UpdatedBy", "UpdatedDate", "Username" },
                values: new object[] { 1L, null, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), null, null, "admin@vericmr.com", "Admin", true, true, null, "User", "$2a$11$8K1p/a0dL2LkqvMA87LzO.Ac5dvdW8aCO7yuiYxYGrI0rXG/a1u3W", null, "Admin", null, null, "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_BaseHeaderEntity_ApprovalStatus",
                table: "BaseHeaderEntity",
                column: "ApprovalStatus");

            migrationBuilder.CreateIndex(
                name: "IX_BaseHeaderEntity_CreatedBy",
                table: "BaseHeaderEntity",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_BaseHeaderEntity_DeletedBy",
                table: "BaseHeaderEntity",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_BaseHeaderEntity_ERPIntegrationNumber",
                table: "BaseHeaderEntity",
                column: "ERPIntegrationNumber");

            migrationBuilder.CreateIndex(
                name: "IX_BaseHeaderEntity_IsCompleted",
                table: "BaseHeaderEntity",
                column: "IsCompleted");

            migrationBuilder.CreateIndex(
                name: "IX_BaseHeaderEntity_IsERPIntegrated",
                table: "BaseHeaderEntity",
                column: "IsERPIntegrated");

            migrationBuilder.CreateIndex(
                name: "IX_BaseHeaderEntity_IsPendingApproval",
                table: "BaseHeaderEntity",
                column: "IsPendingApproval");

            migrationBuilder.CreateIndex(
                name: "IX_BaseHeaderEntity_UpdatedBy",
                table: "BaseHeaderEntity",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_CITY_CountryId",
                table: "RII_CITY",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_CITY_CreatedBy",
                table: "RII_CITY",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_CITY_DeletedBy",
                table: "RII_CITY",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_CITY_Name",
                table: "RII_CITY",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_RII_CITY_UpdatedBy",
                table: "RII_CITY",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_CustomerId",
                table: "RII_CONTACT",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_Email",
                table: "RII_CONTACT",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_IsDeleted",
                table: "RII_CONTACT",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_TitleId",
                table: "RII_CONTACT",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_CONTACT_CountryId",
                table: "RII_CONTACT",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_CONTACT_CreatedBy",
                table: "RII_CONTACT",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_CONTACT_DeletedBy",
                table: "RII_CONTACT",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_CONTACT_UpdatedBy",
                table: "RII_CONTACT",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_COUNTRY_Code",
                table: "RII_COUNTRY",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RII_COUNTRY_CreatedBy",
                table: "RII_COUNTRY",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_COUNTRY_DeletedBy",
                table: "RII_COUNTRY",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_COUNTRY_Name",
                table: "RII_COUNTRY",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_RII_COUNTRY_UpdatedBy",
                table: "RII_COUNTRY",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_CUSTOMER_CityId",
                table: "RII_CUSTOMER",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_CUSTOMER_CountryId",
                table: "RII_CUSTOMER",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_CUSTOMER_CustomerCode",
                table: "RII_CUSTOMER",
                column: "CustomerCode",
                unique: true,
                filter: "[CustomerCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RII_CUSTOMER_CustomerTypeId",
                table: "RII_CUSTOMER",
                column: "CustomerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_CUSTOMER_DistrictId",
                table: "RII_CUSTOMER",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_CUSTOMER_Email",
                table: "RII_CUSTOMER",
                column: "Email",
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RII_CUSTOMER_TaxNumber",
                table: "RII_CUSTOMER",
                column: "TaxNumber",
                filter: "[TaxNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RII_CUSTOMER_TYPE_CreatedBy",
                table: "RII_CUSTOMER_TYPE",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_CUSTOMER_TYPE_DeletedBy",
                table: "RII_CUSTOMER_TYPE",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_CUSTOMER_TYPE_Name",
                table: "RII_CUSTOMER_TYPE",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RII_CUSTOMER_TYPE_UpdatedBy",
                table: "RII_CUSTOMER_TYPE",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_DISTRICT_CityId",
                table: "RII_DISTRICT",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_DISTRICT_CreatedBy",
                table: "RII_DISTRICT",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_DISTRICT_DeletedBy",
                table: "RII_DISTRICT",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_DISTRICT_ERPCode",
                table: "RII_DISTRICT",
                column: "ERPCode",
                unique: true,
                filter: "[ERPCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RII_DISTRICT_Name",
                table: "RII_DISTRICT",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_RII_DISTRICT_UpdatedBy",
                table: "RII_DISTRICT",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_TITLE_CreatedBy",
                table: "RII_TITLE",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_TITLE_DeletedBy",
                table: "RII_TITLE",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_TITLE_UpdatedBy",
                table: "RII_TITLE",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Title_IsDeleted",
                table: "RII_TITLE",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Title_TitleName",
                table: "RII_TITLE",
                column: "TitleName");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CreatedBy",
                table: "Users",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DeletedBy",
                table: "Users",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UpdatedBy",
                table: "Users",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RII_CONTACT");

            migrationBuilder.DropTable(
                name: "RII_CUSTOMER");

            migrationBuilder.DropTable(
                name: "RII_TITLE");

            migrationBuilder.DropTable(
                name: "BaseHeaderEntity");

            migrationBuilder.DropTable(
                name: "RII_CUSTOMER_TYPE");

            migrationBuilder.DropTable(
                name: "RII_DISTRICT");

            migrationBuilder.DropTable(
                name: "RII_CITY");

            migrationBuilder.DropTable(
                name: "RII_COUNTRY");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
