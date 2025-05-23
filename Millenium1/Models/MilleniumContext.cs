using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Millenium1.Models;

public partial class MilleniumContext : DbContext
{
    public MilleniumContext()
    {
    }

    public MilleniumContext(DbContextOptions<MilleniumContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Administrator> Administrators { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<ClientElement> ClientElements { get; set; }

    public virtual DbSet<Defect> Defects { get; set; }

    public virtual DbSet<Equipment> Equipment { get; set; }

    public virtual DbSet<Fabric> Fabrics { get; set; }

    public virtual DbSet<Maintenance> Maintenances { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderHistory> OrderHistories { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<Sewer> Sewers { get; set; }

    public virtual DbSet<StatusDefect> StatusDefects { get; set; }

    public virtual DbSet<StatusEquipment> StatusEquipments { get; set; }

    public virtual DbSet<StatusOrder> StatusOrders { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<Thread> Threads { get; set; }

    public virtual DbSet<UserLoginAudit> UserLoginAudits { get; set; }

    public virtual DbSet<Warehouse> Warehouses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Millenium;Username=postgres;Password=123qwe");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrator>(entity =>
        {
            entity.HasKey(e => e.AdministratorId).HasName("administrator_pkey");

            entity.ToTable("administrator");

            entity.HasIndex(e => e.AdministratorEmail, "administrator_administrator_email_key").IsUnique();

            entity.HasIndex(e => e.AdministratorPhone, "administrator_administrator_phone_key").IsUnique();

            entity.HasIndex(e => e.AdministratorPhone, "idx_administrator_phone");

            entity.Property(e => e.AdministratorId).HasColumnName("administrator_id");
            entity.Property(e => e.AdministratorEmail)
                .HasMaxLength(255)
                .HasColumnName("administrator_email");
            entity.Property(e => e.AdministratorFio)
                .HasMaxLength(255)
                .HasColumnName("administrator_fio");
            entity.Property(e => e.AdministratorPhone)
                .HasMaxLength(20)
                .HasColumnName("administrator_phone");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("created_at");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Clientid).HasName("client_pkey");

            entity.ToTable("client");

            entity.HasIndex(e => e.ClientEmail, "idx_client_email");

            entity.Property(e => e.Clientid)
                .ValueGeneratedNever()
                .HasColumnName("clientid");
            entity.Property(e => e.ClientEmail)
                .HasMaxLength(255)
                .HasColumnName("client_email");
            entity.Property(e => e.ClientFio)
                .HasMaxLength(255)
                .HasColumnName("client_fio");
        });

        modelBuilder.Entity<ClientElement>(entity =>
        {
            entity.HasKey(e => e.Elclientid).HasName("client_element_pkey");

            entity.ToTable("client_element");

            entity.Property(e => e.Elclientid).HasColumnName("elclientid");
            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .HasColumnName("address");
            entity.Property(e => e.Card)
                .HasMaxLength(20)
                .HasColumnName("card");
            entity.Property(e => e.Clientid).HasColumnName("clientid");

            entity.HasOne(d => d.Client).WithMany(p => p.ClientElements)
                .HasForeignKey(d => d.Clientid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_client");
        });

        modelBuilder.Entity<Defect>(entity =>
        {
            entity.HasKey(e => e.DefectId).HasName("defects_pkey");

            entity.ToTable("defects");

            entity.Property(e => e.DefectId).HasColumnName("defect_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.StatusDefectsId).HasColumnName("StatusDefectsID");

            entity.HasOne(d => d.Order).WithMany(p => p.Defects)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_order");

            entity.HasOne(d => d.Product).WithMany(p => p.Defects)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_product");

            entity.HasOne(d => d.StatusDefects).WithMany(p => p.Defects)
                .HasForeignKey(d => d.StatusDefectsId)
                .HasConstraintName("fk_defects_status");
        });

        modelBuilder.Entity<Equipment>(entity =>
        {
            entity.HasKey(e => e.EquipmentId).HasName("equipment_pkey");

            entity.ToTable("equipment");

            entity.Property(e => e.EquipmentId).HasColumnName("equipment_id");
            entity.Property(e => e.EquipmentName)
                .HasMaxLength(100)
                .HasColumnName("equipment_name");
            entity.Property(e => e.Model)
                .HasMaxLength(50)
                .HasColumnName("model");
            entity.Property(e => e.StatusEquipmentId).HasColumnName("StatusEquipmentID");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("type");

            entity.HasOne(d => d.StatusEquipment).WithMany(p => p.Equipment)
                .HasForeignKey(d => d.StatusEquipmentId)
                .HasConstraintName("fk_equipment_status");
        });

        modelBuilder.Entity<Fabric>(entity =>
        {
            entity.HasKey(e => e.FabricId).HasName("fabric_pkey");

            entity.ToTable("fabric");

            entity.HasIndex(e => e.SupplierId, "idx_fabric_supplier");

            entity.Property(e => e.FabricId).HasColumnName("fabric_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.FabName)
                .HasMaxLength(100)
                .HasColumnName("fab_name");
            entity.Property(e => e.MaterialType)
                .HasMaxLength(50)
                .HasColumnName("material_type");
            entity.Property(e => e.PricePerMeter)
                .HasPrecision(10, 2)
                .HasColumnName("price_per_meter");
            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Fabrics)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("fk_supplier");
        });

        modelBuilder.Entity<Maintenance>(entity =>
        {
            entity.HasKey(e => e.MaintenanceId).HasName("maintenance_pkey");

            entity.ToTable("maintenance");

            entity.Property(e => e.MaintenanceId).HasColumnName("maintenance_id");
            entity.Property(e => e.EquipmentId).HasColumnName("equipment_id");
            entity.Property(e => e.MaintenanceDate)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasColumnName("maintenance_date");
            entity.Property(e => e.MaintenanceDescription).HasColumnName("maintenance_description");
            entity.Property(e => e.MaintenanceType)
                .HasMaxLength(50)
                .HasColumnName("maintenance_type");
            entity.Property(e => e.NextMaintenanceDate).HasColumnName("next_maintenance_date");

            entity.HasOne(d => d.Equipment).WithMany(p => p.Maintenances)
                .HasForeignKey(d => d.EquipmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_equipment");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Orderid).HasName("Order_pkey");

            entity.ToTable("Order");

            entity.HasIndex(e => e.Clientid, "idx_order_client");

            entity.Property(e => e.Orderid).HasColumnName("orderid");
            entity.Property(e => e.AdministratorId).HasColumnName("administrator_id");
            entity.Property(e => e.Clientid).HasColumnName("clientid");
            entity.Property(e => e.DueDate).HasColumnName("due_date");
            entity.Property(e => e.FabricId).HasColumnName("fabric_id");
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasColumnName("order_date");
            entity.Property(e => e.SewerId).HasColumnName("sewer_id");
            entity.Property(e => e.StatusOrderId).HasColumnName("StatusOrderID");
            entity.Property(e => e.TotalAmount)
                .HasPrecision(10, 2)
                .HasColumnName("total_amount");

            entity.HasOne(d => d.Administrator).WithMany(p => p.Orders)
                .HasForeignKey(d => d.AdministratorId)
                .HasConstraintName("fk_administrator");

            entity.HasOne(d => d.Client).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Clientid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_client");

            entity.HasOne(d => d.Fabric).WithMany(p => p.Orders)
                .HasForeignKey(d => d.FabricId)
                .HasConstraintName("fk_fabric");

            entity.HasOne(d => d.Sewer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.SewerId)
                .HasConstraintName("fk_sewer");

            entity.HasOne(d => d.StatusOrder).WithMany(p => p.Orders)
                .HasForeignKey(d => d.StatusOrderId)
                .HasConstraintName("fk_defects_status_order");
        });

        modelBuilder.Entity<OrderHistory>(entity =>
        {
            entity.HasKey(e => e.Histid).HasName("order_history_pkey");

            entity.ToTable("order_history");

            entity.HasIndex(e => new { e.Clientid, e.Orderid }, "unique_client_order").IsUnique();

            entity.Property(e => e.Histid).HasColumnName("histid");
            entity.Property(e => e.Clientid).HasColumnName("clientid");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasColumnName("date");
            entity.Property(e => e.Orderid).HasColumnName("orderid");

            entity.HasOne(d => d.Client).WithMany(p => p.OrderHistories)
                .HasForeignKey(d => d.Clientid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_client");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderHistories)
                .HasForeignKey(d => d.Orderid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_order");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.OrderItemId).HasName("order_item_pkey");

            entity.ToTable("order_item");

            entity.HasIndex(e => new { e.OrderId, e.ProductId }, "unique_order_product").IsUnique();

            entity.Property(e => e.OrderItemId).HasColumnName("order_item_id");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_order");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_product");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("product_pkey");

            entity.ToTable("product");

            entity.HasIndex(e => e.CategoryId, "idx_product_category");

            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.EquipmentId).HasColumnName("equipment_id");
            entity.Property(e => e.FabricId).HasColumnName("fabric_id");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");
            entity.Property(e => e.ProductName)
                .HasMaxLength(100)
                .HasColumnName("product_name");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_category");

            entity.HasOne(d => d.Equipment).WithMany(p => p.Products)
                .HasForeignKey(d => d.EquipmentId)
                .HasConstraintName("fk_equipment");

            entity.HasOne(d => d.Fabric).WithMany(p => p.Products)
                .HasForeignKey(d => d.FabricId)
                .HasConstraintName("product_fabric_id_fkey");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("product_category_pkey");

            entity.ToTable("product_category");

            entity.HasIndex(e => e.CategoryName, "product_category_category_name_key").IsUnique();

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(100)
                .HasColumnName("category_name");
            entity.Property(e => e.Description).HasColumnName("description");
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.HasKey(e => e.Requestid).HasName("request_pkey");

            entity.ToTable("request");

            entity.HasIndex(e => e.Isdone, "idx_request_status");

            entity.Property(e => e.Requestid).HasColumnName("requestid");
            entity.Property(e => e.Enddate).HasColumnName("enddate");
            entity.Property(e => e.FabricId).HasColumnName("fabric_id");
            entity.Property(e => e.Isdone)
                .HasDefaultValue(false)
                .HasColumnName("isdone");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Startdate)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasColumnName("startdate");
            entity.Property(e => e.Supplierid).HasColumnName("supplierid");

            entity.HasOne(d => d.Fabric).WithMany(p => p.Requests)
                .HasForeignKey(d => d.FabricId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_fabric");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Requests)
                .HasForeignKey(d => d.Supplierid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_supplier");
        });

        modelBuilder.Entity<Sewer>(entity =>
        {
            entity.HasKey(e => e.SewerId).HasName("sewer_pkey");

            entity.ToTable("sewer");

            entity.HasIndex(e => e.SkillLevel, "idx_sewer_skill");

            entity.Property(e => e.SewerId).HasColumnName("sewer_id");
            entity.Property(e => e.SewerFio)
                .HasMaxLength(255)
                .HasColumnName("sewer_fio");
            entity.Property(e => e.SkillLevel)
                .HasMaxLength(100)
                .HasColumnName("skill_level");
        });

        modelBuilder.Entity<StatusDefect>(entity =>
        {
            entity.HasKey(e => e.StatusDefectsId).HasName("StatusDefects_pkey");

            entity.Property(e => e.StatusDefectsId).HasColumnName("StatusDefectsID");
            entity.Property(e => e.StatusDefectsNm)
                .HasMaxLength(100)
                .HasColumnName("StatusDefectsNM");
        });

        modelBuilder.Entity<StatusEquipment>(entity =>
        {
            entity.HasKey(e => e.StatusEquipmentId).HasName("StatusEquipment_pkey");

            entity.ToTable("StatusEquipment");

            entity.Property(e => e.StatusEquipmentId).HasColumnName("StatusEquipmentID");
            entity.Property(e => e.StatusEquipmentNm)
                .HasMaxLength(100)
                .HasColumnName("StatusEquipmentNM");
        });

        modelBuilder.Entity<StatusOrder>(entity =>
        {
            entity.HasKey(e => e.StatusOrderId).HasName("StatusOrder_pkey");

            entity.ToTable("StatusOrder");

            entity.Property(e => e.StatusOrderId).HasColumnName("StatusOrderID");
            entity.Property(e => e.StatusOrderNm)
                .HasMaxLength(100)
                .HasColumnName("StatusOrderNM");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId).HasName("supplier_pkey");

            entity.ToTable("supplier");

            entity.HasIndex(e => e.SupplierEmail, "supplier_supplier_email_key").IsUnique();

            entity.HasIndex(e => e.SupplierPhone, "supplier_supplier_phone_key").IsUnique();

            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");
            entity.Property(e => e.RegistrationDate)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasColumnName("registration_date");
            entity.Property(e => e.SupplierEmail)
                .HasMaxLength(255)
                .HasColumnName("supplier_email");
            entity.Property(e => e.SupplierName)
                .HasMaxLength(100)
                .HasColumnName("supplier_name");
            entity.Property(e => e.SupplierPhone)
                .HasMaxLength(20)
                .HasColumnName("supplier_phone");
        });

        modelBuilder.Entity<Thread>(entity =>
        {
            entity.HasKey(e => e.ThreadId).HasName("thread_pkey");

            entity.ToTable("thread");

            entity.HasIndex(e => e.SupplierId, "idx_thread_supplier");

            entity.Property(e => e.ThreadId).HasColumnName("thread_id");
            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .HasColumnName("color");
            entity.Property(e => e.MaterialType)
                .HasMaxLength(50)
                .HasColumnName("material_type");
            entity.Property(e => e.PricePerSpool)
                .HasPrecision(10, 2)
                .HasColumnName("price_per_spool");
            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Threads)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_supplier");
        });

        modelBuilder.Entity<UserLoginAudit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_login_audit_pkey");

            entity.ToTable("user_login_audit");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IpAddress)
                .HasMaxLength(50)
                .HasColumnName("ip_address");
            entity.Property(e => e.LoginTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnName("login_time");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.HasKey(e => e.WarehouseId).HasName("warehouse_pkey");

            entity.ToTable("warehouse");

            entity.HasIndex(e => e.FabricId, "idx_warehouse_fabric");

            entity.Property(e => e.WarehouseId).HasColumnName("warehouse_id");
            entity.Property(e => e.FabricId).HasColumnName("fabric_id");
            entity.Property(e => e.QuantityInStock)
                .HasPrecision(10, 2)
                .HasColumnName("quantity_in_stock");

            entity.HasOne(d => d.Fabric).WithMany(p => p.Warehouses)
                .HasForeignKey(d => d.FabricId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_fabric");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
