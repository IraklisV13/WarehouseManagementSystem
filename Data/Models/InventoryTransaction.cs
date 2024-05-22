namespace Data.Models
{
    public class InventoryTransaction
    {
        public int Id { get; set; }
        public int InventoryItemId { get; set; }
        public int WarehouseId { get; set; }
        public int Quantity { get; set; }
        public decimal? Cost { get; set; } // For incoming shipments
        public decimal? SalePrice { get; set; } // For outgoing orders
        public DateTime TransactionDate { get; set; }
        public TransactionType Type { get; set; }

        public virtual InventoryItem InventoryItem { get; set; }
        public virtual Warehouse Warehouse { get; set; }
    }

    public enum TransactionType
    {
        IncomingShipment,
        OutgoingOrder
    }
}
