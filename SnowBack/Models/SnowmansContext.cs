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

    public virtual DbSet<DInfraElementsParent> DInfraElementsParents { get; set; }

    public virtual DbSet<DInfraElementsType> DInfraElementsTypes { get; set; }

    public virtual DbSet<DKbDoc> DKbDocs { get; set; }

    public virtual DbSet<DPlannedTask> DPlannedTasks { get; set; }

    public virtual DbSet<DStaff> DStaffs { get; set; }

    public virtual DbSet<DTask> DTasks { get; set; }

    public virtual DbSet<JElementsState> JElementsStates { get; set; }

    public virtual DbSet<JEmployeesMove> JEmployeesMoves { get; set; }

    public virtual DbSet<JEmployeesSchedule> JEmployeesSchedules { get; set; }

    public virtual DbSet<JGoodsMoved> JGoodsMoveds { get; set; }

    public virtual DbSet<JSnowGunsOrder> JSnowGunsOrders { get; set; }

    public virtual DbSet<JStaffAssign> JStaffAssigns { get; set; }

    public virtual DbSet<JTask> JTasks { get; set; }

    public virtual DbSet<JTransportFueling> JTransportFuelings { get; set; }

    public virtual DbSet<JTransportRent> JTransportRents { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-KRSLVHM;Initial Catalog=Snowmans;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;");

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
            entity
                .HasNoKey()
                .ToTable("D_Employees_Details");

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
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
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


            entity.HasOne(d => d.FieldTypeNavigation).WithMany(p => p.DInfraElementsFields)
                .HasForeignKey(d => d.FieldType)
                .HasConstraintName("FK_D_Infra_Elements_Fields_D_DFields_Types");
        });

        modelBuilder.Entity<DInfraElementsFunction>(entity =>
        {
            entity.ToTable("D_Infra_Elements_Functions");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
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
            entity.Property(e => e.Type)
                .ValueGeneratedOnAdd()
                .HasColumnName("type");

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
            entity.Property(e => e.Surename)
                .HasMaxLength(512)
                .IsUnicode(false)
                .HasColumnName("surename");
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
            entity
                .HasNoKey()
                .ToTable("J_Employees_Schedule");

            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Guid).HasColumnName("guid");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Shift).HasMaxLength(1);
            entity.Property(e => e.Type).HasMaxLength(6);
            entity.Property(e => e.Variant).HasMaxLength(4);
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
            entity
                .HasNoKey()
                .ToTable("J_Staff_Assign");

            entity.Property(e => e.Employee).HasColumnName("employee");
            entity.Property(e => e.Fired).HasColumnName("fired");
            entity.Property(e => e.Guid).HasColumnName("guid");
            entity.Property(e => e.Hired).HasColumnName("hired");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Position).HasColumnName("position");
        });

        modelBuilder.Entity<JTask>(entity =>
        {
            entity.ToTable("J_Tasks");

            entity.Property(e => e.Id).HasColumnName("id");
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
            entity.Property(e => e.IsGroup).HasColumnName("isGroup");
            entity.Property(e => e.Task).HasColumnName("task");
        });

        modelBuilder.Entity<JTransportFueling>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("J_Transport_Fueling");

            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Good).HasColumnName("good");
            entity.Property(e => e.Guid).HasColumnName("guid");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Point).HasColumnName("point");
            entity.Property(e => e.Started)
                .HasColumnType("datetime")
                .HasColumnName("started");
            entity.Property(e => e.Task).HasColumnName("task");
            entity.Property(e => e.Userwho).HasColumnName("userwho");
            entity.Property(e => e.Vehicle).HasColumnName("vehicle");
        });

        modelBuilder.Entity<JTransportRent>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("J_Transport_Rent");

            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Element).HasColumnName("element");
            entity.Property(e => e.Executor).HasColumnName("executor");
            entity.Property(e => e.Finished)
                .HasColumnType("datetime")
                .HasColumnName("finished");
            entity.Property(e => e.Guid).HasColumnName("guid");
            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Point).HasColumnName("point");
            entity.Property(e => e.Started)
                .HasColumnType("datetime")
                .HasColumnName("started");
            entity.Property(e => e.Task).HasColumnName("task");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
