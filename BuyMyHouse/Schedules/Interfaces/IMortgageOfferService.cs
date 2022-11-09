using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datastore.Models;

namespace BuyMyHouse.Interfaces
{
    public interface IMortgageOfferService 
    {
        public void Run(bool send = false);
        public List<User> GetUsers();
        public Task SendEmails();
        public void Calculate();
    }
}
