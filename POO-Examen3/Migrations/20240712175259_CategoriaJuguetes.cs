using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace POO_Examen3.Migrations
{
    /// <inheritdoc />
    public partial class CategoriaJuguetes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Toys",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Toys_CategoryId",
                table: "Toys",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Toys_CategoryToys_CategoryId",
                table: "Toys",
                column: "CategoryId",
                principalTable: "CategoryToys",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Toys_CategoryToys_CategoryId",
                table: "Toys");

            migrationBuilder.DropIndex(
                name: "IX_Toys_CategoryId",
                table: "Toys");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Toys");
        }
    }
}
