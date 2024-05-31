using Stumped.Models;

namespace Stumped.Data.Repositories
{
    public interface IQuoteRepository
    {
        Task<Quote> CreateQuoteAsync(Quote quote);
        Task<Quote> GetQuoteByIdAsync(int quoteId);
        Task<Quote> UpdateQuoteAsync(Quote quote);
    }

}
