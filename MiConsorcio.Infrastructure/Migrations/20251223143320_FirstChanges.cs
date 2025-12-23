using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiConsorcio.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FirstChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriasGasto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasGasto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Consorcios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Cuit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Calle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoPostal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consorcios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Documento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoPersona = table.Column<int>(type: "int", nullable: false),
                    Calle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoPostal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsorcioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RazonSocial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cuil = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Actividad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Expensas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConsorcioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PeriodoAnio = table.Column<int>(type: "int", nullable: false),
                    PeriodoMes = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expensas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expensas_Consorcios_ConsorcioId",
                        column: x => x.ConsorcioId,
                        principalTable: "Consorcios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Gastos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConsorcioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PeriodoAno = table.Column<int>(type: "int", nullable: false),
                    PeriodoMes = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ProveedorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CategoriaGastoId = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gastos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gastos_Consorcios_ConsorcioId",
                        column: x => x.ConsorcioId,
                        principalTable: "Consorcios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConsorcioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnidadFuncionalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MedioPago = table.Column<int>(type: "int", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pagos_Consorcios_ConsorcioId",
                        column: x => x.ConsorcioId,
                        principalTable: "Consorcios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UnidadesFuncionales",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    Coeficiente = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Piso = table.Column<int>(type: "int", nullable: true),
                    Departamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<int>(type: "int", nullable: false),
                    Saldo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ConsorcioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadesFuncionales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnidadesFuncionales_Consorcios_ConsorcioId",
                        column: x => x.ConsorcioId,
                        principalTable: "Consorcios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ExpensaDetalle",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExpensaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnidadFuncionalId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpensaDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpensaDetalle_Expensas_ExpensaId",
                        column: x => x.ExpensaId,
                        principalTable: "Expensas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoriasGasto_Nombre",
                table: "CategoriasGasto",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExpensaDetalle_ExpensaId",
                table: "ExpensaDetalle",
                column: "ExpensaId");

            migrationBuilder.CreateIndex(
                name: "IX_Expensas_ConsorcioId",
                table: "Expensas",
                column: "ConsorcioId");

            migrationBuilder.CreateIndex(
                name: "IX_Expensas_PeriodoAnio_PeriodoMes",
                table: "Expensas",
                columns: new[] { "PeriodoAnio", "PeriodoMes" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Gastos_ConsorcioId",
                table: "Gastos",
                column: "ConsorcioId");

            migrationBuilder.CreateIndex(
                name: "IX_Pagos_ConsorcioId",
                table: "Pagos",
                column: "ConsorcioId");

            migrationBuilder.CreateIndex(
                name: "IX_UnidadesFuncionales_ConsorcioId",
                table: "UnidadesFuncionales",
                column: "ConsorcioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriasGasto");

            migrationBuilder.DropTable(
                name: "ExpensaDetalle");

            migrationBuilder.DropTable(
                name: "Gastos");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Persona");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "UnidadesFuncionales");

            migrationBuilder.DropTable(
                name: "Expensas");

            migrationBuilder.DropTable(
                name: "Consorcios");
        }
    }
}
