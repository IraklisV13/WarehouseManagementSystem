using Data.DBContext;
using Data.Models;

namespace Business.Services
{
    public class InventoryTransactionService
    {
        private WarehouseManagementSystemDBContext _context;

        public InventoryTransactionService()
        {
            _context = new WarehouseManagementSystemDBContext();
        }

        public List<InventoryTransaction> GetAllTransactions()
        {
            return _context.InventoryTransactions.Include("InventoryItem").Include("Warehouse").ToList();
        }

        public InventoryTransaction GetTransactionById(int id)
        {
            return _context.InventoryTransactions.Include("InventoryItem").Include("Warehouse").FirstOrDefault(t => t.Id == id);
        }

        public void AddTransaction(InventoryTransaction transaction)
        {
            _context.InventoryTransactions.Add(transaction);
            _context.SaveChanges();
        }

        public void UpdateTransaction(InventoryTransaction transaction)
        {
            var existingTransaction = _context.InventoryTransactions.Find(transaction.Id);
            if (existingTransaction != null)
            {
                existingTransaction.InventoryItemId = transaction.InventoryItemId;
                existingTransaction.WarehouseId = transaction.WarehouseId;
                existingTransaction.Quantity = transaction.Quantity;
                existingTransaction.Cost = transaction.Cost;
                existingTransaction.SalePrice = transaction.SalePrice;
                existingTransaction.TransactionDate = transaction.TransactionDate;
                existingTransaction.Type = transaction.Type;
                _context.SaveChanges();
            }
        }

        public void DeleteTransaction(int id)
        {
            var transaction = _context.InventoryTransactions.Find(id);
            if (transaction != null)
            {
                _context.InventoryTransactions.Remove(transaction);
                _context.SaveChanges();
            }
        }
    }
}
