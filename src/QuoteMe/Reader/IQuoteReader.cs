using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoteMe.Reader
{
    public interface IQuoteReader
    {
        Task<IList<string>> GetAllQuotesAsync();
    }
}
