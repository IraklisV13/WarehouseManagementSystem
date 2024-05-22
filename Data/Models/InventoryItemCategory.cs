namespace Data.Models
{
    public class InventoryItemCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<InventoryItem> InventoryItems { get; set; }
    }
}
