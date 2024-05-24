using Business.Services;
using Data.Models;

namespace UIForms.UI
{
    public partial class ReportForm : Form
    {
        private readonly ReportService _reportService;

        public ReportForm(ReportService reportService)
        {
            _reportService = reportService;
            InitializeComponent();
        }

        private void btnGeneratePeriodicReport_Click(object sender, EventArgs e)
        {
            int warehouseId = int.Parse(txtWarehouseId.Text);
            DateTime startDate = dtpStartDate.Value;
            DateTime endDate = dtpEndDate.Value;

            List<InventoryMovementReport> report = _reportService.GetPeriodicInventoryReport(warehouseId, startDate, endDate);

            // Display the report in a DataGridView or any other control
            dgvReport.DataSource = report;
        }

        private void btnGenerateProfitabilityReport_Click(object sender, EventArgs e)
        {
            int warehouseId = int.Parse(txtWarehouseId.Text);
            DateTime startDate = dtpStartDate.Value;
            DateTime endDate = dtpEndDate.Value;

            List<ProfitabilityReport> report = _reportService.GetProfitabilityReport(warehouseId, startDate, endDate);

            // Display the report in a DataGridView or any other control
            dgvReport.DataSource = report;
        }
    }
}
