using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ApplicationFormAndProduct2Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CreditCards_ApplicationForms_ApplicationFormId",
                table: "CreditCards");

            migrationBuilder.DropForeignKey(
                name: "FK_Credits_ApplicationForms_ApplicationFormId",
                table: "Credits");

            migrationBuilder.DropForeignKey(
                name: "FK_CurrentAccounts_ApplicationForms_ApplicationFormId",
                table: "CurrentAccounts");

            migrationBuilder.DropIndex(
                name: "IX_CurrentAccounts_ApplicationFormId",
                table: "CurrentAccounts");

            migrationBuilder.DropIndex(
                name: "IX_Credits_ApplicationFormId",
                table: "Credits");

            migrationBuilder.DropIndex(
                name: "IX_CreditCards_ApplicationFormId",
                table: "CreditCards");

            migrationBuilder.DropColumn(
                name: "ApplicationFormId",
                table: "CurrentAccounts");

            migrationBuilder.DropColumn(
                name: "ApplicationFormId",
                table: "Credits");

            migrationBuilder.DropColumn(
                name: "ApplicationFormId",
                table: "CreditCards");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApplicationFormId",
                table: "CurrentAccounts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ApplicationFormId",
                table: "Credits",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ApplicationFormId",
                table: "CreditCards",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CurrentAccounts_ApplicationFormId",
                table: "CurrentAccounts",
                column: "ApplicationFormId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Credits_ApplicationFormId",
                table: "Credits",
                column: "ApplicationFormId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CreditCards_ApplicationFormId",
                table: "CreditCards",
                column: "ApplicationFormId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CreditCards_ApplicationForms_ApplicationFormId",
                table: "CreditCards",
                column: "ApplicationFormId",
                principalTable: "ApplicationForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Credits_ApplicationForms_ApplicationFormId",
                table: "Credits",
                column: "ApplicationFormId",
                principalTable: "ApplicationForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CurrentAccounts_ApplicationForms_ApplicationFormId",
                table: "CurrentAccounts",
                column: "ApplicationFormId",
                principalTable: "ApplicationForms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
