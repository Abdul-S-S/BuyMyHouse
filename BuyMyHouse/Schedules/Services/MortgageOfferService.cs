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

namespace BuyMyHouse.Services
{
    public class MortgageOfferService : IMortgageOfferService
    {
        private readonly ILogger _logger;
        private readonly IDBUnitOfWork _dbUnitOfWork;
        public MortgageOfferService(ILogger<MortgageOfferService> logger, IDBUnitOfWork dBUnitOfWork)
        {
            _logger = logger;
            _dbUnitOfWork = dBUnitOfWork;
        }
        public void Calculate()
        {

        }

        public void Save()
        {
        }

        public void GetUsers()
        {
            throw new NotImplementedException();
        }

        public void SendEmails()
        {
            throw new NotImplementedException();
        }
        public void Run(bool Send)
        {
            if (Send)
            {

            }
            else
            {

            }
        }

    }
}
