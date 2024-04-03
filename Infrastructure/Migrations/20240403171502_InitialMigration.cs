using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    Telefono = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    Mail = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Direccion = table.Column<string>(type: "character varying(400)", maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Banco_pkey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    Apellido = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    Documento = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    Direccion = table.Column<string>(type: "character varying(400)", maxLength: 400, nullable: true),
                    Mail = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Celular = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    Estado = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    BancoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Cliente_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "Cliente_BancoId_fkey",
                        column: x => x.BancoId,
                        principalTable: "Banco",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cuentas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titular = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    NumeroCuenta = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Tipo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Saldo = table.Column<decimal>(type: "numeric(20,5)", precision: 20, scale: 5, nullable: false),
                    ClienteId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Cuenta_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "Cuenta_ClienteId_fkey",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CajaAhorros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CuentaId = table.Column<int>(type: "integer", nullable: false),
                    TipoDeposito = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    NombreTarjeta = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Estado = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CajaAhorro_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "CajaAhorro_CuentaId_fkey",
                        column: x => x.CuentaId,
                        principalTable: "Cuentas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CuentaCorrientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CuentaId = table.Column<int>(type: "integer", nullable: false),
                    LimiteOperacional = table.Column<decimal>(type: "numeric(20,5)", precision: 20, scale: 5, nullable: true),
                    PromedioMensual = table.Column<decimal>(type: "numeric(20,5)", precision: 20, scale: 5, nullable: true),
                    InteresMantenimiento = table.Column<decimal>(type: "numeric(10,5)", precision: 10, scale: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("CuentaCorriente_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "CuentaCorriente_CuentaId_fkey",
                        column: x => x.CuentaId,
                        principalTable: "Cuentas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Movimientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CuentaDestino = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    TipoOperacion = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    MontoTransaccion = table.Column<decimal>(type: "numeric(20,5)", precision: 20, scale: 5, nullable: true),
                    FechaHora = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Estado = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    CuentaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Movimientos_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "Movimientos_CuentaId_fkey",
                        column: x => x.CuentaId,
                        principalTable: "Cuentas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CajaAhorros_CuentaId",
                table: "CajaAhorros",
                column: "CuentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_BancoId",
                table: "Clientes",
                column: "BancoId");

            migrationBuilder.CreateIndex(
                name: "IX_CuentaCorrientes_CuentaId",
                table: "CuentaCorrientes",
                column: "CuentaId");

            migrationBuilder.CreateIndex(
                name: "IX_Cuentas_ClienteId",
                table: "Cuentas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_CuentaId",
                table: "Movimientos",
                column: "CuentaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CajaAhorros");

            migrationBuilder.DropTable(
                name: "CuentaCorrientes");

            migrationBuilder.DropTable(
                name: "Movimientos");

            migrationBuilder.DropTable(
                name: "Cuentas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Banco");
        }
    }
}
