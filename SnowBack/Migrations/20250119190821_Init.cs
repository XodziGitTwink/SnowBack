using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SnowBack.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "D_Authentication",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    login = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    staff_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_D_Authentication", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "D_DFields_Types",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    name = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    code = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_D_DFields_Types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "D_Employees_Details",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    name = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    sname = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    mname = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    shortname = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    birth = table.Column<DateOnly>(type: "date", nullable: true),
                    code = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    phone = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    cloth = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    shoes = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    height = table.Column<string>(type: "varchar(3)", unicode: false, maxLength: 3, nullable: true),
                    breast = table.Column<string>(type: "varchar(3)", unicode: false, maxLength: 3, nullable: true),
                    waist = table.Column<string>(type: "varchar(3)", unicode: false, maxLength: 3, nullable: true),
                    hand = table.Column<string>(type: "varchar(3)", unicode: false, maxLength: 3, nullable: true),
                    head = table.Column<string>(type: "varchar(3)", unicode: false, maxLength: 3, nullable: true),
                    step = table.Column<string>(type: "varchar(3)", unicode: false, maxLength: 3, nullable: true),
                    gloves = table.Column<string>(type: "varchar(3)", unicode: false, maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_D_Employees_Details", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "D_Goods",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    code = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    name = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    type = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    remain = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    dateOn = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_D_Goods", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "D_Goods_Infra_Relations",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    good = table.Column<int>(type: "int", nullable: false),
                    element = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "D_Goods_KB",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    relatedobject = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(512)", unicode: false, maxLength: 512, nullable: false),
                    filepath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_D_Goods_KB", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "D_Goods_Types",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    name = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    code = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    type = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_D_Goods_Types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "D_Group_Task",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(512)", unicode: false, maxLength: 512, nullable: false),
                    code = table.Column<string>(type: "nchar(15)", fixedLength: true, maxLength: 15, nullable: true),
                    created = table.Column<DateTime>(type: "datetime", nullable: false),
                    creator = table.Column<int>(type: "int", nullable: true),
                    description = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_D_Group_Task", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "D_Infra_Elements",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    name = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    code = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    inventorycode = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    gps = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    type = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_D_Infra_Elements", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "D_Infra_Elements_Functions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<int>(type: "int", nullable: false),
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    name = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    code = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    objectid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_D_Infra_Elements_Functions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "D_Infra_Elements_KB",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    relatedobject = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(512)", unicode: false, maxLength: 512, nullable: false),
                    filepath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_D_Infra_Elements_KB", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "D_Infra_Elements_Parents",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    objectid = table.Column<int>(type: "int", nullable: true),
                    parentid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_D_Infra_Elements_Parents", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "D_Infra_Elements_Types",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    name = table.Column<string>(type: "varchar(512)", unicode: false, maxLength: 512, nullable: true),
                    code = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_D_Infra_Elements_Types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "D_KB_Docs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    relatedobject = table.Column<int>(type: "int", nullable: false),
                    type = table.Column<bool>(type: "bit", nullable: false),
                    name = table.Column<string>(type: "varchar(512)", unicode: false, maxLength: 512, nullable: false),
                    filepath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "D_PlannedTasks",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    parenttask = table.Column<int>(type: "int", nullable: false),
                    task = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "D_Staff",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(512)", unicode: false, maxLength: 512, nullable: false),
                    surename = table.Column<string>(type: "varchar(512)", unicode: false, maxLength: 512, nullable: false),
                    lastname = table.Column<string>(type: "varchar(512)", unicode: false, maxLength: 512, nullable: false),
                    code = table.Column<string>(type: "nchar(15)", fixedLength: true, maxLength: 15, nullable: true),
                    callId = table.Column<string>(type: "nchar(15)", fixedLength: true, maxLength: 15, nullable: true),
                    phone = table.Column<string>(type: "nchar(15)", fixedLength: true, maxLength: 15, nullable: true),
                    email = table.Column<string>(type: "varchar(512)", unicode: false, maxLength: 512, nullable: true),
                    position = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_D_Staff", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "D_Staff_KB",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    relatedobject = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(512)", unicode: false, maxLength: 512, nullable: false),
                    filepath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_D_Staff_KB", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "D_Tasks",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    code = table.Column<string>(type: "nchar(15)", fixedLength: true, maxLength: 15, nullable: true),
                    name = table.Column<string>(type: "varchar(512)", unicode: false, maxLength: 512, nullable: false),
                    position = table.Column<int>(type: "int", nullable: true),
                    duration = table.Column<TimeOnly>(type: "time", nullable: true),
                    created = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_D_Tasks", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "D_Tasks_KB",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    relatedobject = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(512)", unicode: false, maxLength: 512, nullable: false),
                    filepath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_D_Tasks_KB", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "J_Elements_States",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    element = table.Column<int>(type: "int", nullable: true),
                    user = table.Column<int>(type: "int", nullable: true),
                    statuson = table.Column<DateTime>(type: "datetime", nullable: false),
                    status = table.Column<DateTime>(type: "datetime", nullable: false),
                    logfile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    source = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "J_Employees_Moves",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Started = table.Column<DateTime>(type: "datetime", nullable: false),
                    Vehicle = table.Column<int>(type: "int", nullable: false),
                    Point = table.Column<int>(type: "int", nullable: false),
                    UserWho = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "J_Goods",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Task = table.Column<int>(type: "int", nullable: true),
                    Element = table.Column<int>(type: "int", nullable: true),
                    DateOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    Good = table.Column<int>(type: "int", nullable: true),
                    Source = table.Column<int>(type: "int", nullable: true),
                    SourceAddr = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false),
                    Destination = table.Column<int>(type: "int", nullable: true),
                    DestinationAddr = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    UserWho = table.Column<int>(type: "int", nullable: false),
                    UserWhom = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<bool>(type: "bit", nullable: false),
                    Qty = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    DelUser = table.Column<int>(type: "int", nullable: true),
                    DelDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Remain = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_J_Goods", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "J_Goods_Moved",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Task = table.Column<int>(type: "int", nullable: true),
                    Element = table.Column<int>(type: "int", nullable: true),
                    DateOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    Good = table.Column<int>(type: "int", nullable: true),
                    Source = table.Column<int>(type: "int", nullable: true),
                    SourceAddr = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Destination = table.Column<int>(type: "int", nullable: true),
                    DestinationAddr = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    UserWho = table.Column<int>(type: "int", nullable: false),
                    UserWhom = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "J_SnowGuns_Orders",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    gun_id = table.Column<int>(type: "int", nullable: false),
                    point = table.Column<int>(type: "int", nullable: true),
                    waterline = table.Column<int>(type: "int", nullable: true),
                    powerline = table.Column<int>(type: "int", nullable: true),
                    dateon = table.Column<DateOnly>(type: "date", nullable: true),
                    direction = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    main_point = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_J_SnowGuns_Orders", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "J_Tasks",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    task = table.Column<int>(type: "int", nullable: false),
                    element = table.Column<int>(type: "int", nullable: true),
                    executor = table.Column<int>(type: "int", nullable: true),
                    dateon = table.Column<DateTime>(type: "datetime", nullable: false),
                    dateoff = table.Column<DateTime>(type: "datetime", nullable: false),
                    emergency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, defaultValueSql: "((0))"),
                    creator = table.Column<int>(type: "int", nullable: true),
                    description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    isGroup = table.Column<bool>(type: "bit", nullable: false),
                    groupId = table.Column<int>(type: "int", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    isComplete = table.Column<bool>(type: "bit", nullable: true),
                    comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_J_Tasks", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "J_Transport_Fueling",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    vehicle = table.Column<int>(type: "int", nullable: false),
                    userwho = table.Column<int>(type: "int", nullable: true),
                    fueltype = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fuelamount = table.Column<double>(type: "float", nullable: true),
                    gasstation = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_J_Transport_Fueling", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "J_Transport_Rent",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    task = table.Column<int>(type: "int", nullable: true),
                    started = table.Column<DateTime>(type: "datetime", nullable: true),
                    finished = table.Column<DateTime>(type: "datetime", nullable: true),
                    element = table.Column<int>(type: "int", nullable: true),
                    point = table.Column<int>(type: "int", nullable: true),
                    executor = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    rent = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_J_Transport_Rent", x => x.id);
                });

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

            migrationBuilder.CreateTable(
                name: "D_Infra_Elements_Fields",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    name = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    code = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    type = table.Column<int>(type: "int", nullable: true),
                    dateon = table.Column<DateTime>(type: "datetime", nullable: true),
                    value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    field_type = table.Column<int>(type: "int", nullable: true),
                    element_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_D_Infra_Elements_Fields", x => x.id);
                    table.ForeignKey(
                        name: "FK_D_Infra_Elements_Fields_D_DFields_Types",
                        column: x => x.field_type,
                        principalTable: "D_DFields_Types",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "J_Staff_Assign",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    employee = table.Column<int>(type: "int", nullable: false),
                    position = table.Column<int>(type: "int", nullable: false),
                    hired = table.Column<DateOnly>(type: "date", nullable: false),
                    fired = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_J_Staff_Assign", x => x.id);
                    table.ForeignKey(
                        name: "FK_J_Staff_Assign_D_Staff",
                        column: x => x.employee,
                        principalTable: "D_Staff",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "J_Employees_Schedule",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Employee = table.Column<int>(type: "int", nullable: false),
                    Manager = table.Column<int>(type: "int", nullable: false),
                    Shift = table.Column<int>(type: "int", nullable: true),
                    Variant = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(6)", maxLength: 6, nullable: false),
                    Deviation = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_J_Employees_Schedule", x => x.id);
                    table.ForeignKey(
                        name: "FK_J_Employees_Schedule_D_Staff",
                        column: x => x.Employee,
                        principalTable: "D_Staff",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_J_Employees_Schedule_Shift",
                        column: x => x.Shift,
                        principalTable: "Shift",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_D_Infra_Elements_Fields_field_type",
                table: "D_Infra_Elements_Fields",
                column: "field_type");

            migrationBuilder.CreateIndex(
                name: "IX_J_Employees_Schedule_Employee",
                table: "J_Employees_Schedule",
                column: "Employee");

            migrationBuilder.CreateIndex(
                name: "IX_J_Employees_Schedule_Shift",
                table: "J_Employees_Schedule",
                column: "Shift");

            migrationBuilder.CreateIndex(
                name: "IX_J_Staff_Assign_employee",
                table: "J_Staff_Assign",
                column: "employee");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "D_Authentication");

            migrationBuilder.DropTable(
                name: "D_Employees_Details");

            migrationBuilder.DropTable(
                name: "D_Goods");

            migrationBuilder.DropTable(
                name: "D_Goods_Infra_Relations");

            migrationBuilder.DropTable(
                name: "D_Goods_KB");

            migrationBuilder.DropTable(
                name: "D_Goods_Types");

            migrationBuilder.DropTable(
                name: "D_Group_Task");

            migrationBuilder.DropTable(
                name: "D_Infra_Elements");

            migrationBuilder.DropTable(
                name: "D_Infra_Elements_Fields");

            migrationBuilder.DropTable(
                name: "D_Infra_Elements_Functions");

            migrationBuilder.DropTable(
                name: "D_Infra_Elements_KB");

            migrationBuilder.DropTable(
                name: "D_Infra_Elements_Parents");

            migrationBuilder.DropTable(
                name: "D_Infra_Elements_Types");

            migrationBuilder.DropTable(
                name: "D_KB_Docs");

            migrationBuilder.DropTable(
                name: "D_PlannedTasks");

            migrationBuilder.DropTable(
                name: "D_Staff_KB");

            migrationBuilder.DropTable(
                name: "D_Tasks");

            migrationBuilder.DropTable(
                name: "D_Tasks_KB");

            migrationBuilder.DropTable(
                name: "J_Elements_States");

            migrationBuilder.DropTable(
                name: "J_Employees_Moves");

            migrationBuilder.DropTable(
                name: "J_Employees_Schedule");

            migrationBuilder.DropTable(
                name: "J_Goods");

            migrationBuilder.DropTable(
                name: "J_Goods_Moved");

            migrationBuilder.DropTable(
                name: "J_SnowGuns_Orders");

            migrationBuilder.DropTable(
                name: "J_Staff_Assign");

            migrationBuilder.DropTable(
                name: "J_Tasks");

            migrationBuilder.DropTable(
                name: "J_Transport_Fueling");

            migrationBuilder.DropTable(
                name: "J_Transport_Rent");

            migrationBuilder.DropTable(
                name: "Staff_Position");

            migrationBuilder.DropTable(
                name: "D_DFields_Types");

            migrationBuilder.DropTable(
                name: "Shift");

            migrationBuilder.DropTable(
                name: "D_Staff");
        }
    }
}
