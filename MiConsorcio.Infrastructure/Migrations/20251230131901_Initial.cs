using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiConsorcio.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ExpensaId1",
                table: "ExpensaDetalle",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExpensaDetalle_ExpensaId1",
                table: "ExpensaDetalle",
                column: "ExpensaId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpensaDetalle_Expensas_ExpensaId1",
                table: "ExpensaDetalle",
                column: "ExpensaId1",
                principalTable: "Expensas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpensaDetalle_Expensas_ExpensaId1",
                table: "ExpensaDetalle");

            migrationBuilder.DropIndex(
                name: "IX_ExpensaDetalle_ExpensaId1",
                table: "ExpensaDetalle");

            migrationBuilder.DropColumn(
                name: "ExpensaId1",
                table: "ExpensaDetalle");
        }
    }
}
