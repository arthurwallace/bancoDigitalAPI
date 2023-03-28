using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bancodigital_api.Migrations
{
    /// <inheritdoc />
    public partial class changeNumeroConta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "conta",
                table: "Contas",
                newName: "numeroConta");

            migrationBuilder.AlterColumn<Guid>(
                name: "Contaid",
                table: "Movimentacoes",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "id",
                table: "Contas",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "numeroConta",
                table: "Contas",
                newName: "conta");

            migrationBuilder.AlterColumn<int>(
                name: "Contaid",
                table: "Movimentacoes",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "Contas",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT")
                .Annotation("Sqlite:Autoincrement", true);
        }
    }
}
