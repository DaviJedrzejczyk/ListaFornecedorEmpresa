using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AjusteTamanhoCNPJ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CNPJ",
                table: "SUPPLIERS",
                type: "varchar(18)",
                unicode: false,
                maxLength: 18,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(11)",
                oldUnicode: false,
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CNPJ",
                table: "COMPANIES",
                type: "varchar(18)",
                unicode: false,
                maxLength: 18,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(11)",
                oldUnicode: false,
                oldMaxLength: 11);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CNPJ",
                table: "SUPPLIERS",
                type: "varchar(11)",
                unicode: false,
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(18)",
                oldUnicode: false,
                oldMaxLength: 18,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CNPJ",
                table: "COMPANIES",
                type: "varchar(11)",
                unicode: false,
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(18)",
                oldUnicode: false,
                oldMaxLength: 18);
        }
    }
}
