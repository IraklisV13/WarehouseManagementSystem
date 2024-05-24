using Business.Services;
using Data.Models;

namespace UIForms.UI
{
    public partial class AddTransactionForm : Form
    {
        private InventoryTransactionService _transactionService;

        public AddTransactionForm(InventoryTransactionService transactionService)
        {
            InitializeComponent();
            _transactionService = transactionService;
            cmbType.DataSource = Enum.GetValues(typeof(TransactionType));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var transaction = new InventoryTransaction
                {
                    InventoryItemId = int.Parse(txtItemId.Text),
                    WarehouseId = int.Parse(txtWarehouseId.Text),
                    Quantity = int.Parse(txtQuantity.Text),
                    Cost = decimal.Parse(txtCost.Text),
                    SalePrice = decimal.Parse(txtSalePrice.Text),
                    TransactionDate = DateTime.Parse(dtpDate.Text),
                    TransactionType = (TransactionType)cmbType.SelectedItem
                };

                _transactionService.AddTransaction(transaction);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving transaction: {ex.Message}");
            }
        }
    }
}
