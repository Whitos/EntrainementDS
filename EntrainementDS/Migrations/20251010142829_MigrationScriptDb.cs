using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EntrainementDS.Migrations
{
    /// <inheritdoc />
    public partial class MigrationScriptDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UTI_RUE",
                schema: "public",
                table: "T_E_UTILISATEUR_UTI",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(10)",
                oldMaxLength: 10);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UTI_RUE",
                schema: "public",
                table: "T_E_UTILISATEUR_UTI",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
