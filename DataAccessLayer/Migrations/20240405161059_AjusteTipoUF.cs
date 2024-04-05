using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AjusteTipoUF : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UF",
                table: "COMPANIES",
                type: "int",
                unicode: false,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(2)",
                oldUnicode: false,
                oldMaxLength: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UF",
                table: "COMPANIES",
                type: "varchar(2)",
                unicode: false,
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldUnicode: false);
        }
    }
}
