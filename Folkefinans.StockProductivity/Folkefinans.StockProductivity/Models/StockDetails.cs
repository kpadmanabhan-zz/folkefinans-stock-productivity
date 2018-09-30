using System.Collections.Generic;

namespace Folkefinans.StockProductivity.Models
{
    public class StockDetails
    {
        public int Id { get; set; }

        public string StockName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Percentage { get; set; }
        public int Years { get; set; }

        public Dictionary<int, decimal> StockResults { get; set; }
    }
}