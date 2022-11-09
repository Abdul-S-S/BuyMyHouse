using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using BuyMyHouse.Interfaces;

namespace BuyMyHouse.API
{
    public class HouseAPI
    {
        private readonly IHouseService _houseService;

        public HouseAPI(IHouseService houseService)
        {
            _houseService = houseService;
        }
        [FunctionName("House")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "house")] HttpRequest req,
            ILogger log)
        {
            //if request contains range get houses in range.
            if (req.Method == "GET")
            {
                int min, max;
                string range = req.Query["priceRange"];
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                dynamic data = JsonConvert.DeserializeObject(requestBody);
                range = range ?? data?.name;
                if (!string.IsNullOrEmpty(range))
                {
                    try
                    {
                        string[] minMax = range.Split("-");
                        _houseService.GetHouses(h => h.Price > Convert.ToDouble(minMax[0]) && h.Price < Convert.ToDouble(minMax[1]));
                    }
                    catch(Exception e)
                    {
                        log.LogError($"Range was not passed in the correct format: {e.Message}");
                    }
                    try
                    {
                        _houseService.GetHouses();
                    }
                    catch (Exception e)
                    {
                        log.LogError($"Error retrieving houses: {e.Message}");
                    }
                }
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
