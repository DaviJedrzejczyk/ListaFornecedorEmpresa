using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class CorrecaoDeCampos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DATA_NASCIMENTO",
                table: "SUPPLIERS",
                newName: "BIRTH_DATE");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BIRTH_DATE",
                table: "SUPPLIERS",
                newName: "DATA_NASCIMENTO");
        }
    }
}
