namespace Stumped.Models
{
    public class Quote
    {
        public int QuoteId { get; set; }
        public DateTime Date { get; set; }
        public DateTime ValidTo { get; set; }
        public string QuoteNumber { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }

}
