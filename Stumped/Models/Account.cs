namespace Stumped.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public decimal Balance { get; set; }
        public List<Transaction> Transactions { get; set; }
        public List<Quote> Quotes { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
