using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace QuoteMe.Writer
{
    public sealed class QuoteWriter : IQuoteWriter
    {
        private readonly FileStream _stream;

        public QuoteWriter(FileStream stream) => _stream = stream;

        public async Task WriteQuotesAsync(IList<string> data)
        {
            using (var writer = new StreamWriter(_stream))
            {
                var json = JsonSerializer.Serialize(data);
                await writer.WriteAsync(json);
            }
        }
    }
}
