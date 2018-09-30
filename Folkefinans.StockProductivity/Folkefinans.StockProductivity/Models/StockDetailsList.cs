using System.Collections.Generic;

namespace Folkefinans.StockProductivity.Models
{
    public class StockDetailsList
    {
        public StockDetailsList()
        {
            StockDetails = new List<StockDetails>();
        }

        public List<StockDetails> StockDetails { get; set; }
    }
}