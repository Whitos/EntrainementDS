using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EntrainementDS.Migrations
{
    /// <inheritdoc />
    public partial class MigInitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "T_E_UTILISATEUR_UTI",
                schema: "public",
                columns: table => new
                {
                    UTI_ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UTI_NOM = table.Column<string>(type: "text", nullable: false),
                    UTI_PRENOM = table.Column<string>(type: "text", nullable: false),
                    UTI_NUMERORUE = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    UTI_RUE = table.Column<string>(type: "text", nullable: false),
                    UTI_CODEPOSTAL = table.Column<string>(type: "text", nullable: false),
                    UTI_VILLE = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UTI", x => x.UTI_ID);
                });

            migrationBuilder.CreateTable(
                name: "T_E_COMMANDE_COM",
                schema: "public",
                columns: table => new
                {
                    COM_ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    COM_NOMARTICLE = table.Column<string>(type: "text", nullable: false),
                    UTI_ID = table.Column<int>(type: "integer", nullable: false),
                    COM_MONTANT_INI = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    COM_NOMBREECHEANCES = table.Column<int>(type: "integer", nullable: false),
                    COM_MONTANT_TOT = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    COM_MAJORATION = table.Column<decimal>(type: "numeric(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COM", x => x.COM_ID);
                    table.ForeignKey(
                        name: "FK_COM_UTI",
                        column: x => x.UTI_ID,
                        principalSchema: "public",
                        principalTable: "T_E_UTILISATEUR_UTI",
                        principalColumn: "UTI_ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_E_COMMANDE_COM_UTI_ID",
                schema: "public",
                table: "T_E_COMMANDE_COM",
                column: "UTI_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_E_COMMANDE_COM",
                schema: "public");

            migrationBuilder.DropTable(
                name: "T_E_UTILISATEUR_UTI",
                schema: "public");
        }
    }
}
