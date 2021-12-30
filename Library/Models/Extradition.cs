using Library.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Extradition:IModel
    {
        public int BookID { get; set; }
        public int LibraryBookNO { get; set; }
        public int ReaderNo { get; set; }
        public DateTime DateOfExtradition { get; set; }
        public DateTime DateOfReturn { get; set; }
        public string Information { get; set; }
        public BookFund BookFund { get; set; }
        public Reader Reader { get; set; }
    }
}
