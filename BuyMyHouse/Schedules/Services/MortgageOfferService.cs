using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuyMyHouse.Interfaces;
using Datastore.Context;
using Datastore.Operators;
using Datastore.Operators.Interfaces;
using Microsoft.Extensions.Logging;
using Datastore.Models;
using System.IO;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace BuyMyHouse.Services
{
    public class MortgageOfferService : IMortgageOfferService
    {
        private readonly ILogger _logger;
        private readonly IDBUnitOfWork _dbUnitOfWork;

        string EmailTempalte
        {
            get
            {
                if (File.Exists(Environment.GetEnvironmentVariable("EmailTemplatePath")))
                {
                    return File.ReadAllText(Environment.GetEnvironmentVariable("EmailTemplatePath"));
                }
                return "";
            }
        }
        public MortgageOfferService(ILogger<MortgageOfferService> logger, IDBUnitOfWork dBUnitOfWork)
        {
            _logger = logger;
            _dbUnitOfWork = dBUnitOfWork;
        }
        public void Calculate()
        {
            var users = _dbUnitOfWork.Reader.Read<User>(u => u.YearlyIncome != null);
            if (users != null)
            {
                foreach (var user in users.ToList())
                {
                    double userYearlyIncome = (double)(user.YearlyIncome != null ? user.YearlyIncome : 0);
                    if (userYearlyIncome>0)
                    user.MortgageOffer = new MortgageOffer(userYearlyIncome * 200, (userYearlyIncome / 12) / 3);
                   _dbUnitOfWork.Writer.Update(user);
                }
            }
        }

       

        public List<User> GetUsers()
        {
            return _dbUnitOfWork.Reader.Read<User>(u => u.Notified == false && u.MortgageOffer != null).ToList();
        }

        public async Task SendEmails()
        {
            foreach(var user in GetUsers())
            {
                await SendEmail(user);
            }
        }
        public async Task SendEmail(User u)
        {
            string emailBody = EmailTempalte.Replace("@Firstname", u.Firstname).Replace("@Lastname", u.Lastname).Replace("MortgageOffer", u.MortgageOffer.ToString());
            string sendGridApiKey = Environment.GetEnvironmentVariable("sendgrid_key");
            var client = new SendGridClient(sendGridApiKey);
            var message = new SendGridMessage();
            message.SetFrom("611315@student.inholland.nl", "BuyMyHouse");
            message.AddTo(u.Email);
            message.SetSubject("[BuyMyHouse RealEstate");
            message.HtmlContent = emailBody;

            var response = await client.SendEmailAsync(message);

            if (!response.IsSuccessStatusCode)
            {
                var responseBody = await response.Body.ReadAsStringAsync();
                _logger.LogError($"Error Sending Email: {responseBody}");
            }
        }
        public void Run(bool Send)
        {
            if (Send)
            {
                SendEmails();
            }
            else
            {
                Calculate();
            }
        }

    }
}
