using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreditCardCorrectionMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_CreditCards_CreditCardId",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_CreditCardId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "CreditCardId",
                table: "Accounts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreditCardId",
                table: "Accounts",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CreditCardId",
                table: "Accounts",
                column: "CreditCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_CreditCards_CreditCardId",
                table: "Accounts",
                column: "CreditCardId",
                principalTable: "CreditCards",
                principalColumn: "Id");
        }
    }
}
