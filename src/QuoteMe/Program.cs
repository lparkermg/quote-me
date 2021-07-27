using QuoteMe.Reader;
using QuoteMe.Writer;
using System;
using System.IO;

namespace QuoteMe
{
    class Program
    {
        private static string _dataPath => Path.Combine(AppContext.BaseDirectory, "quotes.json");
        static void Main(string[] args)
        {
            var stream = new FileStream(_dataPath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);

            var reader = new QuoteReader(stream);
            var writer = new QuoteWriter(stream);

            var quoter = new QuoteMe(reader, writer);


            Console.WriteLine("Hello World!");
        }
    }
}
