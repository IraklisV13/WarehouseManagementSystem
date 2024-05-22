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
            cmbType.SelectedItem = _transaction.Type;
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
                _transaction.Type = (TransactionType)cmbType.SelectedItem;

                _transactionService.UpdateTransaction(_transaction);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating transaction: {ex.Message}");
            }
        }

        private void InitializeComponent()
        {
            this.txtItemId = new System.Windows.Forms.TextBox();
            this.txtWarehouseId = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtCost = new System.Windows.Forms.TextBox();
            this.txtSalePrice = new System.Windows.Forms.TextBox();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtItemId
            // 
            this.txtItemId.Location = new System.Drawing.Point(120, 30);
            this.txtItemId.Name = "txtItemId";
            this.txtItemId.Size = new System.Drawing.Size(100, 20);
            this.txtItemId.TabIndex = 0;
            // 
            // txtWarehouseId
            // 
            this.txtWarehouseId.Location = new System.Drawing.Point(120, 60);
            this.txtWarehouseId.Name = "txtWarehouseId";
            this.txtWarehouseId.Size = new System.Drawing.Size(100, 20);
            this.txtWarehouseId.TabIndex = 1;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(120, 90);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(100, 20);
            this.txtQuantity.TabIndex = 2;
            // 
            // txtCost
            // 
            this.txtCost.Location = new System.Drawing.Point(120, 120);
            this.txtCost.Name = "txtCost";
            this.txtCost.Size = new System.Drawing.Size(100, 20);
            this.txtCost.TabIndex = 3;
            // 
            // txtSalePrice
            // 
            this.txtSalePrice.Location = new System.Drawing.Point(120, 150);
            this.txtSalePrice.Name = "txtSalePrice";
            this.txtSalePrice.Size = new System.Drawing.Size(100, 20);
            this.txtSalePrice.TabIndex = 4;
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(120, 180);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(100, 20);
            this.txtDate.TabIndex = 5;
            // 
            // cmbType
            // 
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(120, 210);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(100, 21);
            this.cmbType.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(120, 240);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // EditTransactionForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.txtSalePrice);
            this.Controls.Add(this.txtCost);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.txtWarehouseId);
            this.Controls.Add(this.txtItemId);
            this.Name = "EditTransactionForm";
            this.Text = "Edit Transaction";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox txtItemId;
        private System.Windows.Forms.TextBox txtWarehouseId;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtCost;
        private System.Windows.Forms.TextBox txtSalePrice;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Button btnSave;
    }
}
