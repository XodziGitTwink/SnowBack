using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SnowBack.Migrations
{
    /// <inheritdoc />
    public partial class TransoprtUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_D_Infra_Elements_D_Infra_Elements_Types",
                table: "D_Infra_Elements");

            migrationBuilder.DropForeignKey(
                name: "FK_D_Infra_Elements_Fields_D_Infra_Elements",
                table: "D_Infra_Elements_Fields");

            migrationBuilder.DropForeignKey(
                name: "FK_D_Infra_Elements_Fields_D_Infra_Elements_Types",
                table: "D_Infra_Elements_Fields");

            migrationBuilder.DropForeignKey(
                name: "FK_D_Infra_Elements_Functions_D_Infra_Elements_Types",
                table: "D_Infra_Elements_Functions");

            migrationBuilder.DropIndex(
                name: "IX_D_Infra_Elements_Functions_type",
                table: "D_Infra_Elements_Functions");

            migrationBuilder.DropIndex(
                name: "IX_D_Infra_Elements_Fields_element_id",
                table: "D_Infra_Elements_Fields");

            migrationBuilder.DropIndex(
                name: "IX_D_Infra_Elements_Fields_type",
                table: "D_Infra_Elements_Fields");

            migrationBuilder.DropIndex(
                name: "IX_D_Infra_Elements_type",
                table: "D_Infra_Elements");

            migrationBuilder.AlterColumn<DateTime>(
                name: "started",
                table: "J_Transport_Rent",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "finished",
                table: "J_Transport_Rent",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<int>(
                name: "userwho",
                table: "J_Transport_Fueling",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "started",
                table: "J_Transport_Fueling",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<int>(
                name: "point",
                table: "J_Transport_Fueling",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "executor",
                table: "J_Tasks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "J_Tasks",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "J_Tasks",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isComplete",
                table: "J_Tasks",
                type: "bit",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Shift",
                table: "J_Employees_Schedule",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)",
                oldMaxLength: 1,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Deviation",
                table: "J_Employees_Schedule",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "position",
                table: "D_Staff",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "D_Infra_Elements_Functions",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "objectid",
                table: "D_Infra_Elements_Functions",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "D_Group_Task",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar(10)",
                oldFixedLength: true,
                oldMaxLength: 10)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "creator",
                table: "D_Group_Task",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "D_Group_Task",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "staff_id",
                table: "D_Authentication",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_J_Transport_Rent",
                table: "J_Transport_Rent",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_J_Transport_Fueling",
                table: "J_Transport_Fueling",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_J_Staff_Assign",
                table: "J_Staff_Assign",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_J_Employees_Schedule",
                table: "J_Employees_Schedule",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_D_Infra_Elements_Parents",
                table: "D_Infra_Elements_Parents",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_D_Employees_Details",
                table: "D_Employees_Details",
                column: "id");

            migrationBuilder.CreateTable(
                name: "Shift",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    duration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shift", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Staff_Position",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff_Position", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_J_Staff_Assign_employee",
                table: "J_Staff_Assign",
                column: "employee");

            migrationBuilder.CreateIndex(
                name: "IX_J_Employees_Schedule_Employee",
                table: "J_Employees_Schedule",
                column: "Employee");

            migrationBuilder.CreateIndex(
                name: "IX_J_Employees_Schedule_Shift",
                table: "J_Employees_Schedule",
                column: "Shift");

            migrationBuilder.AddForeignKey(
                name: "FK_J_Employees_Schedule_D_Staff",
                table: "J_Employees_Schedule",
                column: "Employee",
                principalTable: "D_Staff",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_J_Employees_Schedule_Shift",
                table: "J_Employees_Schedule",
                column: "Shift",
                principalTable: "Shift",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_J_Staff_Assign_D_Staff",
                table: "J_Staff_Assign",
                column: "employee",
                principalTable: "D_Staff",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_J_Employees_Schedule_D_Staff",
                table: "J_Employees_Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_J_Employees_Schedule_Shift",
                table: "J_Employees_Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_J_Staff_Assign_D_Staff",
                table: "J_Staff_Assign");

            migrationBuilder.DropTable(
                name: "Shift");

            migrationBuilder.DropTable(
                name: "Staff_Position");

            migrationBuilder.DropPrimaryKey(
                name: "PK_J_Transport_Rent",
                table: "J_Transport_Rent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_J_Transport_Fueling",
                table: "J_Transport_Fueling");

            migrationBuilder.DropPrimaryKey(
                name: "PK_J_Staff_Assign",
                table: "J_Staff_Assign");

            migrationBuilder.DropIndex(
                name: "IX_J_Staff_Assign_employee",
                table: "J_Staff_Assign");

            migrationBuilder.DropPrimaryKey(
                name: "PK_J_Employees_Schedule",
                table: "J_Employees_Schedule");

            migrationBuilder.DropIndex(
                name: "IX_J_Employees_Schedule_Employee",
                table: "J_Employees_Schedule");

            migrationBuilder.DropIndex(
                name: "IX_J_Employees_Schedule_Shift",
                table: "J_Employees_Schedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_D_Infra_Elements_Parents",
                table: "D_Infra_Elements_Parents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_D_Employees_Details",
                table: "D_Employees_Details");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "J_Tasks");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "J_Tasks");

            migrationBuilder.DropColumn(
                name: "isComplete",
                table: "J_Tasks");

            migrationBuilder.DropColumn(
                name: "Deviation",
                table: "J_Employees_Schedule");

            migrationBuilder.DropColumn(
                name: "position",
                table: "D_Staff");

            migrationBuilder.DropColumn(
                name: "objectid",
                table: "D_Infra_Elements_Functions");

            migrationBuilder.DropColumn(
                name: "creator",
                table: "D_Group_Task");

            migrationBuilder.DropColumn(
                name: "description",
                table: "D_Group_Task");

            migrationBuilder.DropColumn(
                name: "staff_id",
                table: "D_Authentication");

            migrationBuilder.AlterColumn<DateTime>(
                name: "started",
                table: "J_Transport_Rent",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "finished",
                table: "J_Transport_Rent",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "userwho",
                table: "J_Transport_Fueling",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "started",
                table: "J_Transport_Fueling",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "point",
                table: "J_Transport_Fueling",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "executor",
                table: "J_Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Shift",
                table: "J_Employees_Schedule",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "id",
                table: "D_Infra_Elements_Functions",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "id",
                table: "D_Group_Task",
                type: "nchar(10)",
                fixedLength: true,
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_D_Infra_Elements_Functions_type",
                table: "D_Infra_Elements_Functions",
                column: "type");

            migrationBuilder.CreateIndex(
                name: "IX_D_Infra_Elements_Fields_element_id",
                table: "D_Infra_Elements_Fields",
                column: "element_id");

            migrationBuilder.CreateIndex(
                name: "IX_D_Infra_Elements_Fields_type",
                table: "D_Infra_Elements_Fields",
                column: "type");

            migrationBuilder.CreateIndex(
                name: "IX_D_Infra_Elements_type",
                table: "D_Infra_Elements",
                column: "type");

            migrationBuilder.AddForeignKey(
                name: "FK_D_Infra_Elements_D_Infra_Elements_Types",
                table: "D_Infra_Elements",
                column: "type",
                principalTable: "D_Infra_Elements_Types",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_D_Infra_Elements_Fields_D_Infra_Elements",
                table: "D_Infra_Elements_Fields",
                column: "element_id",
                principalTable: "D_Infra_Elements",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_D_Infra_Elements_Fields_D_Infra_Elements_Types",
                table: "D_Infra_Elements_Fields",
                column: "type",
                principalTable: "D_Infra_Elements_Types",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_D_Infra_Elements_Functions_D_Infra_Elements_Types",
                table: "D_Infra_Elements_Functions",
                column: "type",
                principalTable: "D_Infra_Elements_Types",
                principalColumn: "id");
        }
    }
}
