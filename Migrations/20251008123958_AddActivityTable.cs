using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cms_webapi.Migrations
{
    /// <inheritdoc />
    public partial class AddActivityTable : Migration
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
                    table.ForeignKey(
                        name: "FK_RII_ACTIVITY_RII_CONTACT_ContactId",
                        column: x => x.ContactId,
                        principalTable: "RII_CONTACT",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_ACTIVITY_RII_CUSTOMER_PotentialCustomerId",
                        column: x => x.PotentialCustomerId,
                        principalTable: "RII_CUSTOMER",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_ACTIVITY_Users_AssignedUserId",
                        column: x => x.AssignedUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_ACTIVITY_Users_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_ACTIVITY_Users_DeletedBy",
                        column: x => x.DeletedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RII_ACTIVITY_Users_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Users",
                        principalColumn: "Id");
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RII_ACTIVITY");
        }
    }
}
