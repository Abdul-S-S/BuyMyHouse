using System;

namespace Datastore.Models
{
    public class MortgageOffer
    {
        public string ID { get; set; }
        public double TotalMortgage { get; set; }
        public double MonthlyPayments { get; set; }
        public DateTime Created { get; set; }
        public User User { get; set; }

        public MortgageOffer()
        {

        }
        public MortgageOffer(double totalMortgage, double monthlyPayments)
        {
            ID = Guid.NewGuid().ToString();
            TotalMortgage = totalMortgage;
            MonthlyPayments = monthlyPayments;
            Created = DateTime.Now;
        }
    }
}
