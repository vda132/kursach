using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models.PK
{
    class AuthorBookFundPK
    {
        public int BookID { get; set; }
        public int LibraryBookNO { get; set; }
        public int AuthorID { get; set; }
    }
}
