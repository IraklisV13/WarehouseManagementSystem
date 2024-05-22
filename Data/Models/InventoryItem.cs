namespace Data.Models
{
    public class InventoryItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int WarehouseId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public virtual InventoryItemCategory Category { get; set; }
        public virtual Warehouse Warehouse { get; set; }
        public virtual ICollection<InventoryTransaction> InventoryTransactions { get; set; }
    }
}
