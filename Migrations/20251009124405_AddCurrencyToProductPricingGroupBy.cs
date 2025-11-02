using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cms_webapi.Migrations
{
    /// <inheritdoc />
    public partial class AddCurrencyToProductPricingGroupBy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "RII_PRODUCT_PRICING_GROUP_BY",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Currency",
                table: "RII_PRODUCT_PRICING",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Currency",
                table: "RII_PRODUCT_PRICING_GROUP_BY");

            migrationBuilder.DropColumn(
                name: "Currency",
                table: "RII_PRODUCT_PRICING");
        }
    }
}
