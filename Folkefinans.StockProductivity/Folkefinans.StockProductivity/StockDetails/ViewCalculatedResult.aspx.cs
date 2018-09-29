using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;
using Folkefinans.StockProductivity.Models;
using Newtonsoft.Json;

namespace Folkefinans.StockProductivity.StockDetails
{
    public partial class ViewCalculatedResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated) {
                Response.Redirect(@"/Account/Login.aspx?ReturnUrl=/StockDetails/ViewCalculatedResult.aspx");
            }

            if (IsPostBack) {
                var idStr = Request.Params.Get("__EVENTTARGET");
                idStr = idStr.Replace("StockDetailsRow_", "");
                var id = Convert.ToInt32(idStr);

                var detailsJson = GetStockDetails(id).GetAwaiter().GetResult();
                var stockDetails = JsonConvert.DeserializeObject<Models.StockDetails>(detailsJson);

                lblStockName.Text = $"Stock Name: {stockDetails.StockName}";
                PopulateDetailsTable(stockDetails);
            }

            var responseJson = GetAllStocks().GetAwaiter().GetResult();
            var returnStockDetailsList = JsonConvert.DeserializeObject<List<Models.StockDetailsModel>>(responseJson);
            PopulateOverviewTable(returnStockDetailsList);
        }

        private void PopulateDetailsTable(Models.StockDetails stockDetails)
        {
            foreach (var key in stockDetails.StockResults.Keys) {
                var row = new TableRow();

                var cell1 = new TableCell {
                    Text = key.ToString()
                };
                row.Cells.Add(cell1);

                var cell2 = new TableCell {
                    Text = stockDetails.StockResults[key].ToString()
                };
                row.Cells.Add(cell2);

                tblResults.Rows.Add(row);
            }
        }

        private void PopulateOverviewTable(List<Models.StockDetailsModel> stockDetailsList)
        {
            foreach (var stockDetails in stockDetailsList) {
                var row = new TableRow();
                row.ID = $"StockDetailsRow_{stockDetails.Id.ToString()}";

                var cell1 = new TableCell {
                    Text = stockDetails.StockName
                };
                row.Cells.Add(cell1);

                var cell2 = new TableCell {
                    Text = stockDetails.Price.ToString()
                };
                row.Cells.Add(cell2);

                var cell3 = new TableCell {
                    Text = stockDetails.Quantity.ToString()
                };
                row.Cells.Add(cell3);

                var cell4 = new TableCell {
                    Text = stockDetails.Percentage.ToString()
                };
                row.Cells.Add(cell4);

                var cell5 = new TableCell {
                    Text = stockDetails.Years.ToString()
                };
                row.Cells.Add(cell5);

                row.Attributes.Add("onclick", "__doPostBack('" + row.ID + "','')");

                tblProductivityResults.Rows.Add(row);
            }
        }

        private async Task<string> GetAllStocks()
        {
            using (var client = new HttpClient()) {
                client.BaseAddress = new Uri("http://localhost:50798");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync("api/StockDetails").ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                var responseJson = await response.Content.ReadAsStringAsync();

                return responseJson;
            }
        }

        private async Task<string> GetStockDetails(int id)
        {
            using (var client = new HttpClient()) {
                client.BaseAddress = new Uri("http://localhost:50798");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync($"api/StockDetails/{id}").ConfigureAwait(false);
                response.EnsureSuccessStatusCode();

                var responseJson = await response.Content.ReadAsStringAsync();

                return responseJson;
            }
        }
    }
}