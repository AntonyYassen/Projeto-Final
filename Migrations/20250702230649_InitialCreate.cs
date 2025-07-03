using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaAluguelVeiculos.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    CPF = table.Column<string>(type: "TEXT", maxLength: 11, nullable: false),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.CPF);
                });

            migrationBuilder.CreateTable(
                name: "Veiculos",
                columns: table => new
                {
                    Placa = table.Column<string>(type: "TEXT", maxLength: 7, nullable: false),
                    Modelo = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Ano = table.Column<int>(type: "INTEGER", nullable: false),
                    Disponivel = table.Column<bool>(type: "INTEGER", nullable: false),
                    TipoVeiculo = table.Column<string>(type: "TEXT", maxLength: 8, nullable: false),
                    QuantidadePortas = table.Column<int>(type: "INTEGER", nullable: true),
                    Cilindradas = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculos", x => x.Placa);
                });

            migrationBuilder.CreateTable(
                name: "Contratos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClienteCPF = table.Column<string>(type: "TEXT", nullable: false),
                    VeiculoPlaca = table.Column<string>(type: "TEXT", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataFim = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contratos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contratos_Clientes_ClienteCPF",
                        column: x => x.ClienteCPF,
                        principalTable: "Clientes",
                        principalColumn: "CPF",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contratos_Veiculos_VeiculoPlaca",
                        column: x => x.VeiculoPlaca,
                        principalTable: "Veiculos",
                        principalColumn: "Placa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_ClienteCPF",
                table: "Contratos",
                column: "ClienteCPF");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_VeiculoPlaca",
                table: "Contratos",
                column: "VeiculoPlaca");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contratos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Veiculos");
        }
    }
}
