namespace Data.Models
{
    public class ProfitabilityReport
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal COGS { get; set; }
        public decimal Revenue { get; set; }
        public decimal GrossProfit { get; set; }
        public decimal GrossMargin { get; set; }
    }
}
