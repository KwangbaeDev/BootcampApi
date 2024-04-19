using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CorrectApplicationFormMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "ApplicationForms");

            migrationBuilder.DropColumn(
                name: "DocumentNumber",
                table: "ApplicationForms");

            migrationBuilder.DropColumn(
                name: "Lastname",
                table: "ApplicationForms");

            migrationBuilder.DropColumn(
                name: "Mail",
                table: "ApplicationForms");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ApplicationForms");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "ApplicationForms");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "ApplicationForms",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DocumentNumber",
                table: "ApplicationForms",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Lastname",
                table: "ApplicationForms",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Mail",
                table: "ApplicationForms",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ApplicationForms",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "ApplicationForms",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
