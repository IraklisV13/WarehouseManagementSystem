using Business.Services;
using Data.Models;

namespace UIForms.UI
{
    public partial class MainForm : Form
    {
        private InventoryTransactionService _transactionService;

        public MainForm()
        {
            InitializeComponent();
            _transactionService = new InventoryTransactionService();
            LoadTransactions();
        }

        private void LoadTransactions()
        {
            var transactions = _transactionService.GetAllTransactions();
            dataGridViewTransactions.DataSource = transactions;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addTransactionForm = new AddTransactionForm(_transactionService);
            addTransactionForm.ShowDialog();
            LoadTransactions();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewTransactions.SelectedRows.Count > 0)
            {
                var transaction = (InventoryTransaction)dataGridViewTransactions.SelectedRows[0].DataBoundItem;
                var editTransactionForm = new EditTransactionForm(_transactionService, transaction);
                editTransactionForm.ShowDialog();
                LoadTransactions();
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
        }

        private void InitializeComponent()
        {
            this.dataGridViewTransactions = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransactions)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewTransactions
            // 
            this.dataGridViewTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTransactions.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewTransactions.Name = "dataGridViewTransactions";
            this.dataGridViewTransactions.Size = new System.Drawing.Size(776, 396);
            this.dataGridViewTransactions.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 414);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(93, 414);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(174, 414);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dataGridViewTransactions);
            this.Name = "MainForm";
            this.Text = "Warehouse Management System";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransactions)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dataGridViewTransactions;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
    }
}
