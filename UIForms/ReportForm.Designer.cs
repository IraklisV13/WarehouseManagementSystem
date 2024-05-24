namespace UIForms.UI
{
    partial class ReportForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.TextBox txtWarehouseId;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Button btnGeneratePeriodicReport;
        private System.Windows.Forms.Button btnGenerateProfitabilityReport;

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
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.txtWarehouseId = new System.Windows.Forms.TextBox();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.btnGeneratePeriodicReport = new System.Windows.Forms.Button();
            this.btnGenerateProfitabilityReport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvReport
            // 
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.Location = new System.Drawing.Point(12, 98);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.Size = new System.Drawing.Size(776, 340);
            this.dgvReport.TabIndex = 0;
            // 
            // txtWarehouseId
            // 
            this.txtWarehouseId.Location = new System.Drawing.Point(12, 12);
            this.txtWarehouseId.Name = "txtWarehouseId";
            this.txtWarehouseId.Size = new System.Drawing.Size(100, 23);
            this.txtWarehouseId.TabIndex = 1;
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Location = new System.Drawing.Point(118, 12);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(200, 23);
            this.dtpStartDate.TabIndex = 2;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Location = new System.Drawing.Point(324, 12);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(200, 23);
            this.dtpEndDate.TabIndex = 3;
            // 
            // btnGeneratePeriodicReport
            // 
            this.btnGeneratePeriodicReport.Location = new System.Drawing.Point(530, 12);
            this.btnGeneratePeriodicReport.Name = "btnGeneratePeriodicReport";
            this.btnGeneratePeriodicReport.Size = new System.Drawing.Size(125, 23);
            this.btnGeneratePeriodicReport.TabIndex = 4;
            this.btnGeneratePeriodicReport.Text = "Generate Periodic Report";
            this.btnGeneratePeriodicReport.UseVisualStyleBackColor = true;
            this.btnGeneratePeriodicReport.Click += new System.EventHandler(this.btnGeneratePeriodicReport_Click);
            // 
            // btnGenerateProfitabilityReport
            // 
            this.btnGenerateProfitabilityReport.Location = new System.Drawing.Point(661, 12);
            this.btnGenerateProfitabilityReport.Name = "btnGenerateProfitabilityReport";
            this.btnGenerateProfitabilityReport.Size = new System.Drawing.Size(125, 23);
            this.btnGenerateProfitabilityReport.TabIndex = 5;
            this.btnGenerateProfitabilityReport.Text = "Generate Profitability Report";
            this.btnGenerateProfitabilityReport.UseVisualStyleBackColor = true;
            this.btnGenerateProfitabilityReport.Click += new System.EventHandler(this.btnGenerateProfitabilityReport_Click);
            // 
            // ReportForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGenerateProfitabilityReport);
            this.Controls.Add(this.btnGeneratePeriodicReport);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.txtWarehouseId);
            this.Controls.Add(this.dgvReport);
            this.Name = "ReportForm";
            this.Text = "Report Form";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
