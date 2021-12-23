using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Providers.Factories
{
    class FactoryProvider
    {
        private static FactoryProvider instance = null;

        public AuthorProvider AuthorProvider { get; }
        public AuthorBookFundProvider AuthorBookFundProvider { get; }
        public BookFundProvider BookFundProvider { get; }
        public ExtraditionProvider ExtraditionProvider { get; }
        public ReaderProvider ReaderProvider { get; }
        public ThemeProvider ThemeProvider { get; }
        public ThemeBookFundProvider ThemeBookFundProvider { get; }
        public UserProvider UserProvider { get; }
        private FactoryProvider()
        {
            AuthorProvider = new AuthorProvider();
            AuthorBookFundProvider = new AuthorBookFundProvider();
            BookFundProvider = new BookFundProvider();
            ExtraditionProvider = new ExtraditionProvider();
            ReaderProvider = new ReaderProvider();
            ThemeProvider = new ThemeProvider();
            ThemeBookFundProvider = new ThemeBookFundProvider();
            UserProvider = new UserProvider();
        }

        public static FactoryProvider GetInstance()
        {
            return instance == null ? (instance = new FactoryProvider()) : instance;
        }
    }
}
