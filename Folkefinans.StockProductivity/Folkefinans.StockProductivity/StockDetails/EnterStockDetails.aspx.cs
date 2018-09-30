using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using Newtonsoft.Json;

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
            var stockDetails = new Models.StockDetailsModel {
                StockName = txtStockName.Text,
                Percentage = Convert.ToDecimal(txtPercentage.Text),
                Price = Convert.ToDecimal(txtPrice.Text),
                Quantity = Convert.ToInt32(txtQuantity.Text),
                Years = Convert.ToInt32(txtYears.Text)
            };

            var responseJson = CalculateAsync(stockDetails).GetAwaiter().GetResult();
            var returnStockDetails = JsonConvert.DeserializeObject<Models.StockDetails>(responseJson);
            Session["StockDetails"] = returnStockDetails;

            Response.Redirect(@"/StockDetails/CalculationResult.aspx");
        }

        private async Task<string> CalculateAsync(Models.StockDetailsModel stockDetails)
        {
            using (var client = new HttpClient()) {
                client.BaseAddress = new Uri("http://localhost:50798");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.PostAsJsonAsync("api/StockDetails", stockDetails).ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                var responseJson = await response.Content.ReadAsStringAsync();
                
                return responseJson;
            }
        }
    }
}