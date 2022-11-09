using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using BuyMyHouse.Interfaces;

namespace BuyMyHouse.Schedules
{
    public class MortgageOffer
    {
        private readonly IMortgageOfferService _mortgageOfferService;

        public MortgageOffer(IMortgageOfferService mortgageOfferService) 
        {
            _mortgageOfferService = mortgageOfferService;
        }
        [FunctionName("CalculateMortgageOffer")]
        public void Run([TimerTrigger("0 */5 * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            try
            {
                _mortgageOfferService.Run();
            }
            catch (Exception e)
            {
                log.LogError($"Error sending mortgage offers: {e.Message}");
            }
        }
    }
}
