using Data.DBContext;
using Data.Models;

namespace Business.Services
{
    public class InventoryItemService
    {
        private WarehouseManagementSystemDBContext _context;

        public InventoryItemService()
        {
            _context = new WarehouseManagementSystemDBContext();
        }

        public List<InventoryItem> GetAllInventoryItems()
        {
            return _context.InventoryItems.Include("Category").Include("Warehouse").ToList();
        }

        public InventoryItem GetInventoryItemById(int id)
        {
            return _context.InventoryItems.Include("Category").Include("Warehouse").FirstOrDefault(i => i.Id == id);
        }

        public void AddInventoryItem(InventoryItem item)
        {
            _context.InventoryItems.Add(item);
            _context.SaveChanges();
        }

        public void UpdateInventoryItem(InventoryItem item)
        {
            var existingItem = _context.InventoryItems.Find(item.Id);
            if (existingItem != null)
            {
                existingItem.Name = item.Name;
                existingItem.CategoryId = item.CategoryId;
                existingItem.WarehouseId = item.WarehouseId;
                existingItem.Price = item.Price;
                existingItem.Quantity = item.Quantity;
                _context.SaveChanges();
            }
        }

        public void DeleteInventoryItem(int id)
        {
            var item = _context.InventoryItems.Find(id);
            if (item != null)
            {
                _context.InventoryItems.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}
