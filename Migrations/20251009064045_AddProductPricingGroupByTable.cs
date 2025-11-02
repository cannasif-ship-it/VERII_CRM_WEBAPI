using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cms_webapi.Migrations
{
    /// <inheritdoc />
    public partial class AddProductPricingGroupByTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RII_PRODUCT_PRICING_GROUP_BY",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ErpGroupCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ListPrice = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    CostPrice = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Discount1 = table.Column<decimal>(type: "decimal(5,4)", nullable: true),
                    Discount2 = table.Column<decimal>(type: "decimal(5,4)", nullable: true),
                    Discount3 = table.Column<decimal>(type: "decimal(5,4)", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_RII_PRODUCT_PRICING_GROUP_BY_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_PRODUCT_PRICING_GROUP_BY_Users_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_PRODUCT_PRICING_GROUP_BY_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RII_PRODUCT_PRICING_GROUP_BY");
        }
    }
}
