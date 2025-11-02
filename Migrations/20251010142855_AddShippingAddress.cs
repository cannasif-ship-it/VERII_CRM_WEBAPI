using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cms_webapi.Migrations
{
    /// <inheritdoc />
    public partial class AddShippingAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    CreatedBy = table.Column<long>(type: "bigint", maxLength: 100, nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", maxLength: 100, nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RII_PAYMENT_TYPE", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RII_PAYMENT_TYPE_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_PAYMENT_TYPE_Users_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_PAYMENT_TYPE_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
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
                    table.ForeignKey(
                        name: "FK_RII_SHIPPING_ADDRESS_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_SHIPPING_ADDRESS_Users_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_SHIPPING_ADDRESS_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RII_PAYMENT_TYPE");

            migrationBuilder.DropTable(
                name: "RII_SHIPPING_ADDRESS");
        }
    }
}
