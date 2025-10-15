using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntrainementDS.Migrations
{
    /// <inheritdoc />
    public partial class DbMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "COM_MONTANT",
                schema: "public",
                table: "T_E_COMMANDE_COM",
                newName: "COM_NOMBREECHEANCES");

            migrationBuilder.AddColumn<decimal>(
                name: "COM_MAJORATION",
                schema: "public",
                table: "T_E_COMMANDE_COM",
                type: "numeric(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "COM_MONTANT_INI",
                schema: "public",
                table: "T_E_COMMANDE_COM",
                type: "numeric(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "COM_MONTANT_TOT",
                schema: "public",
                table: "T_E_COMMANDE_COM",
                type: "numeric(10,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "COM_MAJORATION",
                schema: "public",
                table: "T_E_COMMANDE_COM");

            migrationBuilder.DropColumn(
                name: "COM_MONTANT_INI",
                schema: "public",
                table: "T_E_COMMANDE_COM");

            migrationBuilder.DropColumn(
                name: "COM_MONTANT_TOT",
                schema: "public",
                table: "T_E_COMMANDE_COM");

            migrationBuilder.RenameColumn(
                name: "COM_NOMBREECHEANCES",
                schema: "public",
                table: "T_E_COMMANDE_COM",
                newName: "COM_MONTANT");
        }
    }
}
