using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using BuyMyHouse.Interfaces;

namespace BuyMyHouse.Schedules
{
    public class SendMortgageOffers
    {
        private readonly IMortgageOfferService _sendMortgageOffersService;

        public SendMortgageOffers(IMortgageOfferService sendMortgageOffersService)
        {
            _sendMortgageOffersService = sendMortgageOffersService;
        }
        [FunctionName("SendMortgageOffers")]
        public void Run([TimerTrigger("0 0 8 * * 1-5")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            try
            {
                _sendMortgageOffersService.Run(true);
            }
            catch (Exception e)
            {
                log.LogError($"Error sending mortgage offers: {e.Message}");
            }
        }
    }
}
