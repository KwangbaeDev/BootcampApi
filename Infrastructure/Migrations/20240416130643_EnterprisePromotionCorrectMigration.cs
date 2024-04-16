using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EnterprisePromotionCorrectMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Promotions_CompanyBusinesses_CompanyBusinessId",
                table: "Promotions");

            migrationBuilder.DropTable(
                name: "CompanyBusinesses");

            migrationBuilder.DropPrimaryKey(
                name: "Promotion_pkey",
                table: "Promotions");

            migrationBuilder.DropIndex(
                name: "IX_Promotions_CompanyBusinessId",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "DurationTime",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "PercentageOff",
                table: "Promotions");

            migrationBuilder.RenameColumn(
                name: "CompanyBusinessId",
                table: "Promotions",
                newName: "Discount");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Promotions",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<DateTime>(
                name: "End",
                table: "Promotions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Start",
                table: "Promotions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Promotions",
                table: "Promotions",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Enterprises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enterprises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PromotionEnterprises",
                columns: table => new
                {
                    PromotionId = table.Column<int>(type: "integer", nullable: false),
                    EnterpriseId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromotionEnterprises", x => new { x.PromotionId, x.EnterpriseId });
                    table.ForeignKey(
                        name: "FK_PromotionEnterprises_Enterprises_EnterpriseId",
                        column: x => x.EnterpriseId,
                        principalTable: "Enterprises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PromotionEnterprises_Promotions_PromotionId",
                        column: x => x.PromotionId,
                        principalTable: "Promotions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PromotionEnterprises_EnterpriseId",
                table: "PromotionEnterprises",
                column: "EnterpriseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PromotionEnterprises");

            migrationBuilder.DropTable(
                name: "Enterprises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Promotions",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "End",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "Start",
                table: "Promotions");

            migrationBuilder.RenameColumn(
                name: "Discount",
                table: "Promotions",
                newName: "CompanyBusinessId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Promotions",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<DateTime>(
                name: "DurationTime",
                table: "Promotions",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PercentageOff",
                table: "Promotions",
                type: "numeric(20,5)",
                precision: 20,
                scale: 5,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "Promotion_pkey",
                table: "Promotions",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CompanyBusinesses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Address = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    IsDeleted = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Company_Business_pkey", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_CompanyBusinessId",
                table: "Promotions",
                column: "CompanyBusinessId");

            migrationBuilder.AddForeignKey(
                name: "FK_Promotions_CompanyBusinesses_CompanyBusinessId",
                table: "Promotions",
                column: "CompanyBusinessId",
                principalTable: "CompanyBusinesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
