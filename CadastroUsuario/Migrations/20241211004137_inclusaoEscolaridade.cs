using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CadastroUsuario.Migrations
{
    /// <inheritdoc />
    public partial class inclusaoEscolaridade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Escolaridade",
                table: "Usuarios");

            migrationBuilder.AddColumn<Guid>(
                name: "EscolaridadeId",
                table: "Usuarios",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Escolaridades",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escolaridades", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EscolaridadeId",
                table: "Usuarios",
                column: "EscolaridadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Escolaridades_EscolaridadeId",
                table: "Usuarios",
                column: "EscolaridadeId",
                principalTable: "Escolaridades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Escolaridades_EscolaridadeId",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "Escolaridades");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_EscolaridadeId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "EscolaridadeId",
                table: "Usuarios");

            migrationBuilder.AddColumn<int>(
                name: "Escolaridade",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
