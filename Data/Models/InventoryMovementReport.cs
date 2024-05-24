namespace Data.Models
{
    public class InventoryMovementReport
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int BalanceAtStart { get; set; }
        public int IncomingQuantity { get; set; }
        public int OrderQuantity { get; set; }
        public int BalanceAtEnd { get; set; }
    }
}
