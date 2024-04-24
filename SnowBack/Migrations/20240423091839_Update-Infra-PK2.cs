using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SnowBack.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInfraPK2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddPrimaryKey(
                name: "PK_J_Tasks",
                table: "J_Tasks",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_D_Tasks",
                table: "D_Tasks",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_D_Staff",
                table: "D_Staff",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_D_Infra_Elements_Types",
                table: "D_Infra_Elements_Types",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_D_Infra_Elements",
                table: "D_Infra_Elements",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_J_Tasks_executor",
                table: "J_Tasks",
                column: "executor");

            migrationBuilder.CreateIndex(
                name: "IX_D_Infra_Elements_type",
                table: "D_Infra_Elements",
                column: "type");

            migrationBuilder.AddForeignKey(
                name: "fk_type_id",
                table: "D_Infra_Elements",
                column: "type",
                principalTable: "D_Infra_Elements_Types",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_executor",
                table: "J_Tasks",
                column: "executor",
                principalTable: "D_Staff",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_type_id",
                table: "D_Infra_Elements");

            migrationBuilder.DropForeignKey(
                name: "fk_executor",
                table: "J_Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_J_Tasks",
                table: "J_Tasks");

            migrationBuilder.DropIndex(
                name: "IX_J_Tasks_executor",
                table: "J_Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_D_Tasks",
                table: "D_Tasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_D_Staff",
                table: "D_Staff");

            migrationBuilder.DropPrimaryKey(
                name: "PK_D_Infra_Elements_Types",
                table: "D_Infra_Elements_Types");

            migrationBuilder.DropPrimaryKey(
                name: "PK_D_Infra_Elements",
                table: "D_Infra_Elements");

            migrationBuilder.DropIndex(
                name: "IX_D_Infra_Elements_type",
                table: "D_Infra_Elements");
        }
    }
}
