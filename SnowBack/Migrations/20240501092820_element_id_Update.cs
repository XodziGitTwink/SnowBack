using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SnowBack.Migrations
{
    /// <inheritdoc />
    public partial class element_id_Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "element_id",
                table: "D_Infra_Elements_Fields",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_D_Infra_Elements_Fields_element_id",
                table: "D_Infra_Elements_Fields",
                column: "element_id");

            migrationBuilder.AddForeignKey(
                name: "FK_D_Infra_Elements_Fields_D_Infra_Elements",
                table: "D_Infra_Elements_Fields",
                column: "element_id",
                principalTable: "D_Infra_Elements",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_D_Infra_Elements_Fields_D_Infra_Elements",
                table: "D_Infra_Elements_Fields");

            migrationBuilder.DropIndex(
                name: "IX_D_Infra_Elements_Fields_element_id",
                table: "D_Infra_Elements_Fields");

            migrationBuilder.DropColumn(
                name: "element_id",
                table: "D_Infra_Elements_Fields");
        }
    }
}
