using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SnowBack.Migrations
{
    /// <inheritdoc />
    public partial class InfraRelationsUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "typecode",
                table: "D_Infra_Elements_Fields");

            migrationBuilder.AlterColumn<int>(
                name: "elementid",
                table: "D_Infra_Elements_Functions",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "D_Infra_Elements_Functions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "field_type",
                table: "D_Infra_Elements_Fields",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "type",
                table: "D_Infra_Elements_Fields",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "D_DFields_Types",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_D_Infra_Elements_Functions",
                table: "D_Infra_Elements_Functions",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_D_Infra_Elements_Fields",
                table: "D_Infra_Elements_Fields",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_D_DFields_Types",
                table: "D_DFields_Types",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_D_Infra_Elements_Functions_elementid",
                table: "D_Infra_Elements_Functions",
                column: "elementid");

            migrationBuilder.CreateIndex(
                name: "IX_D_Infra_Elements_Fields_field_type",
                table: "D_Infra_Elements_Fields",
                column: "field_type");

            migrationBuilder.CreateIndex(
                name: "IX_D_Infra_Elements_Fields_type",
                table: "D_Infra_Elements_Fields",
                column: "type");

            migrationBuilder.AddForeignKey(
                name: "FK_D_Infra_Elements_Fields_D_DFields_Types",
                table: "D_Infra_Elements_Fields",
                column: "field_type",
                principalTable: "D_DFields_Types",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_D_Infra_Elements_Fields_D_Infra_Elements_Types",
                table: "D_Infra_Elements_Fields",
                column: "type",
                principalTable: "D_Infra_Elements_Types",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_D_Infra_Elements_Functions_D_Infra_Elements",
                table: "D_Infra_Elements_Functions",
                column: "elementid",
                principalTable: "D_Infra_Elements",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_D_Infra_Elements_Fields_D_DFields_Types",
                table: "D_Infra_Elements_Fields");

            migrationBuilder.DropForeignKey(
                name: "FK_D_Infra_Elements_Fields_D_Infra_Elements_Types",
                table: "D_Infra_Elements_Fields");

            migrationBuilder.DropForeignKey(
                name: "FK_D_Infra_Elements_Functions_D_Infra_Elements",
                table: "D_Infra_Elements_Functions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_D_Infra_Elements_Functions",
                table: "D_Infra_Elements_Functions");

            migrationBuilder.DropIndex(
                name: "IX_D_Infra_Elements_Functions_elementid",
                table: "D_Infra_Elements_Functions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_D_Infra_Elements_Fields",
                table: "D_Infra_Elements_Fields");

            migrationBuilder.DropIndex(
                name: "IX_D_Infra_Elements_Fields_field_type",
                table: "D_Infra_Elements_Fields");

            migrationBuilder.DropIndex(
                name: "IX_D_Infra_Elements_Fields_type",
                table: "D_Infra_Elements_Fields");

            migrationBuilder.DropPrimaryKey(
                name: "PK_D_DFields_Types",
                table: "D_DFields_Types");

            migrationBuilder.DropColumn(
                name: "id",
                table: "D_Infra_Elements_Functions");

            migrationBuilder.DropColumn(
                name: "field_type",
                table: "D_Infra_Elements_Fields");

            migrationBuilder.DropColumn(
                name: "type",
                table: "D_Infra_Elements_Fields");

            migrationBuilder.DropColumn(
                name: "description",
                table: "D_DFields_Types");

            migrationBuilder.AlterColumn<int>(
                name: "elementid",
                table: "D_Infra_Elements_Functions",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "typecode",
                table: "D_Infra_Elements_Fields",
                type: "varchar(15)",
                unicode: false,
                maxLength: 15,
                nullable: true);
        }
    }
}
