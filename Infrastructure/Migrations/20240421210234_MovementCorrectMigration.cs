using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MovementCorrectMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Accounts_SourceAccountId",
                table: "Transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Accounts_TargetAccountId",
                table: "Transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Currencies_CurrencyId",
                table: "Transfers");

            migrationBuilder.DropTable(
                name: "MovementAccounts");

            migrationBuilder.DropIndex(
                name: "IX_Transfers_CurrencyId",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "AccountNumber",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "DestinationBank",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "DocumentNumber",
                table: "Transfers");

            migrationBuilder.RenameColumn(
                name: "TargetAccountId",
                table: "Transfers",
                newName: "MovementId");

            migrationBuilder.RenameColumn(
                name: "SourceAccountId",
                table: "Transfers",
                newName: "OriginAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Transfers_TargetAccountId",
                table: "Transfers",
                newName: "IX_Transfers_MovementId");

            migrationBuilder.RenameIndex(
                name: "IX_Transfers_SourceAccountId",
                table: "Transfers",
                newName: "IX_Transfers_OriginAccountId");

            migrationBuilder.AddColumn<int>(
                name: "DestinationAccountId",
                table: "Transfers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MovementType",
                table: "Movements",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_DestinationAccountId",
                table: "Transfers",
                column: "DestinationAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Accounts_DestinationAccountId",
                table: "Transfers",
                column: "DestinationAccountId",
                principalTable: "Accounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Accounts_OriginAccountId",
                table: "Transfers",
                column: "OriginAccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Movements_MovementId",
                table: "Transfers",
                column: "MovementId",
                principalTable: "Movements",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Accounts_DestinationAccountId",
                table: "Transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Accounts_OriginAccountId",
                table: "Transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Movements_MovementId",
                table: "Transfers");

            migrationBuilder.DropIndex(
                name: "IX_Transfers_DestinationAccountId",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "DestinationAccountId",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "MovementType",
                table: "Movements");

            migrationBuilder.RenameColumn(
                name: "OriginAccountId",
                table: "Transfers",
                newName: "SourceAccountId");

            migrationBuilder.RenameColumn(
                name: "MovementId",
                table: "Transfers",
                newName: "TargetAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Transfers_OriginAccountId",
                table: "Transfers",
                newName: "IX_Transfers_SourceAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Transfers_MovementId",
                table: "Transfers",
                newName: "IX_Transfers_TargetAccountId");

            migrationBuilder.AddColumn<string>(
                name: "AccountNumber",
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

            migrationBuilder.AddColumn<string>(
                name: "DestinationBank",
                table: "Transfers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DocumentNumber",
                table: "Transfers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "MovementAccounts",
                columns: table => new
                {
                    MovementId = table.Column<int>(type: "integer", nullable: false),
                    AccountId = table.Column<int>(type: "integer", nullable: false),
                    TransferId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovementAccounts", x => new { x.MovementId, x.AccountId, x.TransferId });
                    table.ForeignKey(
                        name: "FK_MovementAccounts_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovementAccounts_Movements_MovementId",
                        column: x => x.MovementId,
                        principalTable: "Movements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovementAccounts_Transfers_TransferId",
                        column: x => x.TransferId,
                        principalTable: "Transfers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_CurrencyId",
                table: "Transfers",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_MovementAccounts_AccountId",
                table: "MovementAccounts",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_MovementAccounts_TransferId",
                table: "MovementAccounts",
                column: "TransferId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Accounts_SourceAccountId",
                table: "Transfers",
                column: "SourceAccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Accounts_TargetAccountId",
                table: "Transfers",
                column: "TargetAccountId",
                principalTable: "Accounts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Currencies_CurrencyId",
                table: "Transfers",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
