using System.Threading.Tasks;

namespace QuoteMe
{
    public interface IQuoteMe
    {
        Task Add(string quote);

        Task<string> GetRandom();
    }
}
