using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Claims.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    IdClientePk = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Deuda = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Envio = table.Column<bool>(type: "bit", nullable: false),
                    PagoEnvio = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.IdClientePk);
                });

            migrationBuilder.CreateTable(
                name: "Direcciones",
                columns: table => new
                {
                    IdDireccion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    NombreRemitente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CalleNumero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Colonia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoPostal = table.Column<int>(type: "int", nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Celular = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direcciones", x => x.IdDireccion);
                    table.ForeignKey(
                        name: "FK_Direcciones_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdClientePk",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListasCartas",
                columns: table => new
                {
                    IdListaCartasPk = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    NombreCarta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Precio = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    FechaCompra = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListasCartas", x => x.IdListaCartasPk);
                    table.ForeignKey(
                        name: "FK_ListasCartas_Clientes_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "IdClientePk",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Direcciones_IdCliente",
                table: "Direcciones",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_ListasCartas_IdCliente",
                table: "ListasCartas",
                column: "IdCliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Direcciones");

            migrationBuilder.DropTable(
                name: "ListasCartas");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
