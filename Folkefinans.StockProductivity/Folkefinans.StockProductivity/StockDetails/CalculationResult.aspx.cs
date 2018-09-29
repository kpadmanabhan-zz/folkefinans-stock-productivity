using System;
using System.Web;
using System.Web.UI.WebControls;

namespace Folkefinans.StockProductivity.StockDetails
{
    public partial class CalculationResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated) {
                Response.Redirect(@"/Account/Login.aspx");
            }

            var stockdetails = (Models.StockDetails)Session["StockDetails"];
            if (stockdetails == null) {
                Response.Redirect(@"/StockDetails/EnterStockDetails.aspx");
            }

            tbcStockName.Text = stockdetails.StockName;
            tbcPrice.Text = stockdetails.Price.ToString();
            tbcQuantity.Text = stockdetails.Quantity.ToString();
            tbcPercentage.Text = stockdetails.Percentage.ToString();
            tbcYears.Text = stockdetails.Years.ToString();

            foreach(var key in stockdetails.StockResults.Keys) {
                var row = new TableRow();

                var cell1 = new TableCell {
                    Text = key.ToString()
                };
                row.Cells.Add(cell1);

                var cell2 = new TableCell {
                    Text = stockdetails.StockResults[key].ToString()
                };
                row.Cells.Add(cell2);

                tblResults.Rows.Add(row);
            }
        }
    }
}