using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ApplicationFormAndProductMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Credits_CreditRequests_CreditRequestId",
                table: "Credits");

            migrationBuilder.DropForeignKey(
                name: "FK_Credits_Currencies_CurrencyId",
                table: "Credits");

            migrationBuilder.DropForeignKey(
                name: "FK_Credits_Customers_CustomerId",
                table: "Credits");

            migrationBuilder.DropTable(
                name: "CreditRequests");

            migrationBuilder.DropIndex(
                name: "IX_Credits_CreditRequestId",
                table: "Credits");

            migrationBuilder.DropIndex(
                name: "IX_Credits_CurrencyId",
                table: "Credits");

            migrationBuilder.DropIndex(
                name: "IX_Credits_CustomerId",
                table: "Credits");

            migrationBuilder.DropColumn(
                name: "CreditRequestId",
                table: "Credits");

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "Credits");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Credits",
                newName: "ApplicationFormId");

            migrationBuilder.AddColumn<int>(
                name: "ApplicationFormId",
                table: "CurrentAccounts",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ApplicationFormId",
                table: "CreditCards",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ApplicationForms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Lastname = table.Column<string>(type: "text", nullable: false),
                    DocumentNumber = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Mail = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Descripcion = table.Column<string>(type: "text", nullable: false),
                    ApplicationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ApprovalDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RejectionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RequestStatus = table.Column<int>(type: "integer", nullable: false),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    CurrencyId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationForms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationForms_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationForms_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductType = table.Column<int>(type: "integer", nullable: false),
                    ApplicationFormId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ApplicationForms_ApplicationFormId",
                        column: x => x.ApplicationFormId,
                        principalTable: "ApplicationForms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationForms_CurrencyId",
                table: "ApplicationForms",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationForms_CustomerId",
                table: "ApplicationForms",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ApplicationFormId",
                table: "Products",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ApplicationForms");

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
                table: "CreditCards");

            migrationBuilder.RenameColumn(
                name: "ApplicationFormId",
                table: "Credits",
                newName: "CustomerId");

            migrationBuilder.AddColumn<int>(
                name: "CreditRequestId",
                table: "Credits",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CurrencyId",
                table: "Credits",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CreditRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CurrencyId = table.Column<int>(type: "integer", nullable: false),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    ApplicationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ApprovalDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RejectionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RequestStatus = table.Column<int>(type: "integer", nullable: false),
                    Term = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditRequests_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreditRequests_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Credits_CreditRequestId",
                table: "Credits",
                column: "CreditRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Credits_CurrencyId",
                table: "Credits",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Credits_CustomerId",
                table: "Credits",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditRequests_CurrencyId",
                table: "CreditRequests",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditRequests_CustomerId",
                table: "CreditRequests",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Credits_CreditRequests_CreditRequestId",
                table: "Credits",
                column: "CreditRequestId",
                principalTable: "CreditRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Credits_Currencies_CurrencyId",
                table: "Credits",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Credits_Customers_CustomerId",
                table: "Credits",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
