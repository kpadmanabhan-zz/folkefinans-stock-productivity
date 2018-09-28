using System;
using System.Net.Http;
using System.Threading.Tasks;
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
            var stockDetails = new Models.StockDetails {
                StockName = txtStockName.Text,
                Percentage = Convert.ToDecimal(txtPercentage.Text),
                Price = Convert.ToDecimal(txtPrice.Text),
                Quantity = Convert.ToInt32(txtQuantity.Text),
                Years = Convert.ToInt32(txtYears.Text)
            };

            var x = CalculateAsync(stockDetails).GetAwaiter().GetResult();
        }

        private async Task<Uri> CalculateAsync(Models.StockDetails stockDetails)
        {
            using (var client = new HttpClient()) {
                client.BaseAddress = new Uri("http://localhost:50798");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.PostAsJsonAsync("api/StockDetails", stockDetails);
                response.EnsureSuccessStatusCode();

                return response.Headers.Location;
            }
        }
    }
}