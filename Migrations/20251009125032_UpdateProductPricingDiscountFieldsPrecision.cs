using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cms_webapi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProductPricingDiscountFieldsPrecision : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Discount3",
                table: "RII_PRODUCT_PRICING",
                type: "decimal(18,6)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Discount2",
                table: "RII_PRODUCT_PRICING",
                type: "decimal(18,6)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Discount1",
                table: "RII_PRODUCT_PRICING",
                type: "decimal(18,6)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,4)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Discount3",
                table: "RII_PRODUCT_PRICING",
                type: "decimal(5,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Discount2",
                table: "RII_PRODUCT_PRICING",
                type: "decimal(5,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Discount1",
                table: "RII_PRODUCT_PRICING",
                type: "decimal(5,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)",
                oldNullable: true);
        }
    }
}
