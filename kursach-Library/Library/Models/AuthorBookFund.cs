using Library.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class AuthorBookFund:IModel
    {
        public int BookID { get; set; }
        public int LibraryBookNO { get; set; }
        public int AuthorID { get; set; }
        public BookFund BookFund { get; set; }
        public Author Author { get; set; }
    }
}
