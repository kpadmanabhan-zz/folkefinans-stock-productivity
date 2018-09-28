using System;
using System.Web;
using System.Web.UI;

namespace Folkefinans.StockProductivity.StockDetails
{
    public partial class EnterStockDetails : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated) {
                Response.Redirect(@"/Account/Login.aspx?ReturnUrl=/StockDetails/EnterStockDetails.aspx");
            }
        }

        protected void btnCalculate_Click(object sender, EventArgs e)
        {

        }
    }
}