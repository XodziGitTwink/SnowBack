using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SnowBack.Models;

public partial class SnowmansContext : DbContext
{
    public SnowmansContext()
    {
    }

    public SnowmansContext(DbContextOptions<SnowmansContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DAuthentication> DAuthentications { get; set; }

    public virtual DbSet<DDfieldsType> DDfieldsTypes { get; set; }

    public virtual DbSet<DEmployeesDetail> DEmployeesDetails { get; set; }

    public virtual DbSet<DGood> DGoods { get; set; }

    public virtual DbSet<DGoodsInfraRelation> DGoodsInfraRelations { get; set; }

    public virtual DbSet<DGoodsType> DGoodsTypes { get; set; }

    public virtual DbSet<DGroupTask> DGroupTasks { get; set; }

    public virtual DbSet<DInfraElement> DInfraElements { get; set; }

    public virtual DbSet<DInfraElementsField> DInfraElementsFields { get; set; }

    public virtual DbSet<DInfraElementsFunction> DInfraElementsFunctions { get; set; }

    public virtual DbSet<DInfraElementsKb> DInfraElementsKbs { get; set; }

    public virtual DbSet<DInfraElementsParent> DInfraElementsParents { get; set; }

    public virtual DbSet<DInfraElementsType> DInfraElementsTypes { get; set; }

    public virtual DbSet<DKbDoc> DKbDocs { get; set; }

    public virtual DbSet<DPlannedTask> DPlannedTasks { get; set; }

    public virtual DbSet<DRack> DRacks { get; set; }

    public virtual DbSet<DRoom> DRooms { get; set; }

    public virtual DbSet<DShelf> DShelfs { get; set; }

    public virtual DbSet<DStaff> DStaffs { get; set; }

    public virtual DbSet<DStaffKb> DStaffKbs { get; set; }

    public virtual DbSet<DStock> DStocks { get; set; }

    public virtual DbSet<DTask> DTasks { get; set; }

    public virtual DbSet<DTasksKb> DTasksKbs { get; set; }

    public virtual DbSet<DTMC> DTmcs { get; set; }

    public virtual DbSet<DTMCFunction> DTmcFunctions { get; set; }

    public virtual DbSet<DTMCType> DTmcTypes { get; set; }

    public virtual DbSet<JElementsState> JElementsStates { get; set; }

    public virtual DbSet<JEmployeesMove> JEmployeesMoves { get; set; }

    public virtual DbSet<JEmployeesSchedule> JEmployeesSchedules { get; set; }

    public virtual DbSet<JGoodsMoved> JGoodsMoveds { get; set; }

    public virtual DbSet<JSnowGunsOrder> JSnowGunsOrders { get; set; }

    public virtual DbSet<JStaffAssign> JStaffAssigns { get; set; }

    public virtual DbSet<JTask> JTasks { get; set; }

    public virtual DbSet<JTransportFueling> JTransportFuelings { get; set; }

    public virtual DbSet<JTransportRent> JTransportRents { get; set; }

    public virtual DbSet<Shift> Shifts { get; set; }

    public virtual DbSet<StaffPosition> StaffPositions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-V09KE4L;Initial Catalog=Snowmans;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DAuthentication>(entity =>
        {
            entity.ToTable("D_Authentication");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.StaffId).HasColumnName("staff_id");
        });

