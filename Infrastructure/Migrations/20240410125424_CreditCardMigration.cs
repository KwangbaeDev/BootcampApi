using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreditCardMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreditCardId",
                table: "Accounts",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CreditCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Designation = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    IssueDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CardNumber = table.Column<int>(type: "integer", maxLength: 150, nullable: false),
                    CVV = table.Column<int>(type: "integer", maxLength: 128, nullable: false),
                    CreditCardStatus = table.Column<int>(type: "integer", nullable: false),
                    CreditLimit = table.Column<decimal>(type: "numeric(20,5)", precision: 20, scale: 5, nullable: false),
                    AvailableCredit = table.Column<decimal>(type: "numeric(20,5)", precision: 20, scale: 5, nullable: false),
                    CurrentDebt = table.Column<decimal>(type: "numeric(20,5)", precision: 20, scale: 5, nullable: false),
                    InterestRate = table.Column<decimal>(type: "numeric(20,5)", precision: 20, scale: 5, nullable: false),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    CurrencyId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CreditCard_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditCards_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreditCards_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CreditCardId",
                table: "Accounts",
                column: "CreditCardId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditCards_CurrencyId",
                table: "CreditCards",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditCards_CustomerId",
                table: "CreditCards",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_CreditCards_CreditCardId",
                table: "Accounts",
                column: "CreditCardId",
                principalTable: "CreditCards",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_CreditCards_CreditCardId",
                table: "Accounts");

            migrationBuilder.DropTable(
                name: "CreditCards");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_CreditCardId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "CreditCardId",
                table: "Accounts");
        }
    }
}
