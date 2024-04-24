using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DeleteMovementMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deposits_Movements_MovementId",
                table: "Deposits");

            migrationBuilder.DropForeignKey(
                name: "FK_Extractions_Movements_MovementId",
                table: "Extractions");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentServices_Movements_MovementId",
                table: "PaymentServices");

            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Movements_MovementId",
                table: "Transfers");

            migrationBuilder.DropTable(
                name: "Movements");

            migrationBuilder.RenameColumn(
                name: "MovementId",
                table: "Transfers",
                newName: "DestinationBankId");

            migrationBuilder.RenameIndex(
                name: "IX_Transfers_MovementId",
                table: "Transfers",
                newName: "IX_Transfers_DestinationBankId");

            migrationBuilder.RenameColumn(
                name: "MovementId",
                table: "PaymentServices",
                newName: "AccountId");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "PaymentServices",
                newName: "Concept");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentServices_MovementId",
                table: "PaymentServices",
                newName: "IX_PaymentServices_AccountId");

            migrationBuilder.RenameColumn(
                name: "MovementId",
                table: "Extractions",
                newName: "BankId");

            migrationBuilder.RenameIndex(
                name: "IX_Extractions_MovementId",
                table: "Extractions",
                newName: "IX_Extractions_BankId");

            migrationBuilder.RenameColumn(
                name: "MovementId",
                table: "Deposits",
                newName: "BankId");

            migrationBuilder.RenameIndex(
                name: "IX_Deposits_MovementId",
                table: "Deposits",
                newName: "IX_Deposits_BankId");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Transfers",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Concept",
                table: "Transfers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                table: "Transfers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "TransferredDateTime",
                table: "Transfers",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "PaymentServices",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "PaymentServiceDateTime",
                table: "PaymentServices",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Extractions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Extractions",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExtractionDateTime",
                table: "Extractions",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Deposits",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Deposits",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "DepositDateTime",
                table: "Deposits",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_CurrencyId",
                table: "Transfers",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Extractions_AccountId",
                table: "Extractions",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Deposits_AccountId",
                table: "Deposits",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Deposits_Accounts_AccountId",
                table: "Deposits",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Deposits_Banks_BankId",
                table: "Deposits",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Extractions_Accounts_AccountId",
                table: "Extractions",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Extractions_Banks_BankId",
                table: "Extractions",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentServices_Accounts_AccountId",
                table: "PaymentServices",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Banks_DestinationBankId",
                table: "Transfers",
                column: "DestinationBankId",
                principalTable: "Banks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Currencies_CurrencyId",
                table: "Transfers",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deposits_Accounts_AccountId",
                table: "Deposits");

            migrationBuilder.DropForeignKey(
                name: "FK_Deposits_Banks_BankId",
                table: "Deposits");

            migrationBuilder.DropForeignKey(
                name: "FK_Extractions_Accounts_AccountId",
                table: "Extractions");

            migrationBuilder.DropForeignKey(
                name: "FK_Extractions_Banks_BankId",
                table: "Extractions");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentServices_Accounts_AccountId",
                table: "PaymentServices");

            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Banks_DestinationBankId",
                table: "Transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Currencies_CurrencyId",
                table: "Transfers");

            migrationBuilder.DropIndex(
                name: "IX_Transfers_CurrencyId",
                table: "Transfers");

            migrationBuilder.DropIndex(
                name: "IX_Extractions_AccountId",
                table: "Extractions");

            migrationBuilder.DropIndex(
                name: "IX_Deposits_AccountId",
                table: "Deposits");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "Concept",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "TransferredDateTime",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "PaymentServices");

            migrationBuilder.DropColumn(
                name: "PaymentServiceDateTime",
                table: "PaymentServices");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Extractions");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Extractions");

            migrationBuilder.DropColumn(
                name: "ExtractionDateTime",
                table: "Extractions");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Deposits");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Deposits");

            migrationBuilder.DropColumn(
                name: "DepositDateTime",
                table: "Deposits");

            migrationBuilder.RenameColumn(
                name: "DestinationBankId",
                table: "Transfers",
                newName: "MovementId");

            migrationBuilder.RenameIndex(
                name: "IX_Transfers_DestinationBankId",
                table: "Transfers",
                newName: "IX_Transfers_MovementId");

            migrationBuilder.RenameColumn(
                name: "Concept",
                table: "PaymentServices",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "PaymentServices",
                newName: "MovementId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentServices_AccountId",
                table: "PaymentServices",
                newName: "IX_PaymentServices_MovementId");

            migrationBuilder.RenameColumn(
                name: "BankId",
                table: "Extractions",
                newName: "MovementId");

            migrationBuilder.RenameIndex(
                name: "IX_Extractions_BankId",
                table: "Extractions",
                newName: "IX_Extractions_MovementId");

            migrationBuilder.RenameColumn(
                name: "BankId",
                table: "Deposits",
                newName: "MovementId");

            migrationBuilder.RenameIndex(
                name: "IX_Deposits_BankId",
                table: "Deposits",
                newName: "IX_Deposits_MovementId");

            migrationBuilder.CreateTable(
                name: "Movements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccountId = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric(20,5)", precision: 20, scale: 5, nullable: false),
                    Destination = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    MovementType = table.Column<int>(type: "integer", nullable: false),
                    TransferStatus = table.Column<int>(type: "integer", nullable: false),
                    TransferredDateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Movement_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movements_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movements_AccountId",
                table: "Movements",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Deposits_Movements_MovementId",
                table: "Deposits",
                column: "MovementId",
                principalTable: "Movements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Extractions_Movements_MovementId",
                table: "Extractions",
                column: "MovementId",
                principalTable: "Movements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentServices_Movements_MovementId",
                table: "PaymentServices",
                column: "MovementId",
                principalTable: "Movements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Movements_MovementId",
                table: "Transfers",
                column: "MovementId",
                principalTable: "Movements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
