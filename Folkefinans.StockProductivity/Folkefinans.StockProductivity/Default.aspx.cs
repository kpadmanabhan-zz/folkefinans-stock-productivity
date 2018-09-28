using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Folkefinans.StockProductivity
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnEnterStockDetails_Click(object sender, EventArgs e)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated) {
                Response.Redirect(@"Account\Login.aspx");
            }
        }

        protected void btnViewCalculatedResult_Click(object sender, EventArgs e)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated) {
                Response.Redirect(@"Account\Login.aspx");
            }
        }
    }
}