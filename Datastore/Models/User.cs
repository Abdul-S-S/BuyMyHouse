namespace Datastore.Models
{
    public class User
    {
        public string ID { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Email { get; set; }
        public double? YearlyIncome { get; set; }
        public bool? Notified { get; set; } = false;
        public MortgageOffer? MortgageOffer { get; set; } = null;
        public User(string? firstname, string? lastname, string? email, double? yearlyIncome, bool? notified, MortgageOffer? mortgageOffer)
        {
            ID = Guid.NewGuid().ToString();
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            YearlyIncome = yearlyIncome;
            Notified = notified;
            MortgageOffer = mortgageOffer;
        }
        public User()
        {
            ID = Guid.NewGuid().ToString();
        }
    }

}
