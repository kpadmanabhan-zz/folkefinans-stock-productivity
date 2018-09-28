using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Folkefinans.StockProductivity.Controller
{
    public class StockDetailsController : ApiController
    {
        // POST api/<controller>
        public void Post([FromBody]Models.StockDetails stockDetails)
        {
            
        }
    }
}