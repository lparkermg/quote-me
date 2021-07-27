using QuoteMe.Reader;
using QuoteMe.Writer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoteMe
{
    public class QuoteMe : IQuoteMe
    {
        private readonly IQuoteReader _reader;
        private readonly IQuoteWriter _writer;
        private readonly Random _rng;

        public QuoteMe(IQuoteReader reader, IQuoteWriter writer)
        {
            _reader = reader;
            _writer = writer;
            _rng = new Random(DateTime.UtcNow.GetHashCode());
        }

        public async Task Add(string quote)
        {
            if (string.IsNullOrWhiteSpace(quote))
            {
                throw new ArgumentException($"Argument {nameof(quote)} cannot be null, empty or whitespace.");
            }

            var quotes = await _reader.GetAllQuotesAsync();

            quotes.Add(quote);

            await _writer.WriteQuotesAsync(quotes);
        }

        public async Task<string> GetRandom()
        {
            var quotes = (await _reader.GetAllQuotesAsync()).ToArray();

            if (quotes.Length == 0)
            {
                return null;
            }

            return quotes[_rng.Next(0, quotes.Length)];
        }
    }
}
