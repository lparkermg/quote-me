using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace QuoteMe.Reader
{
    public sealed class QuoteReader : IQuoteReader
    {
        private readonly FileStream _stream;

        public QuoteReader(FileStream stream) => _stream = stream;
        public async Task<IList<string>> GetAllQuotesAsync()
        {
            using (var reader = new StreamReader(_stream))
            {
                var data = await reader.ReadToEndAsync();

                if (string.IsNullOrWhiteSpace(data))
                {
                    return new List<string>();
                }

                return JsonSerializer.Deserialize<IList<string>>(data);
            }
        }
    }
}
