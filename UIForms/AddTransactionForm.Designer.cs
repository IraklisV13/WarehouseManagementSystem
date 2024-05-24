namespace UIForms.UI
{
    partial class AddTransactionForm
    {
        private System.ComponentModel.IContainer components = null;

        public AddTransactionForm()
        {
            InitializeComponent();

            // Event handler for Save button click event
            btnSave.Click += btnSave_Click;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtItemId = new System.Windows.Forms.TextBox();
            this.txtWarehouseId = new System.Windows.Forms.TextBox();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.txtCost = new System.Windows.Forms.TextBox();
            this.txtSalePrice = new System.Windows.Forms.TextBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblItemId = new System.Windows.Forms.Label();
            this.lblWarehouseId = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblCost = new System.Windows.Forms.Label();
            this.lblSalePrice = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();

            // Set properties for labels
            SetLabelProperties(lblItemId, "Item ID:", 20, 10);
            SetLabelProperties(lblWarehouseId, "Warehouse ID:", 20, 50);
            SetLabelProperties(lblQuantity, "Quantity:", 20, 90);
            SetLabelProperties(lblCost, "Cost:", 20, 130);
            SetLabelProperties(lblSalePrice, "Sale Price:", 20, 170);
            SetLabelProperties(lblDate, "Date:", 20, 210);
            SetLabelProperties(lblType, "Transaction Type:", 20, 250);

            // Set properties for input fields
            SetTextBoxProperties(txtItemId, 120, 10);
            SetTextBoxProperties(txtWarehouseId, 120, 50);
            SetTextBoxProperties(txtQuantity, 120, 90);
            SetTextBoxProperties(txtCost, 120, 130);
            SetTextBoxProperties(txtSalePrice, 120, 170);
            SetDateTimePickerProperties(dtpDate, 120, 210);
            SetComboBoxProperties(cmbType, 120, 250);
            SetButtonProperties(btnSave, "Save", 120, 290);

            // Adding controls to the form
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.txtSalePrice);
            this.Controls.Add(this.txtCost);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.txtWarehouseId);
            this.Controls.Add(this.txtItemId);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblSalePrice);
            this.Controls.Add(this.lblCost);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.lblWarehouseId);
            this.Controls.Add(this.lblItemId);

            this.ClientSize = new System.Drawing.Size(300, 350);
            this.Name = "AddTransactionForm";
            this.Text = "Add Transaction";
        }


        private void SetLabelProperties(Label label, string text, int x, int y)
        {
            label.Text = text;
            label.Location = new System.Drawing.Point(x, y);
            label.Size = new System.Drawing.Size(100, 20);
        }

        private void SetTextBoxProperties(TextBox textBox, int x, int y)
        {
            textBox.Location = new System.Drawing.Point(x, y);
            textBox.Size = new System.Drawing.Size(150, 20);
        }

        private void SetDateTimePickerProperties(DateTimePicker dateTimePicker, int x, int y)
        {
            dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dateTimePicker.Location = new System.Drawing.Point(x, y);
            dateTimePicker.Size = new System.Drawing.Size(150, 20);
        }

        private void SetComboBoxProperties(ComboBox comboBox, int x, int y)
        {
            comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox.Location = new System.Drawing.Point(x, y);
            comboBox.Size = new System.Drawing.Size(150, 21);
        }

        private void SetButtonProperties(Button button, string text, int x, int y)
        {
            button.Text = text;
            button.Location = new System.Drawing.Point(x, y);


        }

        private System.Windows.Forms.TextBox txtItemId;
        private System.Windows.Forms.TextBox txtWarehouseId;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.TextBox txtCost;
        private System.Windows.Forms.TextBox txtSalePrice;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblItemId;
        private System.Windows.Forms.Label lblWarehouseId;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblCost;
        private System.Windows.Forms.Label lblSalePrice;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblType;
    }
}
