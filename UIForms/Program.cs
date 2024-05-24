using Business.Services;
using Data.DBContext;
using Data.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace UIForms.UI
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();
            var configuration = LoadConfiguration();
            ConfigureServices(services, configuration);

            using (var serviceProvider = services.BuildServiceProvider())
            {
                var dbContext = serviceProvider.GetRequiredService<WarehouseManagementSystemDBContext>();

                // Apply any pending migrations
                dbContext.Database.Migrate();

                // Add mock data if the database is empty
                AddMockData(dbContext);

                var mainForm = serviceProvider.GetRequiredService<MainForm>();
                Application.Run(mainForm);
            }
        }

        private static IConfiguration LoadConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            return builder.Build();
        }

        private static void ConfigureServices(ServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<WarehouseManagementSystemDBContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<InventoryTransactionService>();
            services.AddScoped<ReportService>();
            services.AddScoped<MainForm>();
            services.AddScoped<AddTransactionForm>();
            services.AddScoped<EditTransactionForm>();
            services.AddScoped<ReportForm>();
        }

        private static void AddMockData(WarehouseManagementSystemDBContext dbContext)
        {
            if (!dbContext.Warehouses.Any())
            {
                var warehouse = new Warehouse { Name = "Main Warehouse" };
                var category = new InventoryItemCategory { Name = "Electronics" };
                var item = new InventoryItem { Name = "Laptop", Category = category, StockLevel = 10, AverageCost = 1000, Warehouse = warehouse };
                var transaction = new InventoryTransaction
                {
                    InventoryItem = item,
                    Quantity = 10,
                    TransactionType = TransactionType.IncomingShipment,
                    TransactionDate = DateTime.Now,
                    SalePrice = 1000
                };

                dbContext.Warehouses.Add(warehouse);
                dbContext.InventoryItemCategories.Add(category);
                dbContext.InventoryItems.Add(item);
                dbContext.InventoryTransactions.Add(transaction);

                dbContext.SaveChanges();
            }
        }
    }
}