        modelBuilder.Entity<DDfieldsType>(entity =>
        {
            entity.ToTable("D_DFields_Types");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.Description)
                .HasMaxLength(512)
                .HasColumnName("description");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("guid");
            entity.Property(e => e.Name)
                .HasMaxLength(512)
                .HasColumnName("name");
        });

        modelBuilder.Entity<DEmployeesDetail>(entity =>
        {
            entity.ToTable("D_Employees_Details");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Birth).HasColumnName("birth");
            entity.Property(e => e.Breast)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("breast");
            entity.Property(e => e.Cloth)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("cloth");
            entity.Property(e => e.Code)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.Gloves)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("gloves");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("guid");
            entity.Property(e => e.Hand)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("hand");
            entity.Property(e => e.Head)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("head");
            entity.Property(e => e.Height)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("height");
            entity.Property(e => e.Mname)
                .HasMaxLength(512)
                .HasColumnName("mname");
            entity.Property(e => e.Name)
                .HasMaxLength(512)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Shoes)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("shoes");
            entity.Property(e => e.Shortname)
                .HasMaxLength(512)
                .HasColumnName("shortname");
            entity.Property(e => e.Sname)
                .HasMaxLength(512)
                .HasColumnName("sname");
            entity.Property(e => e.Step)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("step");
            entity.Property(e => e.Waist)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("waist");
        });

        modelBuilder.Entity<DGood>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("D_Goods");

            entity.Property(e => e.Code)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("guid");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(512)
                .HasColumnName("name");
            entity.Property(e => e.Type).HasColumnName("type");
        });

        modelBuilder.Entity<DGoodsInfraRelation>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("D_Goods_Infra_Relations");

            entity.Property(e => e.Element).HasColumnName("element");
            entity.Property(e => e.Good).HasColumnName("good");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("guid");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
        });

        modelBuilder.Entity<DGoodsType>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("D_Goods_Types");

            entity.Property(e => e.Code)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("guid");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(512)
                .HasColumnName("name");
            entity.Property(e => e.Type)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("type");
        });

        modelBuilder.Entity<DGroupTask>(entity =>
        {
            entity.ToTable("D_Group_Task");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(15)
                .IsFixedLength()
                .HasColumnName("code");
            entity.Property(e => e.Created)
                .HasColumnType("datetime")
                .HasColumnName("created");
            entity.Property(e => e.Creator).HasColumnName("creator");
            entity.Property(e => e.Description)
                .HasMaxLength(512)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(512)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<DInfraElement>(entity =>
        {
            entity.ToTable("D_Infra_Elements");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Gps)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("gps");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("guid");
            entity.Property(e => e.Inventorycode)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("inventorycode");
            entity.Property(e => e.Name)
                .HasMaxLength(512)
                .HasColumnName("name");
            entity.Property(e => e.Type).HasColumnName("type");

            entity.HasOne(d => d.TypeNavigation).WithMany(p => p.DInfraElements)
                .HasForeignKey(d => d.Type)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_D_Infra_Elements_D_Infra_Elements_Types");
        });

        modelBuilder.Entity<DInfraElementsField>(entity =>
        {
            entity.ToTable("D_Infra_Elements_Fields");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.Dateon)
                .HasColumnType("datetime")
                .HasColumnName("dateon");
            entity.Property(e => e.ElementId).HasColumnName("element_id");
            entity.Property(e => e.FieldType).HasColumnName("field_type");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("guid");
            entity.Property(e => e.Name)
                .HasMaxLength(512)
                .HasColumnName("name");
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.Value).HasColumnName("value");

            entity.HasOne(d => d.Element).WithMany(p => p.DInfraElementsFields)
                .HasForeignKey(d => d.ElementId)
                .HasConstraintName("FK_D_Infra_Elements_Fields_D_Infra_Elements");

            entity.HasOne(d => d.FieldTypeNavigation).WithMany(p => p.DInfraElementsFields)
                .HasForeignKey(d => d.FieldType)
                .HasConstraintName("FK_D_Infra_Elements_Fields_D_DFields_Types");

            entity.HasOne(d => d.TypeNavigation).WithMany(p => p.DInfraElementsFields)
                .HasForeignKey(d => d.Type)
                .HasConstraintName("FK_D_Infra_Elements_Fields_D_Infra_Elements_Types");
        });

        modelBuilder.Entity<DInfraElementsFunction>(entity =>
        {
            entity.ToTable("D_Infra_Elements_Functions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("guid");
            entity.Property(e => e.Name)
                .HasMaxLength(512)
                .HasColumnName("name");
            entity.Property(e => e.Objectid).HasColumnName("objectid");
            entity.Property(e => e.Type).HasColumnName("type");

            entity.HasOne(d => d.Object).WithMany(p => p.DInfraElementsFunctions)
                .HasForeignKey(d => d.Objectid)
                .HasConstraintName("FK_D_Infra_Elements_Functions_D_Infra_Elements");

            entity.HasOne(d => d.TypeNavigation).WithMany(p => p.DInfraElementsFunctions)
                .HasForeignKey(d => d.Type)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_D_Infra_Elements_Functions_D_Infra_Elements_Types");
        });

        modelBuilder.Entity<DInfraElementsKb>(entity =>
        {
            entity.ToTable("D_Infra_Elements_KB");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Filepath).HasColumnName("filepath");
            entity.Property(e => e.Guid).HasColumnName("guid");
            entity.Property(e => e.Name)
                .HasMaxLength(512)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Relatedobject).HasColumnName("relatedobject");
        });

        modelBuilder.Entity<DInfraElementsParent>(entity =>
        {
            entity.ToTable("D_Infra_Elements_Parents");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("guid");
            entity.Property(e => e.Objectid).HasColumnName("objectid");
            entity.Property(e => e.Parentid).HasColumnName("parentid");
        });

        modelBuilder.Entity<DInfraElementsType>(entity =>
        {
            entity.ToTable("D_Infra_Elements_Types");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.Description)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Guid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("guid");
            entity.Property(e => e.Name)
                .HasMaxLength(512)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<DKbDoc>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("D_KB_Docs");

            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Filepath).HasColumnName("filepath");
            entity.Property(e => e.Guid).HasColumnName("guid");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(512)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Relatedobject).HasColumnName("relatedobject");
            entity.Property(e => e.Type).HasColumnName("type");
        });

        modelBuilder.Entity<DPlannedTask>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("D_PlannedTasks");

            entity.Property(e => e.Guid).HasColumnName("guid");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Parenttask).HasColumnName("parenttask");
            entity.Property(e => e.Task).HasColumnName("task");
        });

        modelBuilder.Entity<DRack>(entity =>
        {
            entity.ToTable("D_Racks");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Guid).HasColumnName("guid");
            entity.Property(e => e.RackDescription).HasColumnName("rackDescription");
            entity.Property(e => e.RackName)
                .HasMaxLength(512)
                .HasColumnName("rackName");
            entity.Property(e => e.RoomId).HasColumnName("roomId");
        });

        modelBuilder.Entity<DRoom>(entity =>
        {
            entity.ToTable("D_Rooms");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Guid).HasColumnName("guid");
            entity.Property(e => e.RoomDescription).HasColumnName("roomDescription");
            entity.Property(e => e.RoomName)
                .HasMaxLength(512)
                .HasColumnName("roomName");
            entity.Property(e => e.StockId).HasColumnName("stockId");
        });

        modelBuilder.Entity<DShelf>(entity =>
        {
            entity.ToTable("D_Shelfs");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Guid).HasColumnName("guid");
            entity.Property(e => e.RackId).HasColumnName("rackId");
            entity.Property(e => e.ShelfDiscription).HasColumnName("shelfDiscription");
            entity.Property(e => e.ShelfName)
                .HasMaxLength(512)
                .HasColumnName("shelfName");
        });

        modelBuilder.Entity<DStaff>(entity =>
        {
            entity.ToTable("D_Staff");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CallId)
                .HasMaxLength(15)
                .IsFixedLength()
                .HasColumnName("callId");
            entity.Property(e => e.Code)
                .HasMaxLength(15)
                .IsFixedLength()
                .HasColumnName("code");
            entity.Property(e => e.Email)
                .HasMaxLength(512)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Lastname)
                .HasMaxLength(512)
                .IsUnicode(false)
                .HasColumnName("lastname");
            entity.Property(e => e.Name)
                .HasMaxLength(512)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsFixedLength()
                .HasColumnName("phone");
            entity.Property(e => e.Position).HasColumnName("position");
            entity.Property(e => e.Surename)
                .HasMaxLength(512)
                .IsUnicode(false)
                .HasColumnName("surename");
        });

        modelBuilder.Entity<DStaffKb>(entity =>
        {
            entity.ToTable("D_Staff_KB");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Filepath).HasColumnName("filepath");
            entity.Property(e => e.Guid).HasColumnName("guid");
            entity.Property(e => e.Name)
                .HasMaxLength(512)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Relatedobject).HasColumnName("relatedobject");
        });

        modelBuilder.Entity<DStock>(entity =>
        {
            entity.ToTable("D_Stocks");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Guid).HasColumnName("guid");
            entity.Property(e => e.StockDesc).HasColumnName("stockDesc");
            entity.Property(e => e.StockName)
                .HasMaxLength(512)
                .HasColumnName("stockName");
        });

        modelBuilder.Entity<DTask>(entity =>
        {
            entity.ToTable("D_Tasks");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(15)
                .IsFixedLength()
                .HasColumnName("code");
            entity.Property(e => e.Created)
                .HasColumnType("datetime")
                .HasColumnName("created");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.Guid).HasColumnName("guid");
            entity.Property(e => e.Name)
                .HasMaxLength(512)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Position).HasColumnName("position");
        });

        modelBuilder.Entity<DTasksKb>(entity =>
        {
            entity.ToTable("D_Tasks_KB");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Filepath).HasColumnName("filepath");
            entity.Property(e => e.Guid).HasColumnName("guid");
            entity.Property(e => e.Name)
                .HasMaxLength(512)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Relatedobject).HasColumnName("relatedobject");
        });

        modelBuilder.Entity<DTmc>(entity =>
        {
            entity.ToTable("D_TMC");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.FunctId).HasColumnName("functId");
            entity.Property(e => e.Guid).HasColumnName("guid");
            entity.Property(e => e.Inventorycode)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("inventorycode");
            entity.Property(e => e.Name)
                .HasMaxLength(512)
                .HasColumnName("name");
            entity.Property(e => e.ShelfId).HasColumnName("shelfId");
            entity.Property(e => e.TaskId).HasColumnName("taskId");
            entity.Property(e => e.TypeId).HasColumnName("typeId");
            entity.Property(e => e.UserId).HasColumnName("userId");
        });

        modelBuilder.Entity<DTmcFunction>(entity =>
        {
            entity.ToTable("D_TMC_Functions");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Guid).HasColumnName("guid");
            entity.Property(e => e.Name)
                .HasMaxLength(512)
                .HasColumnName("name");
            entity.Property(e => e.TypeId).HasColumnName("typeId");
        });

        modelBuilder.Entity<DTmcType>(entity =>
        {
            entity.ToTable("D_TMC_Types");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Guid).HasColumnName("guid");
            entity.Property(e => e.Name)
                .HasMaxLength(512)
                .HasColumnName("name");
        });

        modelBuilder.Entity<JElementsState>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("J_Elements_States");

            entity.Property(e => e.Element).HasColumnName("element");
            entity.Property(e => e.Guid).HasColumnName("guid");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Logfile).HasColumnName("logfile");
            entity.Property(e => e.Source).HasColumnName("source");
            entity.Property(e => e.Status)
                .HasColumnType("datetime")
                .HasColumnName("status");
            entity.Property(e => e.Statuson)
                .HasColumnType("datetime")
                .HasColumnName("statuson");
            entity.Property(e => e.User).HasColumnName("user");
        });

        modelBuilder.Entity<JEmployeesMove>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("J_Employees_Moves");

            entity.Property(e => e.Guid).HasColumnName("guid");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Started).HasColumnType("datetime");
        });

        modelBuilder.Entity<JEmployeesSchedule>(entity =>
        {
            entity.ToTable("J_Employees_Schedule");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Guid).HasColumnName("guid");
            entity.Property(e => e.Type).HasMaxLength(6);
            entity.Property(e => e.Variant).HasMaxLength(4);

            entity.HasOne(d => d.EmployeeNavigation).WithMany(p => p.JEmployeesSchedules)
                .HasForeignKey(d => d.Employee)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_J_Employees_Schedule_D_Staff");

            entity.HasOne(d => d.ShiftNavigation).WithMany(p => p.JEmployeesSchedules)
                .HasForeignKey(d => d.Shift)
                .HasConstraintName("FK_J_Employees_Schedule_Shift");
        });

        modelBuilder.Entity<JGoodsMoved>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("J_Goods_Moved");

            entity.Property(e => e.DateOn).HasColumnType("datetime");
            entity.Property(e => e.DestinationAddr).HasMaxLength(15);
            entity.Property(e => e.Guid).HasColumnName("guid");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.SourceAddr).HasMaxLength(15);
        });

        modelBuilder.Entity<JSnowGunsOrder>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("J_SnowGuns_Orders");

            entity.Property(e => e.Code)
                .HasMaxLength(15)
                .IsFixedLength()
                .HasColumnName("code");
            entity.Property(e => e.Dateon).HasColumnName("dateon");
            entity.Property(e => e.DayOrder).HasColumnName("dayOrder");
            entity.Property(e => e.Guid).HasColumnName("guid");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Nightorder).HasColumnName("nightorder");
            entity.Property(e => e.Point)
                .HasMaxLength(15)
                .IsFixedLength()
                .HasColumnName("point");
            entity.Property(e => e.Powerline).HasColumnName("powerline");
            entity.Property(e => e.Waterline).HasColumnName("waterline");
        });

        modelBuilder.Entity<JStaffAssign>(entity =>
        {
            entity.ToTable("J_Staff_Assign");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Employee).HasColumnName("employee");
            entity.Property(e => e.Fired).HasColumnName("fired");
            entity.Property(e => e.Guid).HasColumnName("guid");
            entity.Property(e => e.Hired).HasColumnName("hired");
            entity.Property(e => e.Position).HasColumnName("position");

            entity.HasOne(d => d.EmployeeNavigation).WithMany(p => p.JStaffAssigns)
                .HasForeignKey(d => d.Employee)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_J_Staff_Assign_D_Staff");
        });

        modelBuilder.Entity<JTask>(entity =>
        {
            entity.ToTable("J_Tasks");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.Creator).HasColumnName("creator");
            entity.Property(e => e.Dateoff)
                .HasColumnType("datetime")
                .HasColumnName("dateoff");
            entity.Property(e => e.Dateon)
                .HasColumnType("datetime")
                .HasColumnName("dateon");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .HasColumnName("description");
            entity.Property(e => e.Element).HasColumnName("element");
            entity.Property(e => e.Emergency)
                .HasMaxLength(10)
                .HasDefaultValueSql("((0))")
                .HasColumnName("emergency");
            entity.Property(e => e.Executor).HasColumnName("executor");
            entity.Property(e => e.GroupId).HasColumnName("groupId");
            entity.Property(e => e.Guid).HasColumnName("guid");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.IsComplete).HasColumnName("isComplete");
            entity.Property(e => e.IsGroup).HasColumnName("isGroup");
            entity.Property(e => e.Task).HasColumnName("task");
        });

        modelBuilder.Entity<JTransportFueling>(entity =>
        {
            entity.ToTable("J_Transport_Fueling");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fuelamount).HasColumnName("fuelamount");
            entity.Property(e => e.Fueltype).HasColumnName("fueltype");
            entity.Property(e => e.Gasstation).HasColumnName("gasstation");
            entity.Property(e => e.Guid).HasColumnName("guid");
            entity.Property(e => e.Userwho).HasColumnName("userwho");
            entity.Property(e => e.Vehicle).HasColumnName("vehicle");
        });

        modelBuilder.Entity<JTransportRent>(entity =>
        {
            entity.ToTable("J_Transport_Rent");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Element).HasColumnName("element");
            entity.Property(e => e.Executor).HasColumnName("executor");
            entity.Property(e => e.Finished)
                .HasColumnType("datetime")
                .HasColumnName("finished");
            entity.Property(e => e.Guid).HasColumnName("guid");
            entity.Property(e => e.Point).HasColumnName("point");
            entity.Property(e => e.Rent).HasColumnName("rent");
            entity.Property(e => e.Started)
                .HasColumnType("datetime")
                .HasColumnName("started");
            entity.Property(e => e.Task).HasColumnName("task");
        });

        modelBuilder.Entity<Shift>(entity =>
        {
            entity.ToTable("Shift");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<StaffPosition>(entity =>
        {
            entity.ToTable("Staff_Position");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
