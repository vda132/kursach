using Library.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    class BookFund : IModel
    {
        public int BookID { get; set; }
        public int LibraryBookNO { get; set; }
        public string BookName { get; set; }
        public DateTime DateOfPublication { get; set; }
        public int Capacity { get; set; }
        public decimal Price { get; set; }
        public IReadOnlyCollection<Extradition> Extraditions { get; set; } = new List<Extradition>();
        public IReadOnlyCollection<ThemeBookFund> ThemeBookFunds { get; set; } = new List<ThemeBookFund>();
        public IReadOnlyCollection<AuthorBookFund> AuthorBookFunds { get; set; } = new List<AuthorBookFund>();
    }
}
