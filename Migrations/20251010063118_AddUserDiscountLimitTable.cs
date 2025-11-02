using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cms_webapi.Migrations
{
    /// <inheritdoc />
    public partial class AddUserDiscountLimitTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                        name: "FK_RII_USER_DISCOUNT_LIMIT_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_USER_DISCOUNT_LIMIT_Users_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_USER_DISCOUNT_LIMIT_Users_SalespersonId",
                        column: x => x.SalespersonId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RII_USER_DISCOUNT_LIMIT_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RII_USER_DISCOUNT_LIMIT");
        }
    }
}
