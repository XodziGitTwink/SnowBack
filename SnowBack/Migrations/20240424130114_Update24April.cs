using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SnowBack.Migrations
{
    /// <inheritdoc />
    public partial class Update24April : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_D_Infra_Elements_Functions_D_Infra_Elements",
                table: "D_Infra_Elements_Functions");

            migrationBuilder.RenameColumn(
                name: "elementid",
                table: "D_Infra_Elements_Functions",
                newName: "type");

            migrationBuilder.RenameIndex(
                name: "IX_D_Infra_Elements_Functions_elementid",
                table: "D_Infra_Elements_Functions",
                newName: "IX_D_Infra_Elements_Functions_type");

            migrationBuilder.AddForeignKey(
                name: "FK_D_Infra_Elements_Functions_D_Infra_Elements_Types",
                table: "D_Infra_Elements_Functions",
                column: "type",
                principalTable: "D_Infra_Elements_Types",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_D_Infra_Elements_Functions_D_Infra_Elements_Types",
                table: "D_Infra_Elements_Functions");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "D_Infra_Elements_Functions",
                newName: "elementid");

            migrationBuilder.RenameIndex(
                name: "IX_D_Infra_Elements_Functions_type",
                table: "D_Infra_Elements_Functions",
                newName: "IX_D_Infra_Elements_Functions_elementid");

            migrationBuilder.AddForeignKey(
                name: "FK_D_Infra_Elements_Functions_D_Infra_Elements",
                table: "D_Infra_Elements_Functions",
                column: "elementid",
                principalTable: "D_Infra_Elements",
                principalColumn: "id");
        }
    }
}
