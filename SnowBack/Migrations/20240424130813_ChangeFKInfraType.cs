using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SnowBack.Migrations
{
    /// <inheritdoc />
    public partial class ChangeFKInfraType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_type_id",
                table: "D_Infra_Elements");

            migrationBuilder.DropColumn(
                name: "type",
                table: "D_Infra_Elements_Types");

            migrationBuilder.AddForeignKey(
                name: "FK_D_Infra_Elements_D_Infra_Elements_Types",
                table: "D_Infra_Elements",
                column: "type",
                principalTable: "D_Infra_Elements_Types",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_D_Infra_Elements_D_Infra_Elements_Types",
                table: "D_Infra_Elements");

            migrationBuilder.AddColumn<string>(
                name: "type",
                table: "D_Infra_Elements_Types",
                type: "varchar(max)",
                unicode: false,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_type_id",
                table: "D_Infra_Elements",
                column: "type",
                principalTable: "D_Infra_Elements_Types",
                principalColumn: "id");
        }
    }
}
