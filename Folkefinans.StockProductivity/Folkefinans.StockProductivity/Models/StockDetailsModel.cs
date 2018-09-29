namespace Folkefinans.StockProductivity.Models
{
    public class StockDetailsModel
    {
        public string StockName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Percentage { get; set; }
        public int Years { get; set; }
    }
}