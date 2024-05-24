using Data.DBContext;
using Data.Models;

namespace Business.Services
{
    public class ReportService
    {
        private readonly WarehouseManagementSystemDBContext _dbContext;

        public ReportService(WarehouseManagementSystemDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<InventoryMovementReport> GetPeriodicInventoryReport(int warehouseId, DateTime startDate, DateTime endDate)
        {
            var report = _dbContext.InventoryItems
                .Where(item => item.WarehouseId == warehouseId)
                .Select(item => new InventoryMovementReport
                {
                    ItemId = item.Id,
                    ItemName = item.Name,
                    BalanceAtStart = item.InventoryTransactions
                        .Where(t => t.TransactionDate < startDate)
                        .Sum(t => t.TransactionType == TransactionType.IncomingShipment ? t.Quantity : -t.Quantity),
                    IncomingQuantity = item.InventoryTransactions
                        .Where(t => t.TransactionDate >= startDate && t.TransactionDate <= endDate && t.TransactionType == TransactionType.IncomingShipment)
                        .Sum(t => t.Quantity),
                    OrderQuantity = item.InventoryTransactions
                        .Where(t => t.TransactionDate >= startDate && t.TransactionDate <= endDate && t.TransactionType == TransactionType.OutgoingOrder)
                        .Sum(t => t.Quantity),
                    BalanceAtEnd = item.InventoryTransactions
                        .Where(t => t.TransactionDate <= endDate)
                        .Sum(t => t.TransactionType == TransactionType.IncomingShipment ? t.Quantity : -t.Quantity)
                })
                .ToList();

            return report;
        }

        public List<ProfitabilityReport> GetProfitabilityReport(int warehouseId, DateTime startDate, DateTime endDate)
        {
            var report = _dbContext.InventoryItems
                .Where(item => item.WarehouseId == warehouseId)
                .Select(item => new ProfitabilityReport
                {
                    ItemId = item.Id,
                    ItemName = item.Name,
                    COGS = item.InventoryTransactions
                        .Where(t => t.TransactionDate >= startDate && t.TransactionDate <= endDate && t.TransactionType == TransactionType.OutgoingOrder)
                        .Sum(t => t.Quantity * t.InventoryItem.AverageCost),
                    Revenue = item.InventoryTransactions
                        .Where(t => t.TransactionDate >= startDate && t.TransactionDate <= endDate && t.TransactionType == TransactionType.OutgoingOrder)
                        .Sum(t => t.Quantity * t.SalePrice),
                    GrossProfit = item.InventoryTransactions
                        .Where(t => t.TransactionDate >= startDate && t.TransactionDate <= endDate && t.TransactionType == TransactionType.OutgoingOrder)
                        .Sum(t => (t.SalePrice - t.InventoryItem.AverageCost) * t.Quantity),
                    GrossMargin = item.InventoryTransactions
                        .Where(t => t.TransactionDate >= startDate && t.TransactionDate <= endDate && t.TransactionType == TransactionType.OutgoingOrder)
                        .Sum(t => (t.SalePrice - t.InventoryItem.AverageCost) * t.Quantity) /
                        item.InventoryTransactions
                        .Where(t => t.TransactionDate >= startDate && t.TransactionDate <= endDate && t.TransactionType == TransactionType.OutgoingOrder)
                        .Sum(t => t.SalePrice) * 100
                })
                .ToList();

            return report;
        }
    }
}
