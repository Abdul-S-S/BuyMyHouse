using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using BuyMyHouse.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Datastore.Models;

namespace BuyMyHouse.API
{
    public class UserAPI
    {
        private readonly IUserService _userService;

        public UserAPI(IUserService userService)
        {
            _userService = userService;
        }
        [FunctionName("User")]
        public async Task<IActionResult> GetUsers(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = "user")] HttpRequest req,
            ILogger log)
        {
            //if request contains range get houses in range.
            if (req.Method == "GET")
            {
                var result = _userService.GetUsers();
                return new OkObjectResult(JsonConvert.SerializeObject(result));
            }
            else if (req.Method == "POST")
            {
                string requestBody = await req.ReadAsStringAsync();
                User user = JsonConvert.DeserializeObject<User>(requestBody);
                _userService.WriteUser(user);
                return new OkObjectResult(JsonConvert.SerializeObject(user));
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
