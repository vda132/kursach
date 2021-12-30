using Library.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class ThemeBookFund:IModel
    {
        public int BookID { get; set; }
        public int LibraryBookNO { get; set; }
        public int ThemeID { get; set; }
        public Theme Theme { get; set; }
        public BookFund BookFund { get; set; }
    }
}
