using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Folkefinans.StockProductivity.StockDetails
{
    public partial class ViewCalculatedResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated) {
                Response.Redirect(@"/Account/Login.aspx?ReturnUrl=/StockDetails/ViewCalculatedResult.aspx");
            }
        }
    }
}