using Business.Services;
using Data.Models;

namespace UIForms.UI
{
    public partial class EditTransactionForm : Form
    {
        private InventoryTransactionService _transactionService;
        private InventoryTransaction _transaction;

        public EditTransactionForm(InventoryTransactionService transactionService, InventoryTransaction transaction)
        {
            InitializeComponent();
            _transactionService = transactionService;
            _transaction = transaction;
            cmbType.DataSource = Enum.GetValues(typeof(TransactionType));
            PopulateFields();
        }

        private void PopulateFields()
        {
            txtItemId.Text = _transaction.InventoryItemId.ToString();
            txtWarehouseId.Text = _transaction.WarehouseId.ToString();
            txtQuantity.Text = _transaction.Quantity.ToString();
            txtCost.Text = _transaction.Cost.ToString();
            txtSalePrice.Text = _transaction.SalePrice.ToString();
            txtDate.Text = _transaction.TransactionDate.ToString();
            cmbType.SelectedItem = _transaction.TransactionType;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                _transaction.InventoryItemId = int.Parse(txtItemId.Text);
                _transaction.WarehouseId = int.Parse(txtWarehouseId.Text);
                _transaction.Quantity = int.Parse(txtQuantity.Text);
                _transaction.Cost = decimal.Parse(txtCost.Text);
                _transaction.SalePrice = decimal.Parse(txtSalePrice.Text);
                _transaction.TransactionDate = DateTime.Parse(txtDate.Text);
                _transaction.TransactionType = (TransactionType)cmbType.SelectedItem;

                _transactionService.UpdateTransaction(_transaction);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating transaction: {ex.Message}");
            }
        }
    }
}
