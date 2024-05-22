using Data.DBContext;
using Data.Models;

namespace Business.Services
{
    public class WarehouseService
    {
        private WarehouseManagementSystemDBContext _context;

        public WarehouseService()
        {
            _context = new WarehouseManagementSystemDBContext();
        }

        public List<Warehouse> GetAllWarehouses()
        {
            return _context.Warehouses.ToList();
        }

        public Warehouse GetWarehouseById(int id)
        {
            return _context.Warehouses.Find(id);
        }

        public void AddWarehouse(Warehouse warehouse)
        {
            _context.Warehouses.Add(warehouse);
            _context.SaveChanges();
        }

        public void UpdateWarehouse(Warehouse warehouse)
        {
            var existingWarehouse = _context.Warehouses.Find(warehouse.Id);
            if (existingWarehouse != null)
            {
                existingWarehouse.Name = warehouse.Name;
                existingWarehouse.Location = warehouse.Location;
                _context.SaveChanges();
            }
        }

        public void DeleteWarehouse(int id)
        {
            var warehouse = _context.Warehouses.Find(id);
            if (warehouse != null)
            {
                _context.Warehouses.Remove(warehouse);
                _context.SaveChanges();
            }
        }
    }
}
