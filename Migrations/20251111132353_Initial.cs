using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cms_webapi.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RII_ACTIVITY",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Subject = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ActivityType = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PotentialCustomerId = table.Column<long>(type: "bigint", nullable: true),
                    ErpCustomerCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Priority = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContactId = table.Column<long>(type: "bigint", nullable: true),
                    AssignedUserId = table.Column<long>(type: "bigint", nullable: true),
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
                    table.PrimaryKey("PK_RII_ACTIVITY", x => x.Id);
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
                });

            migrationBuilder.CreateTable(
                name: "RII_CUSTOMER",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CustomerTypeId = table.Column<long>(type: "bigint", nullable: true),
                    TaxOffice = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TaxNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SalesRepCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    GroupCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreditLimit = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    BranchCode = table.Column<short>(type: "smallint", nullable: false),
                    BusinessUnitCode = table.Column<short>(type: "smallint", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Website = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Phone1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Phone2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CountryId = table.Column<long>(type: "bigint", nullable: true),
                    CityId = table.Column<long>(type: "bigint", nullable: true),
                    DistrictId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true),
                    COMPLETION_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_COMPLETED = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IS_PENDING_APPROVAL = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    APPROVAL_STATUS = table.Column<bool>(type: "bit", nullable: true),
                    REJECTED_REASON = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    APPROVED_BY_USER_ID = table.Column<long>(type: "bigint", nullable: true),
                    APPROVAL_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_ERP_INTEGRATED = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ERP_INTEGRATION_NUMBER = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LAST_SYNC_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    COUNT_TRIED_BY = table.Column<int>(type: "int", nullable: true, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RII_CUSTOMER", x => x.Id);
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
                });

            migrationBuilder.CreateTable(
                name: "RII_PAYMENT_TYPE",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RII_PAYMENT_TYPE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RII_PRODUCT_PRICING",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ErpProductCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ErpGroupCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ListPrice = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    CostPrice = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Discount1 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    Discount2 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    Discount3 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
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
                    table.PrimaryKey("PK_RII_PRODUCT_PRICING", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RII_PRODUCT_PRICING_GROUP_BY",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ErpGroupCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ListPrice = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    CostPrice = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Discount1 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    Discount2 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    Discount3 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RII_PRODUCT_PRICING_GROUP_BY", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RII_QUOTATION",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    POTENTIAL_CUSTOMER_ID = table.Column<long>(type: "bigint", nullable: true),
                    ERP_CUSTOMER_CODE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContactId = table.Column<long>(type: "bigint", nullable: true),
                    ValidUntil = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DELIVERY_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SHIPPING_ADDRESS_ID = table.Column<long>(type: "bigint", nullable: true),
                    REPRESENTATIVE_ID = table.Column<long>(type: "bigint", nullable: true),
                    ActivityId = table.Column<long>(type: "bigint", nullable: true),
                    STATUS = table.Column<int>(type: "int", nullable: true),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PAYMENT_TYPE_ID = table.Column<long>(type: "bigint", nullable: true),
                    OFFER_TYPE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OFFER_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OFFER_NO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    REVISION_NO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    REVISION_ID = table.Column<long>(type: "bigint", nullable: true),
                    CURRENCY = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EXCHANGE_RATE = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    HasCustomerSpecificDiscount = table.Column<bool>(type: "bit", nullable: false),
                    CREATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CREATED_BY = table.Column<long>(type: "bigint", nullable: true),
                    UPDATED_BY = table.Column<long>(type: "bigint", nullable: true),
                    DELETED_BY = table.Column<long>(type: "bigint", nullable: true),
                    COMPLETION_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_COMPLETED = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IS_PENDING_APPROVAL = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    APPROVAL_STATUS = table.Column<bool>(type: "bit", nullable: true),
                    REJECTED_REASON = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    APPROVED_BY_USER_ID = table.Column<long>(type: "bigint", nullable: true),
                    APPROVAL_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IS_ERP_INTEGRATED = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ERP_INTEGRATION_NUMBER = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LAST_SYNC_DATE = table.Column<DateTime>(type: "datetime2", nullable: true),
                    COUNT_TRIED_BY = table.Column<int>(type: "int", nullable: true, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RII_QUOTATION", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RII_QUOTATION_RII_ACTIVITY_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "RII_ACTIVITY",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_QUOTATION_RII_CONTACT_ContactId",
                        column: x => x.ContactId,
                        principalTable: "RII_CONTACT",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_QUOTATION_RII_CUSTOMER_POTENTIAL_CUSTOMER_ID",
                        column: x => x.POTENTIAL_CUSTOMER_ID,
                        principalTable: "RII_CUSTOMER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RII_QUOTATION_RII_PAYMENT_TYPE_PAYMENT_TYPE_ID",
                        column: x => x.PAYMENT_TYPE_ID,
                        principalTable: "RII_PAYMENT_TYPE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RII_QUOTATION_LINE",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuotationId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: true),
                    ProductCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    DiscountRate1 = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    DiscountAmount1 = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    DiscountRate2 = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    DiscountAmount2 = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    DiscountRate3 = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    DiscountAmount3 = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    VatRate = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    VatAmount = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    LineTotal = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    LineGrandTotal = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
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
                    table.PrimaryKey("PK_RII_QUOTATION_LINE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RII_QUOTATION_LINE_RII_QUOTATION_QuotationId",
                        column: x => x.QuotationId,
                        principalTable: "RII_QUOTATION",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RII_SHIPPING_ADDRESS",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ContactPerson = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    CountryId = table.Column<long>(type: "bigint", nullable: true),
                    CityId = table.Column<long>(type: "bigint", nullable: true),
                    DistrictId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RII_SHIPPING_ADDRESS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RII_SHIPPING_ADDRESS_RII_CITY_CityId",
                        column: x => x.CityId,
                        principalTable: "RII_CITY",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_SHIPPING_ADDRESS_RII_COUNTRY_CountryId",
                        column: x => x.CountryId,
                        principalTable: "RII_COUNTRY",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_SHIPPING_ADDRESS_RII_CUSTOMER_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "RII_CUSTOMER",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_SHIPPING_ADDRESS_RII_DISTRICT_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "RII_DISTRICT",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RII_TITLE",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TitleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "RII_USER_AUTHORITY",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
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
                    table.PrimaryKey("PK_RII_USER_AUTHORITY", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RII_USERS",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    IsEmailConfirmed = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LastLoginDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
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
                    table.PrimaryKey("PK_RII_USERS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RII_USERS_RII_USERS_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_USERS_RII_USERS_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_USERS_RII_USERS_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_USERS_RII_USER_AUTHORITY_RoleId",
                        column: x => x.RoleId,
                        principalTable: "RII_USER_AUTHORITY",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RII_USER_DISCOUNT_LIMIT",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ErpProductGroupCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SalespersonId = table.Column<long>(type: "bigint", nullable: false),
                    MaxDiscount1 = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    MaxDiscount2 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
                    MaxDiscount3 = table.Column<decimal>(type: "decimal(18,6)", nullable: true),
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
                    table.PrimaryKey("PK_RII_USER_DISCOUNT_LIMIT", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RII_USER_DISCOUNT_LIMIT_RII_USERS_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_USER_DISCOUNT_LIMIT_RII_USERS_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_USER_DISCOUNT_LIMIT_RII_USERS_SalespersonId",
                        column: x => x.SalespersonId,
                        principalTable: "RII_USERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RII_USER_DISCOUNT_LIMIT_RII_USERS_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RII_USER_SESSION",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    SessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RevokedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IpAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserAgent = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DeviceInfo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
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
                    table.PrimaryKey("PK_RII_USER_SESSION", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RII_USER_SESSION_RII_USERS_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_USER_SESSION_RII_USERS_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_USER_SESSION_RII_USERS_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "RII_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_USER_SESSION_RII_USERS_UserId",
                        column: x => x.UserId,
                        principalTable: "RII_USERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activity_ActivityType",
                table: "RII_ACTIVITY",
                column: "ActivityType");

            migrationBuilder.CreateIndex(
                name: "IX_Activity_AssignedUserId",
                table: "RII_ACTIVITY",
                column: "AssignedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Activity_ContactId",
                table: "RII_ACTIVITY",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Activity_IsCompleted",
                table: "RII_ACTIVITY",
                column: "IsCompleted");

            migrationBuilder.CreateIndex(
                name: "IX_Activity_IsDeleted",
                table: "RII_ACTIVITY",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Activity_PotentialCustomerId",
                table: "RII_ACTIVITY",
                column: "PotentialCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Activity_Status",
                table: "RII_ACTIVITY",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_Activity_Subject",
                table: "RII_ACTIVITY",
                column: "Subject");

            migrationBuilder.CreateIndex(
                name: "IX_RII_ACTIVITY_CreatedBy",
                table: "RII_ACTIVITY",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_ACTIVITY_DeletedBy",
                table: "RII_ACTIVITY",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_ACTIVITY_UpdatedBy",
                table: "RII_ACTIVITY",
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
                name: "IX_RII_CUSTOMER_APPROVAL_DATE",
                table: "RII_CUSTOMER",
                column: "APPROVAL_DATE");

            migrationBuilder.CreateIndex(
                name: "IX_RII_CUSTOMER_APPROVAL_STATUS",
                table: "RII_CUSTOMER",
                column: "APPROVAL_STATUS");

            migrationBuilder.CreateIndex(
                name: "IX_RII_CUSTOMER_APPROVED_BY_USER_ID",
                table: "RII_CUSTOMER",
                column: "APPROVED_BY_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_RII_CUSTOMER_CityId",
                table: "RII_CUSTOMER",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_CUSTOMER_CountryId",
                table: "RII_CUSTOMER",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_CUSTOMER_CreatedBy",
                table: "RII_CUSTOMER",
                column: "CreatedBy");

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
                name: "IX_RII_CUSTOMER_DeletedBy",
                table: "RII_CUSTOMER",
                column: "DeletedBy");

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
                name: "IX_RII_CUSTOMER_IS_COMPLETED",
                table: "RII_CUSTOMER",
                column: "IS_COMPLETED");

            migrationBuilder.CreateIndex(
                name: "IX_RII_CUSTOMER_TaxNumber",
                table: "RII_CUSTOMER",
                column: "TaxNumber",
                filter: "[TaxNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RII_CUSTOMER_UpdatedBy",
                table: "RII_CUSTOMER",
                column: "UpdatedBy");

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
                name: "IX_PaymentType_CreatedDate",
                table: "RII_PAYMENT_TYPE",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentType_Name",
                table: "RII_PAYMENT_TYPE",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_RII_PAYMENT_TYPE_CreatedBy",
                table: "RII_PAYMENT_TYPE",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_PAYMENT_TYPE_DeletedBy",
                table: "RII_PAYMENT_TYPE",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_PAYMENT_TYPE_UpdatedBy",
                table: "RII_PAYMENT_TYPE",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPricing_CreatedDate",
                table: "RII_PRODUCT_PRICING",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPricing_ErpGroupCode",
                table: "RII_PRODUCT_PRICING",
                column: "ErpGroupCode");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPricing_ErpProductCode",
                table: "RII_PRODUCT_PRICING",
                column: "ErpProductCode");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPricing_ErpProductCode_ErpGroupCode",
                table: "RII_PRODUCT_PRICING",
                columns: new[] { "ErpProductCode", "ErpGroupCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductPricing_IsDeleted",
                table: "RII_PRODUCT_PRICING",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_RII_PRODUCT_PRICING_CreatedBy",
                table: "RII_PRODUCT_PRICING",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_PRODUCT_PRICING_DeletedBy",
                table: "RII_PRODUCT_PRICING",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_PRODUCT_PRICING_UpdatedBy",
                table: "RII_PRODUCT_PRICING",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPricingGroupBy_ErpGroupCode",
                table: "RII_PRODUCT_PRICING_GROUP_BY",
                column: "ErpGroupCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductPricingGroupBy_IsDeleted",
                table: "RII_PRODUCT_PRICING_GROUP_BY",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_RII_PRODUCT_PRICING_GROUP_BY_CreatedBy",
                table: "RII_PRODUCT_PRICING_GROUP_BY",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_PRODUCT_PRICING_GROUP_BY_DeletedBy",
                table: "RII_PRODUCT_PRICING_GROUP_BY",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_PRODUCT_PRICING_GROUP_BY_UpdatedBy",
                table: "RII_PRODUCT_PRICING_GROUP_BY",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_QUOTATION_ActivityId",
                table: "RII_QUOTATION",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_QUOTATION_APPROVAL_DATE",
                table: "RII_QUOTATION",
                column: "APPROVAL_DATE");

            migrationBuilder.CreateIndex(
                name: "IX_RII_QUOTATION_APPROVAL_STATUS",
                table: "RII_QUOTATION",
                column: "APPROVAL_STATUS");

            migrationBuilder.CreateIndex(
                name: "IX_RII_QUOTATION_APPROVED_BY_USER_ID",
                table: "RII_QUOTATION",
                column: "APPROVED_BY_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_RII_QUOTATION_ContactId",
                table: "RII_QUOTATION",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_QUOTATION_CREATED_BY",
                table: "RII_QUOTATION",
                column: "CREATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_RII_QUOTATION_CREATED_DATE",
                table: "RII_QUOTATION",
                column: "CREATED_DATE");

            migrationBuilder.CreateIndex(
                name: "IX_RII_QUOTATION_DELETED_BY",
                table: "RII_QUOTATION",
                column: "DELETED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_RII_QUOTATION_IS_COMPLETED",
                table: "RII_QUOTATION",
                column: "IS_COMPLETED");

            migrationBuilder.CreateIndex(
                name: "IX_RII_QUOTATION_OFFER_DATE",
                table: "RII_QUOTATION",
                column: "OFFER_DATE");

            migrationBuilder.CreateIndex(
                name: "IX_RII_QUOTATION_PAYMENT_TYPE_ID",
                table: "RII_QUOTATION",
                column: "PAYMENT_TYPE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_RII_QUOTATION_POTENTIAL_CUSTOMER_ID",
                table: "RII_QUOTATION",
                column: "POTENTIAL_CUSTOMER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_RII_QUOTATION_REPRESENTATIVE_ID",
                table: "RII_QUOTATION",
                column: "REPRESENTATIVE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_RII_QUOTATION_SHIPPING_ADDRESS_ID",
                table: "RII_QUOTATION",
                column: "SHIPPING_ADDRESS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_RII_QUOTATION_STATUS",
                table: "RII_QUOTATION",
                column: "STATUS");

            migrationBuilder.CreateIndex(
                name: "IX_RII_QUOTATION_UPDATED_BY",
                table: "RII_QUOTATION",
                column: "UPDATED_BY");

            migrationBuilder.CreateIndex(
                name: "IX_QuotationLine_IsDeleted",
                table: "RII_QUOTATION_LINE",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_QuotationLine_ProductCode",
                table: "RII_QUOTATION_LINE",
                column: "ProductCode");

            migrationBuilder.CreateIndex(
                name: "IX_QuotationLine_QuotationId",
                table: "RII_QUOTATION_LINE",
                column: "QuotationId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_QUOTATION_LINE_CreatedBy",
                table: "RII_QUOTATION_LINE",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_QUOTATION_LINE_DeletedBy",
                table: "RII_QUOTATION_LINE",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_QUOTATION_LINE_UpdatedBy",
                table: "RII_QUOTATION_LINE",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_SHIPPING_ADDRESS_CreatedBy",
                table: "RII_SHIPPING_ADDRESS",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_SHIPPING_ADDRESS_DeletedBy",
                table: "RII_SHIPPING_ADDRESS",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_SHIPPING_ADDRESS_UpdatedBy",
                table: "RII_SHIPPING_ADDRESS",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingAddress_CityId",
                table: "RII_SHIPPING_ADDRESS",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingAddress_CountryId",
                table: "RII_SHIPPING_ADDRESS",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingAddress_CustomerId",
                table: "RII_SHIPPING_ADDRESS",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingAddress_DistrictId",
                table: "RII_SHIPPING_ADDRESS",
                column: "DistrictId");

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
                name: "IX_RII_USER_AUTHORITY_CreatedBy",
                table: "RII_USER_AUTHORITY",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_USER_AUTHORITY_DeletedBy",
                table: "RII_USER_AUTHORITY",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_USER_AUTHORITY_Title",
                table: "RII_USER_AUTHORITY",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RII_USER_AUTHORITY_UpdatedBy",
                table: "RII_USER_AUTHORITY",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_USER_DISCOUNT_LIMIT_CreatedBy",
                table: "RII_USER_DISCOUNT_LIMIT",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_USER_DISCOUNT_LIMIT_DeletedBy",
                table: "RII_USER_DISCOUNT_LIMIT",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_USER_DISCOUNT_LIMIT_UpdatedBy",
                table: "RII_USER_DISCOUNT_LIMIT",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_UserDiscountLimit_ErpProductGroupCode",
                table: "RII_USER_DISCOUNT_LIMIT",
                column: "ErpProductGroupCode");

            migrationBuilder.CreateIndex(
                name: "IX_UserDiscountLimit_SalespersonId",
                table: "RII_USER_DISCOUNT_LIMIT",
                column: "SalespersonId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDiscountLimit_SalespersonId_ErpProductGroupCode",
                table: "RII_USER_DISCOUNT_LIMIT",
                columns: new[] { "SalespersonId", "ErpProductGroupCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RII_USER_SESSION_CreatedBy",
                table: "RII_USER_SESSION",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_USER_SESSION_DeletedBy",
                table: "RII_USER_SESSION",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_USER_SESSION_UpdatedBy",
                table: "RII_USER_SESSION",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_UserSession_RevokedAt",
                table: "RII_USER_SESSION",
                column: "RevokedAt");

            migrationBuilder.CreateIndex(
                name: "IX_UserSession_SessionId",
                table: "RII_USER_SESSION",
                column: "SessionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserSession_UserId",
                table: "RII_USER_SESSION",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_USERS_CreatedBy",
                table: "RII_USERS",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_USERS_DeletedBy",
                table: "RII_USERS",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RII_USERS_RoleId",
                table: "RII_USERS",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RII_USERS_UpdatedBy",
                table: "RII_USERS",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "RII_USERS",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "RII_USERS",
                column: "Username",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RII_ACTIVITY_RII_CONTACT_ContactId",
                table: "RII_ACTIVITY",
                column: "ContactId",
                principalTable: "RII_CONTACT",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_ACTIVITY_RII_CUSTOMER_PotentialCustomerId",
                table: "RII_ACTIVITY",
                column: "PotentialCustomerId",
                principalTable: "RII_CUSTOMER",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_ACTIVITY_RII_USERS_AssignedUserId",
                table: "RII_ACTIVITY",
                column: "AssignedUserId",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_ACTIVITY_RII_USERS_CreatedBy",
                table: "RII_ACTIVITY",
                column: "CreatedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_ACTIVITY_RII_USERS_DeletedBy",
                table: "RII_ACTIVITY",
                column: "DeletedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_ACTIVITY_RII_USERS_UpdatedBy",
                table: "RII_ACTIVITY",
                column: "UpdatedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_CITY_RII_COUNTRY_CountryId",
                table: "RII_CITY",
                column: "CountryId",
                principalTable: "RII_COUNTRY",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RII_CITY_RII_USERS_CreatedBy",
                table: "RII_CITY",
                column: "CreatedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_CITY_RII_USERS_DeletedBy",
                table: "RII_CITY",
                column: "DeletedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_CITY_RII_USERS_UpdatedBy",
                table: "RII_CITY",
                column: "UpdatedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_CONTACT_RII_COUNTRY_CountryId",
                table: "RII_CONTACT",
                column: "CountryId",
                principalTable: "RII_COUNTRY",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_CONTACT_RII_CUSTOMER_CustomerId",
                table: "RII_CONTACT",
                column: "CustomerId",
                principalTable: "RII_CUSTOMER",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_CONTACT_RII_TITLE_TitleId",
                table: "RII_CONTACT",
                column: "TitleId",
                principalTable: "RII_TITLE",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RII_CONTACT_RII_USERS_CreatedBy",
                table: "RII_CONTACT",
                column: "CreatedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_CONTACT_RII_USERS_DeletedBy",
                table: "RII_CONTACT",
                column: "DeletedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_CONTACT_RII_USERS_UpdatedBy",
                table: "RII_CONTACT",
                column: "UpdatedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_COUNTRY_RII_USERS_CreatedBy",
                table: "RII_COUNTRY",
                column: "CreatedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_COUNTRY_RII_USERS_DeletedBy",
                table: "RII_COUNTRY",
                column: "DeletedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_COUNTRY_RII_USERS_UpdatedBy",
                table: "RII_COUNTRY",
                column: "UpdatedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_CUSTOMER_RII_CUSTOMER_TYPE_CustomerTypeId",
                table: "RII_CUSTOMER",
                column: "CustomerTypeId",
                principalTable: "RII_CUSTOMER_TYPE",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_RII_CUSTOMER_RII_DISTRICT_DistrictId",
                table: "RII_CUSTOMER",
                column: "DistrictId",
                principalTable: "RII_DISTRICT",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_CUSTOMER_RII_USERS_APPROVED_BY_USER_ID",
                table: "RII_CUSTOMER",
                column: "APPROVED_BY_USER_ID",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_CUSTOMER_RII_USERS_CreatedBy",
                table: "RII_CUSTOMER",
                column: "CreatedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_CUSTOMER_RII_USERS_DeletedBy",
                table: "RII_CUSTOMER",
                column: "DeletedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_CUSTOMER_RII_USERS_UpdatedBy",
                table: "RII_CUSTOMER",
                column: "UpdatedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_CUSTOMER_TYPE_RII_USERS_CreatedBy",
                table: "RII_CUSTOMER_TYPE",
                column: "CreatedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_CUSTOMER_TYPE_RII_USERS_DeletedBy",
                table: "RII_CUSTOMER_TYPE",
                column: "DeletedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_CUSTOMER_TYPE_RII_USERS_UpdatedBy",
                table: "RII_CUSTOMER_TYPE",
                column: "UpdatedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_DISTRICT_RII_USERS_CreatedBy",
                table: "RII_DISTRICT",
                column: "CreatedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_DISTRICT_RII_USERS_DeletedBy",
                table: "RII_DISTRICT",
                column: "DeletedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_DISTRICT_RII_USERS_UpdatedBy",
                table: "RII_DISTRICT",
                column: "UpdatedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_PAYMENT_TYPE_RII_USERS_CreatedBy",
                table: "RII_PAYMENT_TYPE",
                column: "CreatedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_PAYMENT_TYPE_RII_USERS_DeletedBy",
                table: "RII_PAYMENT_TYPE",
                column: "DeletedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_PAYMENT_TYPE_RII_USERS_UpdatedBy",
                table: "RII_PAYMENT_TYPE",
                column: "UpdatedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_PRODUCT_PRICING_RII_USERS_CreatedBy",
                table: "RII_PRODUCT_PRICING",
                column: "CreatedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_PRODUCT_PRICING_RII_USERS_DeletedBy",
                table: "RII_PRODUCT_PRICING",
                column: "DeletedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_PRODUCT_PRICING_RII_USERS_UpdatedBy",
                table: "RII_PRODUCT_PRICING",
                column: "UpdatedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_PRODUCT_PRICING_GROUP_BY_RII_USERS_CreatedBy",
                table: "RII_PRODUCT_PRICING_GROUP_BY",
                column: "CreatedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_PRODUCT_PRICING_GROUP_BY_RII_USERS_DeletedBy",
                table: "RII_PRODUCT_PRICING_GROUP_BY",
                column: "DeletedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_PRODUCT_PRICING_GROUP_BY_RII_USERS_UpdatedBy",
                table: "RII_PRODUCT_PRICING_GROUP_BY",
                column: "UpdatedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_QUOTATION_RII_SHIPPING_ADDRESS_SHIPPING_ADDRESS_ID",
                table: "RII_QUOTATION",
                column: "SHIPPING_ADDRESS_ID",
                principalTable: "RII_SHIPPING_ADDRESS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RII_QUOTATION_RII_USERS_APPROVED_BY_USER_ID",
                table: "RII_QUOTATION",
                column: "APPROVED_BY_USER_ID",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_QUOTATION_RII_USERS_CREATED_BY",
                table: "RII_QUOTATION",
                column: "CREATED_BY",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_QUOTATION_RII_USERS_DELETED_BY",
                table: "RII_QUOTATION",
                column: "DELETED_BY",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_QUOTATION_RII_USERS_REPRESENTATIVE_ID",
                table: "RII_QUOTATION",
                column: "REPRESENTATIVE_ID",
                principalTable: "RII_USERS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RII_QUOTATION_RII_USERS_UPDATED_BY",
                table: "RII_QUOTATION",
                column: "UPDATED_BY",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_QUOTATION_LINE_RII_USERS_CreatedBy",
                table: "RII_QUOTATION_LINE",
                column: "CreatedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_QUOTATION_LINE_RII_USERS_DeletedBy",
                table: "RII_QUOTATION_LINE",
                column: "DeletedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_QUOTATION_LINE_RII_USERS_UpdatedBy",
                table: "RII_QUOTATION_LINE",
                column: "UpdatedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_SHIPPING_ADDRESS_RII_USERS_CreatedBy",
                table: "RII_SHIPPING_ADDRESS",
                column: "CreatedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_SHIPPING_ADDRESS_RII_USERS_DeletedBy",
                table: "RII_SHIPPING_ADDRESS",
                column: "DeletedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_SHIPPING_ADDRESS_RII_USERS_UpdatedBy",
                table: "RII_SHIPPING_ADDRESS",
                column: "UpdatedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_TITLE_RII_USERS_CreatedBy",
                table: "RII_TITLE",
                column: "CreatedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_TITLE_RII_USERS_DeletedBy",
                table: "RII_TITLE",
                column: "DeletedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_TITLE_RII_USERS_UpdatedBy",
                table: "RII_TITLE",
                column: "UpdatedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_USER_AUTHORITY_RII_USERS_CreatedBy",
                table: "RII_USER_AUTHORITY",
                column: "CreatedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_USER_AUTHORITY_RII_USERS_DeletedBy",
                table: "RII_USER_AUTHORITY",
                column: "DeletedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RII_USER_AUTHORITY_RII_USERS_UpdatedBy",
                table: "RII_USER_AUTHORITY",
                column: "UpdatedBy",
                principalTable: "RII_USERS",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RII_USER_AUTHORITY_RII_USERS_CreatedBy",
                table: "RII_USER_AUTHORITY");

            migrationBuilder.DropForeignKey(
                name: "FK_RII_USER_AUTHORITY_RII_USERS_DeletedBy",
                table: "RII_USER_AUTHORITY");

            migrationBuilder.DropForeignKey(
                name: "FK_RII_USER_AUTHORITY_RII_USERS_UpdatedBy",
                table: "RII_USER_AUTHORITY");

            migrationBuilder.DropTable(
                name: "RII_PRODUCT_PRICING");

            migrationBuilder.DropTable(
                name: "RII_PRODUCT_PRICING_GROUP_BY");

            migrationBuilder.DropTable(
                name: "RII_QUOTATION_LINE");

            migrationBuilder.DropTable(
                name: "RII_USER_DISCOUNT_LIMIT");

            migrationBuilder.DropTable(
                name: "RII_USER_SESSION");

            migrationBuilder.DropTable(
                name: "RII_QUOTATION");

            migrationBuilder.DropTable(
                name: "RII_ACTIVITY");

            migrationBuilder.DropTable(
                name: "RII_PAYMENT_TYPE");

            migrationBuilder.DropTable(
                name: "RII_SHIPPING_ADDRESS");

            migrationBuilder.DropTable(
                name: "RII_CONTACT");

            migrationBuilder.DropTable(
                name: "RII_CUSTOMER");

            migrationBuilder.DropTable(
                name: "RII_TITLE");

            migrationBuilder.DropTable(
                name: "RII_CUSTOMER_TYPE");

            migrationBuilder.DropTable(
                name: "RII_DISTRICT");

            migrationBuilder.DropTable(
                name: "RII_CITY");

            migrationBuilder.DropTable(
                name: "RII_COUNTRY");

            migrationBuilder.DropTable(
                name: "RII_USERS");

            migrationBuilder.DropTable(
                name: "RII_USER_AUTHORITY");
        }
    }
}
