using MediatR;
using Stumped.Commands;
using Stumped.Data;
using Stumped.Models;

namespace Stumped.Handlers
{
    public class CreateQuoteHandler : IRequestHandler<CreateQuoteCommand, Quote>
    {
        private readonly AppDbContext _context;

        public CreateQuoteHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Quote> Handle(CreateQuoteCommand request, CancellationToken cancellationToken)
        {
            var quote = new Quote
            {
                Date = request.Date,
                ValidTo = request.ValidTo,
                QuoteNumber = request.QuoteNumber,
                Description = request.Description,
                Amount = request.Amount,
                Status = request.Status,
                AccountId = request.AccountId
            };

            _context.Quotes.Add(quote);
            await _context.SaveChangesAsync(cancellationToken);

            return quote;
        }
    }

}
