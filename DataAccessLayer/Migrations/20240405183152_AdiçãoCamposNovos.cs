using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AdiçãoCamposNovos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DATA_NASCIMENTO",
                table: "SUPPLIERS",
                type: "datetime2",
                unicode: false,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RG",
                table: "SUPPLIERS",
                type: "varchar(10)",
                unicode: false,
                maxLength: 10,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DATA_NASCIMENTO",
                table: "SUPPLIERS");

            migrationBuilder.DropColumn(
                name: "RG",
                table: "SUPPLIERS");
        }
    }
}
