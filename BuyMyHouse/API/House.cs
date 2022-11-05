using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BuyMyHouse.API
{
    public class House
    {
        [FunctionName("House")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "house")] HttpRequest req,
            ILogger log)
        {
            //if request contains range get houses in range.
            if (req.Method == "GET")
            {
                return new OkObjectResult("Houses here");
            }
            else
            {
                return new NotFoundObjectResult("Request is invalid");
            }
            //get the houses 
            //list the houses
        }
    }
}
