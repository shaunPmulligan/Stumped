using Stumped.Models;

namespace Stumped.Data.Repositories
{
    public class QuoteRepository : IQuoteRepository
    {
        private readonly AppDbContext _context;

        public QuoteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Quote> CreateQuoteAsync(Quote quote)
        {
            _context.Quotes.Add(quote);
            await _context.SaveChangesAsync();
            return quote;
        }

        public async Task<Quote> GetQuoteByIdAsync(int quoteId)
        {
            return await _context.Quotes.FindAsync(quoteId);
        }

        public async Task<Quote> UpdateQuoteAsync(Quote quote)
        {
            _context.Quotes.Update(quote);
            await _context.SaveChangesAsync();
            return quote;
        }
    }

}
