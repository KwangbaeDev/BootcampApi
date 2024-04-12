using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AccountRelationsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SavingAccounts_AccountId",
                table: "SavingAccounts");

            migrationBuilder.DropIndex(
                name: "IX_CurrentAccounts_AccountId",
                table: "CurrentAccounts");

            migrationBuilder.AlterColumn<string>(
                name: "CardNumber",
                table: "CreditCards",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldMaxLength: 150);

            migrationBuilder.CreateIndex(
                name: "IX_SavingAccounts_AccountId",
                table: "SavingAccounts",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CurrentAccounts_AccountId",
                table: "CurrentAccounts",
                column: "AccountId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SavingAccounts_AccountId",
                table: "SavingAccounts");

            migrationBuilder.DropIndex(
                name: "IX_CurrentAccounts_AccountId",
                table: "CurrentAccounts");

            migrationBuilder.AlterColumn<int>(
                name: "CardNumber",
                table: "CreditCards",
                type: "integer",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(150)",
                oldMaxLength: 150);

            migrationBuilder.CreateIndex(
                name: "IX_SavingAccounts_AccountId",
                table: "SavingAccounts",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentAccounts_AccountId",
                table: "CurrentAccounts",
                column: "AccountId");
        }
    }
}
