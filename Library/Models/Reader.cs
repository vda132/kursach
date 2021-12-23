using Library.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    class Reader:IModel
    {
        public int ReaderNo { get; set; }
        public string ReaderName { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public IReadOnlyCollection<Extradition> Extraditions { get; set; } = new List<Extradition>();
    }
}
