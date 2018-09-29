﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace Folkefinans.StockProductivity.Controller
{
    public class StockDetailsController : ApiController
    {
        private const string jsonPath = @"~/App_Data/StockDetailsList.json";

        // POST api/<controller>
        public Models.StockDetails Post([FromBody]Models.StockDetailsModel inputStockDetails)
        {
            var storedStockDetailsJson = File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath(jsonPath));
            var storedStockDetailsList = JsonConvert.DeserializeObject<Models.StockDetailsList>(storedStockDetailsJson);

            if (storedStockDetailsList == null) {
                //First time
                storedStockDetailsList = new Models.StockDetailsList();
            }

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
            File.WriteAllText(System.Web.HttpContext.Current.Server.MapPath(jsonPath), json);

            return stockDetails;
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