using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyMyHouse.Interfaces
{
    public interface IMortgageOfferService 
    {
        public void Run(bool send = false);
        public void GetUsers();
        public void SendEmails();
        public void Calculate();
        public void Save();
    }
}
