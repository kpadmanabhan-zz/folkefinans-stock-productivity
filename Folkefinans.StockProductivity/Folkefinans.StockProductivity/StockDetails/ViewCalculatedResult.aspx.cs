using System;
using System.Web;

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