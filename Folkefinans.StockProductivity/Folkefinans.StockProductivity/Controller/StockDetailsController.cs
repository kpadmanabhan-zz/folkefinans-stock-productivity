using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Web.Http;
using Folkefinans.StockProductivity.Providers;
using Newtonsoft.Json;

namespace Folkefinans.StockProductivity.Controller
{
    public class StockDetailsController : ApiController
    {
        private const string jsonPath = @"~/App_Data/StockDetailsList.json";
        private readonly IFileSystem fileSystem;
        private readonly IPathProvider pathProvider;

        public StockDetailsController(IFileSystem fileSystemObj, IPathProvider pathProviderObj)
        {
            fileSystem = fileSystemObj;
            pathProvider = pathProviderObj;
        }

        public StockDetailsController():this(new FileSystem(), new ServerPathProvider())
        {

        }

        [HttpPost]
        // POST api/<controller>
        public Models.StockDetails Post([FromBody]Models.StockDetailsModel inputStockDetails)
        {
            var storedStockDetailsList = ReadStockDetailsJson();

            var stockDetails = new Models.StockDetails {
                Id = storedStockDetailsList.StockDetails.Count + 1,
                StockName = inputStockDetails.StockName,
                Price = inputStockDetails.Price,
                Quantity = inputStockDetails.Quantity,
                Percentage = inputStockDetails.Percentage,
                Years = inputStockDetails.Years
            };

            CalculateResults(stockDetails);

            storedStockDetailsList.StockDetails.Add(stockDetails);

            var json = JsonConvert.SerializeObject(storedStockDetailsList);
            fileSystem.File.WriteAllText(pathProvider.MapPath(jsonPath), json);

            return stockDetails;
        }

        [HttpGet]
        public List<Models.StockDetailsModel> GetAllStocks()
        {
            var storedStockDetailsList = ReadStockDetailsJson();

            return storedStockDetailsList.StockDetails
                .Select(x => new Models.StockDetailsModel {
                    Id = x.Id,
                    StockName = x.StockName,
                    Price = x.Price,
                    Quantity = x.Quantity,
                    Percentage = x.Percentage,
                    Years = x.Years
                }).ToList();
        }

        [HttpGet]
        public Models.StockDetails GetStockDetails(int id)
        {
            var storedStockDetailsList = ReadStockDetailsJson();

            return storedStockDetailsList.StockDetails.FirstOrDefault(x => x.Id == id);
        }

        private Models.StockDetailsList ReadStockDetailsJson()
        {
            var storedStockDetailsJson = fileSystem.File.ReadAllText(pathProvider.MapPath(jsonPath));
            var storedStockDetailsList = JsonConvert.DeserializeObject<Models.StockDetailsList>(storedStockDetailsJson);

            if (storedStockDetailsList == null) {
                //First time
                storedStockDetailsList = new Models.StockDetailsList();
            }

            return storedStockDetailsList;
        }

        private void CalculateResults(Models.StockDetails stockDetails)
        {
            stockDetails.StockResults = new Dictionary<int, decimal>();

            var value = Math.Round(stockDetails.Price * stockDetails.Quantity, 2);
            stockDetails.StockResults.Add(0, value);
            for (int i=1; i<=stockDetails.Years; i++) {
                value += Math.Round(value * 3 / 100, 2);
                stockDetails.StockResults.Add(i, value);
            }
        }
    }
}