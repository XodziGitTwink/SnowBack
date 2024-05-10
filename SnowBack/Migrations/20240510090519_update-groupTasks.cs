using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SnowBack.Migrations
{
    /// <inheritdoc />
    public partial class updategroupTasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_executor",
                table: "J_Tasks");

            migrationBuilder.DropIndex(
                name: "IX_J_Tasks_executor",
                table: "J_Tasks");

            migrationBuilder.DropColumn(
                name: "type",
                table: "D_Tasks");

            migrationBuilder.DropColumn(
                name: "guid",
                table: "D_Staff");

            migrationBuilder.AlterColumn<string>(
                name: "emergency",
                table: "J_Tasks",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValueSql: "((0))",
                oldClrType: typeof(string),
                oldType: "nvarchar(1)",
                oldMaxLength: 1,
                oldDefaultValueSql: "((0))");

            migrationBuilder.AlterColumn<int>(
                name: "creator",
                table: "J_Tasks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "J_Tasks",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "groupId",
                table: "J_Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isGroup",
                table: "J_Tasks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<Guid>(
                name: "guid",
                table: "D_Tasks",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateTable(
                name: "D_Group_Task",
                columns: table => new
                {
                    id = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false),
                    name = table.Column<string>(type: "varchar(512)", unicode: false, maxLength: 512, nullable: false),
                    code = table.Column<string>(type: "nchar(15)", fixedLength: true, maxLength: 15, nullable: true),
                    created = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_D_Group_Task", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "D_Group_Task");

            migrationBuilder.DropColumn(
                name: "description",
                table: "J_Tasks");

            migrationBuilder.DropColumn(
                name: "groupId",
                table: "J_Tasks");

            migrationBuilder.DropColumn(
                name: "isGroup",
                table: "J_Tasks");

            migrationBuilder.AlterColumn<string>(
                name: "emergency",
                table: "J_Tasks",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: false,
                defaultValueSql: "((0))",
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldDefaultValueSql: "((0))");

            migrationBuilder.AlterColumn<int>(
                name: "creator",
                table: "J_Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "guid",
                table: "D_Tasks",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "type",
                table: "D_Tasks",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "guid",
                table: "D_Staff",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_J_Tasks_executor",
                table: "J_Tasks",
                column: "executor");

            migrationBuilder.AddForeignKey(
                name: "fk_executor",
                table: "J_Tasks",
                column: "executor",
                principalTable: "D_Staff",
                principalColumn: "id");
        }
    }
}
