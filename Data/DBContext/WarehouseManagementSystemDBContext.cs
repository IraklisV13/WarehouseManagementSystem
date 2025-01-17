﻿using Data.Models;
using System.Data.Entity;

namespace Data.DBContext
{
    public class WarehouseManagementSystemDBContext : DbContext
    {
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<InventoryItemCategory> InventoryItemCategories { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<InventoryTransaction> InventoryTransactions { get; set; }

        public WarehouseManagementSystemDBContext() : base("name=WarehouseManagementDatabase")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Warehouse>()
                .HasMany(w => w.InventoryItems)
                .WithRequired(i => i.Warehouse)
                .HasForeignKey(i => i.WarehouseId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InventoryItemCategory>()
                .HasMany(c => c.InventoryItems)
                .WithRequired(i => i.Category)
                .HasForeignKey(i => i.CategoryId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InventoryItem>()
                .HasMany(i => i.InventoryTransactions)
                .WithRequired(t => t.InventoryItem)
                .HasForeignKey(t => t.InventoryItemId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Warehouse>()
                .HasMany(w => w.InventoryTransactions)
                .WithRequired(t => t.Warehouse)
                .HasForeignKey(t => t.WarehouseId)
                .WillCascadeOnDelete(false);
        }
    }
}
