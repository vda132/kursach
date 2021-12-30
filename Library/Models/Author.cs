using Library.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Author:IModel
    {
        public int AuthorID { get; set; }
        public string AuthorName { get; set; }

        public IReadOnlyCollection<AuthorBookFund> AuthorBookFunds { get; set; } = new List<AuthorBookFund>();
        
    }
}
