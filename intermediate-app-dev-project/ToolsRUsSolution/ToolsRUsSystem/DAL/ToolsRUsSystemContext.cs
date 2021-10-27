using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

#region Additional Namepaces
using ToolsRUsSystem.Entities;
#endregion

namespace ToolsRUsSystem.DAL
{
    internal partial class ToolsRUsSystemContext : DbContext
    {
        public ToolsRUsSystemContext()
            : base("name=ToolsRUsDB")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Coupon> Coupons { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual DbSet<ReceiveOrderDetail> ReceiveOrderDetails { get; set; }
        public virtual DbSet<ReceiveOrder> ReceiveOrders { get; set; }
        public virtual DbSet<RentalDetail> RentalDetails { get; set; }
        public virtual DbSet<RentalEquipment> RentalEquipments { get; set; }
        public virtual DbSet<Rental> Rentals { get; set; }
        public virtual DbSet<ReturnedOrderDetail> ReturnedOrderDetails { get; set; }
        public virtual DbSet<SaleDetail> SaleDetails { get; set; }
        public virtual DbSet<SaleRefundDetail> SaleRefundDetails { get; set; }
        public virtual DbSet<SaleRefund> SaleRefunds { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<StockItem> StockItems { get; set; }
        public virtual DbSet<UnOrderedItem> UnOrderedItems { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.StockItems)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.ProvinceID)
                .IsFixedLength();

            modelBuilder.Entity<Customer>()
                .Property(e => e.PostalCode)
                .IsFixedLength();

            modelBuilder.Entity<Customer>()
                .Property(e => e.ContactPhone)
                .IsFixedLength();

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Rentals)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.ContactPhone)
                .IsFixedLength();

            modelBuilder.Entity<Employee>()
                .Property(e => e.PostalCode)
                .IsFixedLength();

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.PurchaseOrders)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Rentals)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.SaleRefunds)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Sales)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Position>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.Position)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Province>()
                .Property(e => e.ProvinceID)
                .IsFixedLength();

            modelBuilder.Entity<Province>()
                .HasMany(e => e.Customers)
                .WithRequired(e => e.Province)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Province>()
                .HasMany(e => e.Vendors)
                .WithRequired(e => e.Province)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PurchaseOrderDetail>()
                .Property(e => e.PurchasePrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PurchaseOrderDetail>()
                .HasMany(e => e.ReceiveOrderDetails)
                .WithRequired(e => e.PurchaseOrderDetail)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PurchaseOrder>()
                .Property(e => e.TaxAmount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PurchaseOrder>()
                .Property(e => e.SubTotal)
                .HasPrecision(19, 4);

            modelBuilder.Entity<PurchaseOrder>()
                .HasMany(e => e.PurchaseOrderDetails)
                .WithRequired(e => e.PurchaseOrder)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PurchaseOrder>()
                .HasMany(e => e.ReceiveOrders)
                .WithRequired(e => e.PurchaseOrder)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ReceiveOrder>()
                .HasMany(e => e.ReceiveOrderDetails)
                .WithRequired(e => e.ReceiveOrder)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ReceiveOrder>()
                .HasMany(e => e.ReturnedOrderDetails)
                .WithRequired(e => e.ReceiveOrder)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RentalDetail>()
                .Property(e => e.RentalDays)
                .HasPrecision(5, 2);

            modelBuilder.Entity<RentalDetail>()
                .Property(e => e.RentalRate)
                .HasPrecision(19, 4);

            modelBuilder.Entity<RentalDetail>()
                .Property(e => e.DamageRepairCost)
                .HasPrecision(19, 4);

            modelBuilder.Entity<RentalEquipment>()
                .Property(e => e.DailyRate)
                .HasPrecision(10, 4);

            modelBuilder.Entity<RentalEquipment>()
                .HasMany(e => e.RentalDetails)
                .WithRequired(e => e.RentalEquipment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Rental>()
                .Property(e => e.SubTotal)
                .HasPrecision(10, 4);

            modelBuilder.Entity<Rental>()
                .Property(e => e.TaxAmount)
                .HasPrecision(10, 4);

            modelBuilder.Entity<Rental>()
                .Property(e => e.PaymentType)
                .IsFixedLength();

            modelBuilder.Entity<Rental>()
                .HasMany(e => e.RentalDetails)
                .WithRequired(e => e.Rental)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SaleDetail>()
                .Property(e => e.SellingPrice)
                .HasPrecision(10, 4);

            modelBuilder.Entity<SaleRefundDetail>()
                .Property(e => e.SellingPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SaleRefund>()
                .Property(e => e.TaxAmount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SaleRefund>()
                .Property(e => e.SubTotal)
                .HasPrecision(19, 4);

            modelBuilder.Entity<SaleRefund>()
                .HasMany(e => e.SaleRefundDetails)
                .WithRequired(e => e.SaleRefund)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sale>()
                .Property(e => e.PaymentType)
                .IsFixedLength();

            modelBuilder.Entity<Sale>()
                .Property(e => e.TaxAmount)
                .HasPrecision(10, 4);

            modelBuilder.Entity<Sale>()
                .Property(e => e.SubTotal)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Sale>()
                .HasMany(e => e.SaleDetails)
                .WithRequired(e => e.Sale)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sale>()
                .HasMany(e => e.SaleRefunds)
                .WithRequired(e => e.Sale)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StockItem>()
                .Property(e => e.SellingPrice)
                .HasPrecision(10, 4);

            modelBuilder.Entity<StockItem>()
                .Property(e => e.PurchasePrice)
                .HasPrecision(10, 4);

            modelBuilder.Entity<StockItem>()
                .HasMany(e => e.PurchaseOrderDetails)
                .WithRequired(e => e.StockItem)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StockItem>()
                .HasMany(e => e.SaleDetails)
                .WithRequired(e => e.StockItem)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StockItem>()
                .HasMany(e => e.SaleRefundDetails)
                .WithRequired(e => e.StockItem)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Vendor>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Vendor>()
                .Property(e => e.ProvinceID)
                .IsFixedLength();

            modelBuilder.Entity<Vendor>()
                .Property(e => e.PostalCode)
                .IsFixedLength();

            modelBuilder.Entity<Vendor>()
                .HasMany(e => e.PurchaseOrders)
                .WithRequired(e => e.Vendor)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Vendor>()
                .HasMany(e => e.StockItems)
                .WithRequired(e => e.Vendor)
                .WillCascadeOnDelete(false);
        }
    }
}
