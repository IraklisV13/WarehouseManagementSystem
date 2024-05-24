using Business.Services;
using Data.Models;

namespace UIForms.UI
{
    public partial class MainForm : Form
    {
        private InventoryTransactionService _transactionService;

        public MainForm(InventoryTransactionService transactionService)
        {
            InitializeComponent();
            _transactionService = transactionService;
            LoadTransactions();
        }

        private void LoadTransactions()
        {
            dataGridViewTransactions.DataSource = _transactionService.GetAllTransactions();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new AddTransactionForm(_transactionService);
            addForm.FormClosed += (s, args) => LoadTransactions();
            addForm.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewTransactions.SelectedRows.Count > 0)
            {
                var transaction = (InventoryTransaction)dataGridViewTransactions.SelectedRows[0].DataBoundItem;
                var editForm = new EditTransactionForm(_transactionService, transaction);
                editForm.FormClosed += (s, args) => LoadTransactions();
                editForm.Show();
            }
            else
            {
                MessageBox.Show("Please select a transaction to edit.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewTransactions.SelectedRows.Count > 0)
            {
                var transaction = (InventoryTransaction)dataGridViewTransactions.SelectedRows[0].DataBoundItem;
                _transactionService.DeleteTransaction(transaction.Id);
                LoadTransactions();
            }
            else
            {
                MessageBox.Show("Please select a transaction to delete.");
            }
        }
    }
}
