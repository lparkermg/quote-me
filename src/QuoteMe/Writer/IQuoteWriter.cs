using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoteMe.Writer
{
    public interface IQuoteWriter
    {
        Task WriteQuotesAsync(IList<string> quotes);
    }
}
