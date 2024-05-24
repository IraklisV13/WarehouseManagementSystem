using Data.DBContext;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public class InventoryTransactionService
    {
        private readonly WarehouseManagementSystemDBContext _dbContext;

        public InventoryTransactionService(WarehouseManagementSystemDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<InventoryTransaction> GetAllTransactions()
        {
            return _dbContext.InventoryTransactions.Include(t => t.InventoryItem).ToList();
        }

        public void AddTransaction(InventoryTransaction transaction)
        {
            if (transaction.TransactionType.ToString() == "Incoming")
            {
                // Update stock level
                transaction.InventoryItem.StockLevel += transaction.Quantity;

                // Update moving average cost
                UpdateMovingAverageCost(transaction.InventoryItemId, transaction.Quantity, transaction.SalePrice);
            }
            else if (transaction.TransactionType.ToString() == "Outgoing")
            {
                // Update stock level
                transaction.InventoryItem.StockLevel -= transaction.Quantity;
            }

            _dbContext.InventoryTransactions.Add(transaction);
            _dbContext.SaveChanges();
        }

        public void UpdateTransaction(InventoryTransaction transaction)
        {
            _dbContext.Entry(transaction).State = (System.Data.Entity.EntityState)EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void DeleteTransaction(int id)
        {
            var transaction = _dbContext.InventoryTransactions.Find(id);
            if (transaction != null)
            {
                if (transaction.TransactionType.ToString() == "Incoming")
                {
                    transaction.InventoryItem.StockLevel -= transaction.Quantity;
                }
                else if (transaction.TransactionType.ToString() == "Outgoing")
                {
                    transaction.InventoryItem.StockLevel += transaction.Quantity;
                }

                _dbContext.InventoryTransactions.Remove(transaction);
                _dbContext.SaveChanges();
            }
        }

        private void UpdateMovingAverageCost(int itemId, int quantity, decimal cost)
        {
            var item = _dbContext.InventoryItems.Find(itemId);
            if (item != null)
            {
                var totalCost = item.StockLevel * item.AverageCost;
                totalCost += quantity * cost;
                item.StockLevel += quantity;
                item.AverageCost = totalCost / item.StockLevel;

                _dbContext.SaveChanges();
            }
        }
    }
}
