using Data.DBContext;
using Data.Models;

namespace Business.Services
{
    public class InventoryItemCategoryService
    {
        private WarehouseManagementSystemDBContext _context;

        public InventoryItemCategoryService()
        {
            _context = new WarehouseManagementSystemDBContext();
        }

        public List<InventoryItemCategory> GetAllCategories()
        {
            return _context.InventoryItemCategories.ToList();
        }

        public InventoryItemCategory GetCategoryById(int id)
        {
            return _context.InventoryItemCategories.Find(id);
        }

        public void AddCategory(InventoryItemCategory category)
        {
            _context.InventoryItemCategories.Add(category);
            _context.SaveChanges();
        }

        public void UpdateCategory(InventoryItemCategory category)
        {
            var existingCategory = _context.InventoryItemCategories.Find(category.Id);
            if (existingCategory != null)
            {
                existingCategory.Name = category.Name;
                _context.SaveChanges();
            }
        }

        public void DeleteCategory(int id)
        {
            var category = _context.InventoryItemCategories.Find(id);
            if (category != null)
            {
                _context.InventoryItemCategories.Remove(category);
                _context.SaveChanges();
            }
        }
    }
}
